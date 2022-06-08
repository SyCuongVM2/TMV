CREATE PROCEDURE [AppAuthPkgTableGetErrorMessage]
	@p_ErrType char, 
  @p_ErrObject varchar(50)
AS
BEGIN
	SET NOCOUNT ON;

	DECLARE @v_ObjectName varchar(250)
    DECLARE @v_ObjectDesc nvarchar(250)
    DECLARE @v_Message nvarchar(3000)

    DECLARE db_cursor CURSOR FOR 
     select Column_Name from information_schema.key_column_usage 
      where CONSTRAINT_NAME = @p_ErrObject 

    If @p_ErrType = 'R'
    BEGIN
		    Select @v_ObjectName = table_name 
          From information_schema.constraint_table_usage
         Where constraint_name = @p_ErrObject

        SET @v_ObjectDesc = @v_ObjectName
        SET @v_Message = 'Please delete all child in ' + @v_ObjectDesc + ' this item.'
    END
    ELSE
    BEGIN
        If @p_ErrType = 'U'
        BEGIN
            SET @v_ObjectDesc = ''            
			OPEN db_cursor 
			FETCH NEXT FROM db_cursor INTO @v_ObjectName
            WHILE @@FETCH_STATUS = 0
            BEGIN
			    IF @v_ObjectDesc = ''
                BEGIN
                   SET @v_Message = 'Can not insert duplicate value in column '
                   SET @v_ObjectDesc =  @v_ObjectDesc + @v_ObjectName + ''''
                END
                ELSE
                BEGIN
                   SET @v_Message = 'Can not insert duplicate value in columns '
                   SET @v_ObjectDesc = @v_ObjectDesc + ' , ''' + @v_ObjectName + '''';
                END
                FETCH NEXT FROM db_cursor INTO @v_ObjectName
            END
            
			CLOSE db_cursor 
			DEALLOCATE db_cursor 
           
            SET @v_Message = @v_Message + @v_ObjectDesc + '.'
        END
    END
    Select @v_Message Error_Message
END