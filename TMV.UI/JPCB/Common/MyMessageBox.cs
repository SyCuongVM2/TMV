using System.Drawing;
using System.Windows.Forms;

namespace TMV.UI.JPCB.Common
{
  public static class MyMessageBox
  {
    public static DialogResult Show(string message, string caption, string button1 = "OK", string button2 = "Cancel")
    {
      Form form = new Form();
      PictureBox pictureBox = new PictureBox();
      Label lblMessage = new Label();
      Button btnOK = new Button();
      Button btnCancel = new Button();

      // pictureBox
      pictureBox.Image = Properties.Resources.Warning;
      pictureBox.Location = new Point(35, 26);
      pictureBox.Size = new Size(53, 50);

      // lblMessage
      lblMessage.AutoSize = true;
      lblMessage.Location = new Point(109, 43);
      lblMessage.Size = new Size(375, 20);
      lblMessage.Text = message;

      // btnOK
      btnOK.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnOK.DialogResult = DialogResult.OK;
      btnOK.FlatStyle = FlatStyle.Popup;
      btnOK.Location = new Point(158, 120);
      btnOK.Size = new Size(143, 36);
      btnOK.Text = button1;
      btnOK.UseVisualStyleBackColor = true;

      // btnCancel
      btnCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
      btnCancel.DialogResult = DialogResult.Cancel;
      btnCancel.FlatStyle = FlatStyle.Popup;
      btnCancel.Location = new Point(307, 120);
      btnCancel.Size = new Size(172, 36);
      btnCancel.Text = button2;
      btnCancel.UseVisualStyleBackColor = true;

      form.AutoScaleDimensions = new SizeF(9F, 20F);
      form.AutoScaleMode = AutoScaleMode.Font;
      form.ClientSize = new Size(495, 168);
      form.Controls.Add(btnCancel);
      form.Controls.Add(pictureBox);
      form.Controls.Add(lblMessage);
      form.Controls.Add(btnOK);
      form.FormBorderStyle = FormBorderStyle.FixedDialog;
      form.MaximizeBox = false;
      form.MinimizeBox = false;
      form.StartPosition = FormStartPosition.CenterScreen;
      form.Text = caption;
      form.AcceptButton = btnOK;
      form.CancelButton = null;

      DialogResult dialogResult = form.ShowDialog();
      return dialogResult;
    }
  }
}