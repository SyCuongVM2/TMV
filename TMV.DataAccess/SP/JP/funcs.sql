DECLARE @temp AS TABLE (hex char(6))

INSERT  INTO @temp
VALUES  ('3333CC') -- Should convert to Red: 51 Green: 51 Blue: 204

DECLARE @table AS varchar(16)
SET @table = '0123456789abcdef' -- Assuming case-insensitive collation!

SELECT  hex
       ,16 * (CHARINDEX(SUBSTRING(hex, 1, 1), @table) - 1) + (CHARINDEX(SUBSTRING(hex, 2, 1), @table) - 1) AS R
       ,16 * (CHARINDEX(SUBSTRING(hex, 3, 1), @table) - 1) + (CHARINDEX(SUBSTRING(hex, 4, 1), @table) - 1) AS G
       ,16 * (CHARINDEX(SUBSTRING(hex, 5, 1), @table) - 1) + (CHARINDEX(SUBSTRING(hex, 6, 1), @table) - 1) AS B
FROM    @temp

CREATE FUNCTION udf_HexToRGB (@hex char(6))
RETURNS TABLE
AS RETURN
    (
     SELECT 16 * (CHARINDEX(SUBSTRING(@hex, 1, 1), '0123456789abcdef') - 1) + (CHARINDEX(SUBSTRING(@hex, 2, 1),
                                                                                         '0123456789abcdef') - 1) AS R
           ,16 * (CHARINDEX(SUBSTRING(@hex, 3, 1), '0123456789abcdef') - 1) + (CHARINDEX(SUBSTRING(@hex, 4, 1),
                                                                                         '0123456789abcdef') - 1) AS G
           ,16 * (CHARINDEX(SUBSTRING(@hex, 5, 1), '0123456789abcdef') - 1) + (CHARINDEX(SUBSTRING(@hex, 6, 1),
                                                                                         '0123456789abcdef') - 1) AS B
    )
GO