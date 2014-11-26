use 
BEGIN
	set nocount on
	DECLARE @str as varchar(4000)
	DECLARE @TableName as varchar(200)
	DECLARE @PK as varchar(200)
	DECLARE @LastColPosition as int
	DECLARE @AuditTableName as varchar(205)
	DECLARE @TriggerName as varchar(210)
	DECLARE @NewLine as varchar
	DECLARE @tabspace as varchar

	SET @TableName = 'SLT_Safety_Walk_Responses'
	SET @TriggerName = @TableName+'_AU_TRIGGER'
	SET @AuditTableName = @TableName+'_Audit'
	SET @PK = 'PK_SLT_Safety_Walk_Responses'
	SET @newline = char(13)
	SET @tabspace = char(9)
	SELECT @LastColPosition=max(Position) from tab WHERE tab = @TableName
		
	PRINT('if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].['+@AuditTableName+']''))'+@NewLine)
	PRINT('drop table [dbo].['+@AuditTableName+']')

	PRINT('CREATE TABLE [dbo].['+@AuditTableName+'] ('+@NewLine)	
	PRINT('[Audit_DateTime] [datetime] Not NULL,'+@NewLine)
-- [DataLength]
	SELECT '['+col+'] ['+datatype+'] ' + 
		CASE WHEN (isnull(length,0) = 0 OR datatype = 'text' or datatype = 'numeric' or datatype ='datetime') then '' else '('+cast(length as varchar)+')' end + 
		CASE WHEN  datatype = 'numeric' then '('+cast([DataLength] as varchar)+') ' else '' end + 
		CASE WHEN [IsNull]='YES' then 'NULL' else 'Not NULL' end + ','
	FROM tab where tab = @TableName and position <> @LastColPosition order by Position
	SELECT '['+col+'] ['+datatype+'] ' + 
		CASE WHEN isnull(length,0) = 0 then '' else '('+cast(length as varchar)+')' end + 
		CASE WHEN  datatype <> 'numeric' then '' else '('+cast([DataLength] as varchar)+') ' end + 
		CASE WHEN [IsNull]='YES' then 'NULL' else 'Not NULL' end + ')'
	from tab where tab = @TableName and position = @LastColPosition
	
	PRINT ('go')
	PRINT('if exists (select * from dbo.sysobjects where id = object_id(N''[dbo].['+@TriggerName+']''))')
	PRINT('drop trigger [dbo].['+@TriggerName+']')
	PRINT('go')
	PRINT('CREATE TRIGGER [dbo].['+@TriggerName+']'+@NewLine)
	PRINT('ON [dbo].['+@TableName+']'+@NewLine)
	PRINT('INSTEAD OF UPDATE AS'+@NewLine)
	PRINT('BEGIN'+@NewLine)
	PRINT('DECLARE @auditType varchar(10)'+@NewLine)

	PRINT(' Update ' + @TableName + @NewLine + ' Set ')
	SELECT '['+col+'] = i.'+ col + ',' from tab where tab = @TableName and position <> @LastColPosition and col <> @PK order by Position
	SELECT '['+col+'] = i.'+ col + ' ' from tab where tab = @TableName and position = @LastColPosition
	PRINT(' From ' + @TableName + ' tbl')
	PRINT(' INNER JOIN inserted i On i.' + @PK + ' = tbl.' + @PK +@NewLine)	

/*	print('IF EXISTS (Select '+ @PK +' from Inserted i)'+@NewLine)
	print('BEGIN SET @auditType = ''Updated'' END'+@NewLine)
	print('ELSE BEGIN SET @auditType = ''Deleted'' END'+@NewLine) */
	print('INSERT INTO [dbo].['+@AuditTableName+'](')
/*	print('[AuditType],'+@NewLine) */
	print('[Audit_DateTime],')
	select '['+col+'],' FROM tab WHERE tab = @TableName and position <> @LastColPosition order by Position
	select '['+col+'])' FROM tab WHERE tab = @TableName and position = @LastColPosition

	--print('Select @auditType,getdate(),'+@NewLine)
	PRINT('Select getdate(),'+@NewLine)
	SELECT 'd.'+col+',' FROM tab WHERE tab = @TableName and position <> @LastColPosition order by Position
	SELECT 'd.'+col FROM tab WHERE tab = @TableName and position = @LastColPosition
	PRINT(' FROM deleted d '+@NewLine)
	PRINT('end')
END