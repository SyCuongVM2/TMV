using System;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace TMV.BusinessObject.Admin
{
  public static class AppHashPassword
  {
    private static readonly RandomNumberGenerator _defaultRng = RandomNumberGenerator.Create();

    public static string HashPassword(string password)
    {
      return Convert.ToBase64String(HashPasswordV3(password, _defaultRng));
    }
    public static bool VerifyHashedPassword(string hashedPassword, string password)
    {
      byte[] decodedHashedPassword = Convert.FromBase64String(hashedPassword);
      try
      {
        // Read header information
        KeyDerivationPrf prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1); // KeyDerivationPrf.HMACSHA256
        int iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5); // -> 10000
        int saltSize = (int)ReadNetworkByteOrder(decodedHashedPassword, 9); // -> 16

        // Read the salt: must be >= 128 bits
        if (saltSize < 128 / 8)
          return false;

        byte[] salt = new byte[saltSize]; // -> 16
        Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

        // Read the subkey (the rest of the payload): must be >= 128 bits
        int numBytesRequested = decodedHashedPassword.Length - 13 - salt.Length; // -> 32
        if (numBytesRequested < 128 / 8)
          return false;

        byte[] expectedSubkey = new byte[numBytesRequested];
        Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

        // Hash the incoming password and verify it
        byte[] actualSubkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);
        return ByteArraysEqual(actualSubkey, expectedSubkey);
      }
      catch
      {
        // This should never occur except in the case of a malformed payload, where
        // we might go off the end of the array. Regardless, a malformed payload
        // implies verification failed.
        return false;
      }
    }

    private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng)
    {
      return HashPasswordV3(
        password, 
        rng,
        prf: KeyDerivationPrf.HMACSHA256,
        iterCount: 10000,
        saltSize: 128 / 8,
        numBytesRequested: 256 / 8
      );
    }
    private static byte[] HashPasswordV3(string password, RandomNumberGenerator rng, KeyDerivationPrf prf, int iterCount, int saltSize, int numBytesRequested)
    {
      // Produce a version 3 (see comment above) text hash.
      byte[] salt = new byte[saltSize]; // -> 16
      rng.GetBytes(salt);
      byte[] subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);
      var outputBytes = new byte[13 + salt.Length + subkey.Length];
      outputBytes[0] = 0x01; // format marker

      WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
      WriteNetworkByteOrder(outputBytes, 5, (uint)iterCount);
      WriteNetworkByteOrder(outputBytes, 9, (uint)saltSize);
      Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
      Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);

      return outputBytes;
    }
    private static bool ByteArraysEqual(byte[] a, byte[] b)
    {
      if (a == null && b == null)
        return true;

      if (a == null || b == null || a.Length != b.Length)
        return false;

      var areSame = true;
      for (var i = 0; i < a.Length; i++)
      {
        areSame &= (a[i] == b[i]);
      }

      return areSame;
    }
    private static void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
    {
      buffer[offset + 0] = (byte)(value >> 24);
      buffer[offset + 1] = (byte)(value >> 16);
      buffer[offset + 2] = (byte)(value >> 8);
      buffer[offset + 3] = (byte)(value >> 0);
    }
    private static uint ReadNetworkByteOrder(byte[] buffer, int offset)
    {
      return ((uint)(buffer[offset + 0]) << 24)
            | ((uint)(buffer[offset + 1]) << 16)
            | ((uint)(buffer[offset + 2]) << 8)
            | ((uint)(buffer[offset + 3]));
    }
  }
}