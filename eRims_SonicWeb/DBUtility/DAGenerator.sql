begin
set nocount on

declare @PK as varchar(100)
declare @Tab as varchar(100)
declare @NewLine as varchar
declare @tabspace as varchar
set @newline = char(13)
set @tabspace = char(9)
set @Tab = 'tblDfContactInfo';
set @PK = 'SequenceNumber';


--- set object property 
Print '#region Fields'
print ''
	select 'private '+
	case 
		when [Datatype]='int' then 'int'
		when [Datatype]='float' then 'Double'
		when [Datatype]='decimal' then 'decimal'
		when [Datatype]='numeric' then 'decimal' 
		when [Datatype]='nvarchar' then 'string' 
		when [Datatype]='char' then 'string' 
		when [Datatype]='varchar' then 'string' 
		when [Datatype]='bit' then 'bool'
		when [Datatype]='datetime' then 'DateTime'
		when [Datatype]='text' then 'string'
		when [Datatype]='bigint' then 'Int64'	
	end 
	+ ' _' + col + ';'	
	from tab where tab=@Tab
Print '#endregion'

print ''
print''

Print ' #region Properties '
print ''
select 
'/// <summary> '+ @newline +
'/// Gets or sets the ' + col + ' value.' + @newline +
'/// </summary>' + @newline + 'public ' +
case when [Datatype]='int' then 'int'
when [Datatype]='float' then 'Double'
when [Datatype]='decimal' then 'decimal'
when [Datatype]='numeric' then 'decimal'
when [Datatype]='nvarchar' then 'string'
when [Datatype]='varchar' then 'string' 
when [Datatype]='char' then 'string' 
when [Datatype]='bit' then 'bool'
when [Datatype]='datetime' then 'DateTime'
when [Datatype]='text' then 'string'
when [Datatype]='bigint' then 'Int64'		
end  +
' ' + col + @newline + 
'{' + @newline +
@tabspace + 'get { return _'+ col+'; }' + @newline +
@tabspace + 'set { _'+col+' = value; }' + @newline +
'}' + @newline + @newline
from tab where tab=@Tab
Print '#endregion'







print ''
print''

Print ' #region Constructors '
print ''

print '/// <summary> '+ @newline 
print '/// Initializes a new instance of the '+ @Tab +' class. with the default value.' + @newline 
print '/// </summary>' + @newline + 'public ' + @Tab + '()' + @newline + '{'
select @tabspace + 'this._'+col+' = '+
case when [Datatype]='int' then '-1;'
when [Datatype]='float' then '0.0;'
when [Datatype]='decimal' then '-1;'
when [Datatype]='numeric' then '-1;' 
when [Datatype]='char' then '"";' 
when [Datatype]='nvarchar' then '"";'
when [Datatype]='varchar' then '"";' 
when [Datatype]='text' then '"";' 
when [Datatype]='bit' then 'false;' 
when [Datatype]='datetime' then '(DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;'
when [Datatype]='bigint' then '0;'	
end 
from tab where tab=@Tab

print '}'
print ''
print @newline


print '/// <summary> '+ @newline 
print '/// Initializes a new instance of the '+ @Tab +' class for passed PrimaryKey with the values set from Database.' + @newline 
select '/// </summary>' + @newline + 'public ' + @Tab + '(' +
 case when [Datatype]='int' then 'int'
when [Datatype]='float' then 'Double'
when [Datatype]='decimal' then 'decimal'
when [Datatype]='numeric' then 'decimal' 
when [Datatype]='char' then 'string' 
when [Datatype]='nvarchar' then 'string'
when [Datatype]='varchar' then 'string' 
when [Datatype]='text' then 'string' 
when [Datatype]='bit' then 'bool' 
when [Datatype]='datetime' then 'DateTime'
when [Datatype]='bigint' then 'Int64'
end + ' PK)' + @newline + '{'
from tab where tab=@Tab and col = @PK
print @tabspace + 'DataTable dt'+ @Tab + ' = SelectById(PK).Tables[0];' + @newline 

print @tabspace + 'if (dt'+@Tab+'.Rows.Count > 0)' + @newline
print @tabspace + '{' +  @newline
print @tabspace + @tabspace + 'DataRow dr'+@Tab+ ' = dt'+@Tab+'.Rows[0];'

select @tabspace + @tabspace + 'this._'+col+' = '+
case when [Datatype]='int' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToDecimal(dr'+@Tab+'["'+col+'"]) : 0;'
when [Datatype]='float' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToDouble(dr'+@Tab+'["'+col+'"]) : 0.0;'
when [Datatype]='decimal' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToDecimal(dr'+@Tab+'["'+col+'"]) : 0;'
when [Datatype]='numeric' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToDecimal(dr'+@Tab+'["'+col+'"]) : 0;'
when [Datatype]='char' then 'Convert.ToString(dr'+@Tab+'["'+col+'"]);' 
when [Datatype]='nvarchar' then 'Convert.ToString(dr'+@Tab+'["'+col+'"]);'  
when [Datatype]='varchar' then 'Convert.ToString(dr'+@Tab+'["'+col+'"]);'  
when [Datatype]='text' then 'Convert.ToString(dr'+@Tab+'["'+col+'"]);'  
when [Datatype]='bit' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToBoolean(dr'+@Tab+'["'+col+'"]) : false;' 
when [Datatype]='datetime' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToDateTime(dr'+@Tab+'["'+col+'"]) : (DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;' 
when [Datatype]='bigint' then 'dr'+@Tab+'["'+col+'"] != DBNull.Value ? Convert.ToInt64(dr'+@Tab+'["'+col+'"]) : 0;' 
end 
from tab where tab=@Tab

print @tabspace + '}' + @newline
print @tabspace + 'else' + @newline
print @tabspace + '{' 
select @tabspace + @tabspace + 'this._'+col+' = '+
case when [Datatype]='int' then '-1;'
when [Datatype]='float' then '0.0;'
when [Datatype]='decimal' then '-1;'
when [Datatype]='numeric' then '-1;' 
when [Datatype]='char' then '"";' 
when [Datatype]='nvarchar' then '"";'
when [Datatype]='varchar' then '"";' 
when [Datatype]='text' then '"";' 
when [Datatype]='bit' then 'false;' 
when [Datatype]='datetime' then '(DateTime) System.Data.SqlTypes.SqlDateTime.MinValue;'
when [Datatype]='bigint' then '0;'
end 
from tab where tab=@Tab
print @tabspace + '}' + @newline
print '}'
print ''
print @newline



Print '#endregion'


end
