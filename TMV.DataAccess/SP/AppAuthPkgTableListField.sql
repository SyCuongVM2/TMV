﻿CREATE OR ALTER PROCEDURE [AppAuthPkgTableListField]
	@p_TableName VARCHAR(50)
AS
BEGIN
	SET NOCOUNT ON;

	SELECT TABLE_NAME,
		   COLUMN_NAME,
		   DATA_TYPE,
		   (CASE WHEN CHARACTER_MAXIMUM_LENGTH IS NULL THEN NUMERIC_PRECISION ELSE CHARACTER_MAXIMUM_LENGTH END) DATA_LENGTH,
		   NUMERIC_SCALE DATA_SCALE,
		   IS_NULLABLE,
		   (CASE (SELECT COLUMN_NAME  
				   FROM information_schema.constraint_column_usage A 
				   JOIN information_schema.table_constraints C  
					 ON A.CONSTRAINT_NAME = C.CONSTRAINT_NAME
				  WHERE C.CONSTRAINT_TYPE = 'PRIMARY KEY' 
					AND C.TABLE_NAME = B.TABLE_NAME 
					AND A.COLUMN_NAME = B.COLUMN_NAME) WHEN NULL THEN 0 ELSE 1 END) PK,
		   ORDINAL_POSITION
	  FROM information_schema.columns B
	 WHERE UPPER(TABLE_NAME)= @p_TableName
	   AND TABLE_CATALOG = (SELECT DB_NAME() AS DataBaseName)
	ORDER BY ORDINAL_POSITION
END