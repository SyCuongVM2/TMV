CREATE PROCEDURE [AppAuthPkgTableGetFieldValue]
	@p_Table_Name VARCHAR(50),
    @p_Column_Name VARCHAR(50),
    @p_PK_Value INT
AS
BEGIN
	SET NOCOUNT ON;

    DECLARE @v_PK_Field VARCHAR(50)
    DECLARE @v_SQL VARCHAR(250)

	SELECT @v_PK_Field = 
           COLUMN_NAME  
      FROM information_schema.constraint_column_usage A 
      JOIN information_schema.table_constraints C  
        ON A.CONSTRAINT_NAME = C.CONSTRAINT_NAME
     WHERE C.CONSTRAINT_TYPE = 'PRIMARY KEY' 
       AND C.TABLE_NAME = @p_Table_Name
     
     SET @v_SQL = 'SELECT ' + @p_Column_Name + ' FROM '+ @p_Table_Name + ' WHERE ' + @v_PK_Field + '=' + @p_PK_Value;
     
     EXEC (@v_SQL)
END