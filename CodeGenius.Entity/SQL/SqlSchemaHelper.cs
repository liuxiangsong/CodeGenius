using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using LibraryGenius;
using System.Data;

namespace CodeGenius.Entity
{
    public static class SqlSchemaHelper
    {
        #region Public Sql Script String
        #region Lau ReadColumnSqlScript 表列
        public const string ReadColumnSqlScript = @"
USE [{0}]
select 
        ObjectID		=OBJECT_ID(TABLE_NAME)
        ,ColumnID		=ORDINAL_POSITION
        ,Name		    =COLUMN_NAME
        ,DataType		=DATA_TYPE
        ,MaxLength	    =COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'PRECISION')
        ,Scale			=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'Scale')
        ,IsIdentity		=COLUMNPROPERTY(OBJECT_ID(I.TABLE_NAME),COLUMN_NAME,'IsIdentity')
        ,IsPrimaryKey	=ISNULL((SELECT 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE inner join sys.objects on CONSTRAINT_NAME=name where type='PK' and SCHEMA_Name(schema_id)=I.TABLE_SCHEMA and TABLE_NAME=I.TABLE_NAME AND COLUMN_NAME=I.COLUMN_NAME),0)
        ,IsForeignKey	=ISNULL((SELECT TOP 1 1 FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE inner join sys.objects on CONSTRAINT_NAME=name where type='F' and SCHEMA_Name(schema_id)=I.TABLE_SCHEMA and TABLE_NAME=I.TABLE_NAME AND COLUMN_NAME=I.COLUMN_NAME),0)
        ,IsNullable		=(case when IS_NULLABLE='Yes' then 1 else 0 end )
        ,DefaultValue	=COLUMN_DEFAULT
        ,Description	=(select value from sys.extended_properties P where class=1 and  OBJECT_ID(TABLE_NAME)=P.major_id and COLUMN_NAME=COL_NAME(P.major_id,P.minor_id) and name='MS_Description')
        ,[CollationName]=COLLATION_NAME
from INFORMATION_SCHEMA.COLUMNS as I 
where TABLE_NAME=@TableName and TABLE_SCHEMA=@TableSchema
order by  ColumnID asc
";
        #endregion

        #region ReadDataTableSql 表
        /// <summary>
        /// 查看表的信息
        /// </summary>
        public const string ReadDataTableSql = @"
USE [{0}]
select T.Name,
	   SCHEMA_NAME(schema_id) [Schema],
	   I.Rows ,
	   I.Rowcnt,
	   Create_Date CreateDate,
	   modify_date ModifyDate
from    sys.tables  T
left join sys.sysindexes I on T.object_id=I.id
where indid<2
Order By [Schema] ASC,[Name] ASC
"; 
        #endregion
        #endregion

        #region  Sql Script String

        private const string DataSourceInformation = "DataSourceInformation";

        #region Lau ReadViewColumnSqlScript 视图列
        private const string ReadViewColumnSqlScript = @"
USE [{0}]
select  ObjectID		=M.object_id		
		,ColumnID		=column_id
		,Name			=M.Name
		,DataType		=TYPE_NAME(system_type_id)
		,MaxLength	    =COLUMNPROPERTY(M.object_id,M.NAME,'PRECISION')
		,Scale			=COLUMNPROPERTY(M.OBJECT_ID,M.NAME,'Scale')
		,IsIdentity		=COLUMNPROPERTY(M.OBJECT_ID,M.NAME,'IsIdentity')
		,IsPrimaryKey	=0
        ,IsForeignKey	=0
        ,IsNullable		=is_nullable
        ,DefaultValue	=null
        ,Description	=null
        ,[CollationName]=COLLATION_NAME 
        ,V.type 
from sys.all_columns as M
	inner join sys.all_views as V on M.object_ID=V.object_id 
 where OBJECT_NAME(M.object_id)=@ViewName and SCHEMA_NAME(V.schema_id)=@ViewSchema
order by M.column_id 
";
        #endregion

        #region Lau ReadDataBaseSqlScript 数据库
        private const string ReadDataBaseSqlScript = @"
USE MASTER 
select Name,
	   suser_sname(owner_sid) Owner,
	   DATABASEPROPERTYEX(name,'Status') Status, 
	   collation_name CollationName,
	   create_date CreateDate 
from sys.databases  
WHERE
(CAST(case when name in ('master','model','msdb','tempdb') then 1 else 0 end AS bit)=@IsSysDataBase)
ORDER BY
Name ASC ";
        #endregion

        #region Lau ReadDataTableSqlScript 表
        private const string ReadDataTableSqlScript = @"
USE [{0}]
select Name,
	   SCHEMA_NAME(schema_id) [Schema],
	   Create_Date CreateDate,
	   modify_date ModifyDate
from    sys.tables 
where
(case when type='U' then 0 else 1 end)=@IsSysDataTable 
Order By [Schema] ASC,[Name] ASC";

        #endregion

        #region Lau ReadPrimaryKeySqlScript 主键
        private const string ReadPrimaryKeySqlScript = @"
USE [{0}]
SELECT Name
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
	inner join sys.objects on CONSTRAINT_NAME=name
where TABLE_SCHEMA=@tableSchema and TABLE_NAME=@tableName and type='PK'  
ORDER BY Name ASC";
        #endregion

        #region Lau ReadForeigneKeySqlScript 外键
        private const string ReadForeigneKeySqlScript = @"
USE [{0}]
SELECT Name
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
	inner join sys.objects on CONSTRAINT_NAME=name
where TABLE_SCHEMA=@tableSchema and TABLE_NAME=@tableName and type='F'  
ORDER BY Name ASC";
        #endregion

        #region Lau ReadConstraintSqlScript 约束
        private const string ReadConstraintSqlScript = @"
USE [{0}]
select  cstr.Name,
		cstr.create_date as CreateDate
from  sys.check_constraints as cstr
	inner join sys.tables as tb on cstr.parent_object_id=tb.object_id
Where SCHEMA_NAME(tb.schema_id)=@tableSchema and tb.name=@tableName
ORDER BY
[Name] ASC";
        #endregion

        #region  ReadDefaultConstraintSqlScript

        private const string ReadDefaultConstraintSqlScript = @"
USE [{0}]
SELECT
cstr.name AS [Name],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/Table[@Name=' + quotename(tbl.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(tbl.schema_id),'''') + ']' + '/Column[@Name=' + quotename(clmns.name,'''') + ']' + '/Default[@Name=' + quotename(cstr.name,'''') + ']' AS [Urn],
cstr.create_date AS [CreateDate]
FROM
sys.tables AS tbl
INNER JOIN sys.all_columns AS clmns ON clmns.object_id=tbl.object_id
INNER JOIN sys.default_constraints AS cstr ON cstr.object_id=clmns.default_object_id
WHERE
(tbl.name=@_msparam_0 and SCHEMA_NAME(tbl.schema_id)=@_msparam_1)
ORDER BY
[Name] ASC";

        #endregion

        #region Lau ReadTableIndexSchemaSqlScript 表索引
        private const string ReadTableIndexSchemaSqlScript = @"
USE [{0}]
select  i.Name 
		,is_unique [IsUnique]
		,CAST(CASE index_id WHEN 1 THEN 1 ELSE 0 END AS bit) AS [IsClustered] 
from sys.indexes i
	inner join sys.tables as tb on i.object_id=tb.object_id
Where SCHEMA_NAME(tb.schema_id)=@TableSchema and tb.name=@TableName
Order by [Name] ASC";
        #endregion

        #region Lau ReadDataViewSqlScript 视图
        private const string ReadDataViewSqlScript = @"
USE [{0}]
select Name
	   ,SCHEMA_NAME(schema_id) [Schema]
	   ,create_date CreateDate
	   ,modify_date ModifyDate 
from  sys.all_views
where is_ms_shipped=@IsSysDataTable
order by [SCHEMA_ID],[Name] ASC";
        #endregion

        #region Lau ReadTableTriggerSchemaSqlScript 表触发器
        private const string ReadTableTriggerSchemaSqlScript = @"
USE [{0}]
select  Name
		,create_date CreateDate
		,modify_date ModifyDate 
from sys.all_objects 
where type in ('TR','TA') 
	  and parent_object_id=object_id(@TableName)
	  and schema_id=schema_id(@TableSchema)
ORDER BY
[Name] ASC";
        #endregion

        #region  ReadViewTriggerSchemaSqlScript
        private const string ReadViewTriggerSchemaSqlScript = @"
USE [{0}]
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
SELECT
tr.name AS [Name],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/View[@Name=' + quotename(v.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(v.schema_id),'''') + ']' + '/Trigger[@Name=' + quotename(tr.name,'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server' + '/Database\[@ID=' + convert(nvarchar(20),dtb.database_id) + '\]' + '/View\[@ID=' + convert(nvarchar(20),v.object_id) + '\]'+ '/Trigger\[@ID=' + convert(nvarchar(20),tr.object_id) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState],
~trr.is_disabled AS [IsEnabled],
CAST(CASE WHEN ISNULL(smtr.definition, ssmtr.definition) IS NULL THEN 1 ELSE 0 END AS bit) AS [IsEncrypted]
FROM
master.sys.databases AS dtb,
sys.all_views AS v
INNER JOIN sys.objects AS tr ON (tr.type in (@_msparam_0, @_msparam_1)) AND (tr.parent_object_id=v.object_id)
LEFT OUTER JOIN sys.assembly_modules AS mod ON mod.object_id = tr.object_id
INNER JOIN sys.triggers AS trr ON trr.object_id = tr.object_id
LEFT OUTER JOIN sys.sql_modules AS smtr ON smtr.object_id = tr.object_id
LEFT OUTER JOIN sys.system_sql_modules AS ssmtr ON ssmtr.object_id = tr.object_id
WHERE
(v.type = @_msparam_2)and(v.name=@_msparam_3 and SCHEMA_NAME(v.schema_id)=@_msparam_4)and((db_name()=@_msparam_5)and(dtb.name=db_name()))
ORDER BY
[Name] ASC";
        #endregion

        #region  ReadViewIndexSchemaSqlScript
        private const string ReadViewIndexSchemaSqlScript = @"
USE [{0}]
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
SELECT
i.name AS [Name],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/View[@Name=' + quotename(v.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(v.schema_id),'''') + ']' + '/Index[@Name=' + quotename(i.name,'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server' + '/Database\[@ID=' + convert(nvarchar(20),dtb.database_id) + '\]' + '/View\[@ID=' + convert(nvarchar(20),v.object_id) + '\]'+ '/Index\[@ID=' + convert(nvarchar(20),CAST(i.index_id AS int)) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState],
CAST(CASE i.index_id WHEN 1 THEN 1 ELSE 0 END AS bit) AS [IsClustered],
i.is_unique AS [IsUnique],
CAST(case when i.type=3 then 1 else 0 end AS bit) AS [IsXmlIndex],
case UPPER(ISNULL(xi.secondary_type,'')) when 'P' then 1 when 'V' then 2 when 'R' then 3 else 0 end AS [SecondaryXmlIndexType],
CAST(case when i.type=4 then 1 else 0 end AS bit) AS [IsSpatialIndex],
i.has_filter AS [HasFilter]
FROM
master.sys.databases AS dtb,
sys.all_views AS v
INNER JOIN sys.indexes AS i ON (i.index_id > @_msparam_0 and i.is_hypothetical = @_msparam_1) AND (i.object_id=v.object_id)
LEFT OUTER JOIN sys.xml_indexes AS xi ON xi.object_id = i.object_id AND xi.index_id = i.index_id
WHERE
(v.type = @_msparam_2)and(v.name=@_msparam_3 and SCHEMA_NAME(v.schema_id)=@_msparam_4)and((db_name()=@_msparam_5)and(dtb.name=db_name()))
ORDER BY
[Name] ASC";
        #endregion

        #region Lau ReadProcedureSchemaSqlScript 存储过程
        private const string ReadProcedureSchemaSqlScript = @"
USE [{0}]
        select	Name
		,SCHEMA_NAME(schema_id) [Schema]
		,create_date CreateDate
		,modify_date ModifyDate	 
from sys.all_objects
where (type='p' or type='PC' or type='RF')
	   and is_ms_shipped=@isSysProcedure 
ORDER BY
[Schema] ASC,[Name] ASC";

        #endregion

        #region  Read表值FunctionSchemaSqlScript
        private const string Read表值FunctionSchemaSqlScript = @"
USE [{0}]
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
SELECT
udf.name AS [Name],
SCHEMA_NAME(udf.schema_id) AS [Schema],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/UserDefinedFunction[@Name=' + quotename(udf.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(udf.schema_id),'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server' + '/Database\[@ID=' + convert(nvarchar(20),dtb.database_id) + '\]'+ '/UserDefinedFunction\[@ID=' + convert(nvarchar(20),udf.object_id) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState],
udf.create_date AS [CreateDate],
ISNULL(sudf.name, N'') AS [Owner],
(case when 'FN' = udf.type then 1 when 'FS' = udf.type then 1 when 'IF' = udf.type then 3 when 'TF' = udf.type then 2 when 'FT' = udf.type then 2 else 0 end) AS [FunctionType]
FROM
master.sys.databases AS dtb,
sys.all_objects AS udf
LEFT OUTER JOIN sys.database_principals AS sudf ON sudf.principal_id = ISNULL(udf.principal_id, (OBJECTPROPERTY(udf.object_id, 'OwnerId')))
WHERE
(udf.type in ('TF', 'FN', 'IF', 'FS', 'FT'))and(((case when 'FN' = udf.type then 1 when 'FS' = udf.type then 1 when 'IF' = udf.type then 3 when 'TF' = udf.type then 2 when 'FT' = udf.type then 2 else 0 end)=@_msparam_0 or (case when 'FN' = udf.type then 1 when 'FS' = udf.type then 1 when 'IF' = udf.type then 3 when 'TF' = udf.type then 2 when 'FT' = udf.type then 2 else 0 end)=@_msparam_1) and CAST(
 case 
    when udf.is_ms_shipped = 1 then 1
    when (
        select 
            major_id 
        from 
            sys.extended_properties 
        where 
            major_id = udf.object_id and 
            minor_id = 0 and 
            class = 1 and 
            name = N'microsoft_database_tools_support') 
        is not null then 1
    else 0
end          
             AS bit)=@_msparam_2)and((db_name()=@_msparam_3)and(dtb.name=db_name()))
ORDER BY
[Schema] ASC,[Name] ASC";
        #endregion

        #region  Read标量值FunctionSchemaSqlScript
        private const string Read标量值FunctionSchemaSqlScript = @"
USE [{0}]
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
SELECT
udf.name AS [Name],
SCHEMA_NAME(udf.schema_id) AS [Schema],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/UserDefinedFunction[@Name=' + quotename(udf.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(udf.schema_id),'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server' + '/Database\[@ID=' + convert(nvarchar(20),dtb.database_id) + '\]'+ '/UserDefinedFunction\[@ID=' + convert(nvarchar(20),udf.object_id) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState],
udf.create_date AS [CreateDate],
ISNULL(sudf.name, N'') AS [Owner],
(case when 'FN' = udf.type then 1 when 'FS' = udf.type then 1 when 'IF' = udf.type then 3 when 'TF' = udf.type then 2 when 'FT' = udf.type then 2 else 0 end) AS [FunctionType]
FROM
master.sys.databases AS dtb,
sys.all_objects AS udf
LEFT OUTER JOIN sys.database_principals AS sudf ON sudf.principal_id = ISNULL(udf.principal_id, (OBJECTPROPERTY(udf.object_id, 'OwnerId')))
WHERE
(udf.type in ('TF', 'FN', 'IF', 'FS', 'FT'))and((case when 'FN' = udf.type then 1 when 'FS' = udf.type then 1 when 'IF' = udf.type then 3 when 'TF' = udf.type then 2 when 'FT' = udf.type then 2 else 0 end)=@_msparam_0 and CAST(
 case 
    when udf.is_ms_shipped = 1 then 1
    when (
        select 
            major_id 
        from 
            sys.extended_properties 
        where 
            major_id = udf.object_id and 
            minor_id = 0 and 
            class = 1 and 
            name = N'microsoft_database_tools_support') 
        is not null then 1
    else 0
end          
             AS bit)=@_msparam_1)and((db_name()=@_msparam_2)and(dtb.name=db_name()))
ORDER BY
[Schema] ASC,[Name] ASC";
        #endregion

        #region  Read聚合FunctionSchemaSqlScript
        private const string Read聚合FunctionSchemaSqlScript = @"
USE [{0}]
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
      


SELECT
obj.name AS [Name],
SCHEMA_NAME(obj.schema_id) AS [Schema],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Database[@Name=' + quotename(db_name(),'''') + ']' + '/UserDefinedAggregate[@Name=' + quotename(obj.name,'''') + ' and @Schema=' + quotename(SCHEMA_NAME(obj.schema_id),'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server' + '/Database\[@ID=' + convert(nvarchar(20),dtb.database_id) + '\]'+ '/UserDefinedAggregate\[@ID=' + convert(nvarchar(20),obj.object_id) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState]
FROM
master.sys.databases AS dtb,
sys.objects AS obj
WHERE
(obj.type=N'AF')and((db_name()=@_msparam_0)and(dtb.name=db_name()))
ORDER BY
[Schema] ASC,[Name] ASC";
        #endregion

        #region Lau ReadDataBaseTriggerSchemaSqlScript 数据库触发器
        private const string ReadDataBaseTriggerSchemaSqlScript = @"
USE [{0}]
select  Name
		,create_date CreateDate
		,modify_date ModifyDate 
from sys.triggers 
where parent_class=0
ORDER BY
[Name] ASC";
        #endregion

        #region  ReadUserSchemaSqlScript
        private const string ReadUserSchemaSqlScript = @"
        DECLARE @is_policy_automation_enabled bit
        SET @is_policy_automation_enabled  = (SELECT CONVERT(bit, current_value)
                                              FROM msdb.dbo.syspolicy_configuration
                                              WHERE name = 'Enabled')
      


SELECT
log.name AS [Name],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Login[@Name=' + quotename(log.name,'''') + ']' AS [Urn],
case when 1=@is_policy_automation_enabled and exists (select * from msdb.dbo.syspolicy_system_health_state where target_query_expression_with_id like 'Server'+ '/Login\[@ID=' + convert(nvarchar(20),log.principal_id) + '\]%' ESCAPE '\') then 1 else 0 end AS [PolicyHealthState],
log.create_date AS [CreateDate],
CASE WHEN N'U' = log.type THEN 0 WHEN N'G' = log.type THEN 1 WHEN N'S' = log.type THEN 2 WHEN N'C' = log.type THEN 3 WHEN N'K' = log.type THEN 4 END AS [LoginType],
log.is_disabled AS [IsDisabled]
FROM
sys.server_principals AS log
WHERE
(log.type in ('U', 'G', 'S', 'C', 'K') AND log.principal_id not between 101 and 255 AND log.name <> N'##MS_AgentSigningCertificate##')
ORDER BY
[Name] ASC";
        #endregion

        #region  ReadRoleSchemaSqlScript
        private const string ReadRoleSchemaSqlScript = @"
SELECT
r.name AS [Name],
'Server[@Name=' + quotename(CAST(
        serverproperty(N'Servername')
       AS sysname),'''') + ']' + '/Role[@Name=' + quotename(r.name,'''') + ']' AS [Urn]
FROM
sys.server_principals r
WHERE
(
				r.type ='R'
			)
ORDER BY
[Name] ASC";
        #endregion

        #region Lau ReadProcedureParameterSchemaSqlScript 存储过程参数
        private const string ReadProcedureParameterSchemaSqlScript = @"
USE [{0}]
select  params.Name
		,TYPE_NAME(user_type_id) DataType
		,CAST(CASE WHEN TYPE_NAME(user_type_id) IN (N'nchar', N'nvarchar') AND params.max_length <> -1 THEN params.max_length/2 ELSE params.max_length END AS int) AS [Length]
		,params.precision AS NumericPrecision
		,params.scale AS NumericScale
		,params.default_value AS DefaultValue
		,params.is_output AS IsOutputParameter 
		,params.is_cursor_ref AS IsCursorParameter 
from sys.all_parameters params
	inner join sys.objects obj on params.object_id=obj.object_id
WHERE (obj.type = 'P' OR obj.type = 'RF' OR obj.type='PC')
	and obj.name=@procedureName
ORDER BY
params.parameter_id ASC";
        #endregion

        #region Lau ReadFunctionParameterSchemaSqlScript 函数参数
        private const string ReadFunctionParameterSchemaSqlScript = @"
USE [{0}]
select  params.Name
		,TYPE_NAME(user_type_id) DataType
		,CAST(CASE WHEN TYPE_NAME(user_type_id) IN (N'nchar', N'nvarchar') AND params.max_length <> -1 THEN params.max_length/2 ELSE params.max_length END AS int) AS [Length]
		,params.precision AS NumericPrecision
		,params.scale AS NumericScale
		,params.default_value AS DefaultValue
		,params.is_output AS IsOutputParameter 
		,params.is_cursor_ref AS IsCursorParameter 
from sys.all_parameters params
	inner join sys.objects obj on params.object_id=obj.object_id
WHERE obj.type in ('TF', 'FN', 'IF', 'FS', 'FT')
	and obj.name=@@procedureName
ORDER BY
params.parameter_id ASC";
        #endregion

        #endregion

        public static DataBaseSchemaCollection ReadDataBaseSchema(string connString)
        {
            return ReadDataBaseSchema(connString, ReadDataBaseSqlScript, false);
        }
        public static DataBaseSchemaCollection ReadSysDataBaseSchema(string connString)
        {
            return ReadDataBaseSchema(connString, ReadDataBaseSqlScript, true);
        }

        public static TableSchemaCollection ReadTableSchema(string connString, string dataBaseName)
        {
            return ReadTableSchema(connString, ReadDataTableSqlScript, dataBaseName, false);
        }
        public static TableSchemaCollection ReadSysTableSchema(string connString, string dataBaseName)
        {
            return ReadTableSchema(connString, ReadDataTableSqlScript, dataBaseName, true);
        }

        public static ColumnSchemaCollection ReadTableColumnSchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            try
            {
                string sqlScript = string.Format(ReadColumnSqlScript, dataBaseName);
                DBHelper.SqlHelper.SqlConnectionString = connString;
                SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
                using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
                {
                    ColumnSchemaCollection collection = new ColumnSchemaCollection();
                    while (reader.Read())
                    {
                        ColumnSchema schema = new ColumnSchema();
                        schema.ObjectID = TypeHelper.ToInt(reader["ObjectID"], 0);
                        schema.ColumnID = TypeHelper.ToInt(reader["ColumnID"], 0);
                        schema.Name = TypeHelper.ToString(reader["Name"]);
                        schema.IsIdentity = TypeHelper.ToBoolean(reader["IsIdentity"]);
                        schema.IsNullable = TypeHelper.ToBoolean(reader["IsNullable"]);
                        schema.IsPrimaryKey = TypeHelper.ToBoolean(reader["IsPrimaryKey"]);
                        schema.IsForeignKey = TypeHelper.ToBoolean(reader["IsForeignKey"]);
                        schema.DataType = TypeHelper.ToString(reader["DataType"]);
                        schema.MaxLength = TypeHelper.ToInt16(reader["MaxLength"], 0);
                        schema.Scale = TypeHelper.ToInt16(reader["Scale"], 0);
                        schema.DefaultValue = TypeHelper.ToString(reader["DefaultValue"]);
                        schema.Description = TypeHelper.ToString(reader["Description"]);
                        schema.CollationName = TypeHelper.ToString(reader["CollationName"]);
                        schema.FullDataType = TypeHelper.DataTypeToFullDataType(schema.DataType, schema.MaxLength, schema.Scale);
                        collection.Add(schema);
                    }
                    return collection;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static KeySchemaCollection ReadPrimaryKeySchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadPrimaryKeySqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                KeySchemaCollection collection = new KeySchemaCollection();
                while (reader.Read())
                {
                    KeySchema schema = new KeySchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.KeyType = KeyType.Primary;
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static KeySchemaCollection ReadForeigneKeySchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadForeigneKeySqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                KeySchemaCollection collection = new KeySchemaCollection();
                while (reader.Read())
                {
                    KeySchema schema = new KeySchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.KeyType = KeyType.Foreigne;
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static ConstraintSchemaCollection ReadConstraintSchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadConstraintSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ConstraintSchemaCollection collection = new ConstraintSchemaCollection();
                while (reader.Read())
                {
                    ConstraintSchema schema = new ConstraintSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static ConstraintSchemaCollection ReadDefaultConstraintSchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadDefaultConstraintSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@_msparam_0", tableName) ,
                  new SqlParameter("@_msparam_1", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ConstraintSchemaCollection collection = new ConstraintSchemaCollection();
                while (reader.Read())
                {
                    ConstraintSchema schema = new ConstraintSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["CreateDate"] = reader["CreateDate"];
                    //schema.Properties["IsDefault"] = true;
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static IndexSchemaCollection ReadTableIndexSchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadTableIndexSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                IndexSchemaCollection collection = new IndexSchemaCollection();
                while (reader.Read())
                {
                    IndexSchema schema = new IndexSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.IsClustered = TypeHelper.ToBoolean(reader["IsClustered"]);
                    schema.IsUnique = TypeHelper.ToBoolean(reader["IsUnique"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static TriggerSchemaCollection ReadTableTriggerSchema(string connString, string dataBaseName, string tableName, string tableSchema = "dbo")
        {
            string sqlScript = string.Format(ReadTableTriggerSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@TableName", tableName) ,
                  new SqlParameter("@TableSchema", tableSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                TriggerSchemaCollection collection = new TriggerSchemaCollection();
                while (reader.Read())
                {
                    TriggerSchema schema = new TriggerSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ModifyDate = TypeHelper.ToDateTime(reader["ModifyDate"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static TriggerSchemaCollection ReadViewTriggerSchema(string connString, string dataBaseName, string viewName, string viewSchema = "dbo")
        {
            string sqlScript = string.Format(ReadViewTriggerSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@_msparam_0", "TR") ,
                  new SqlParameter("@_msparam_1", "TA"),
                  new SqlParameter("@_msparam_2", "V"),
                  new SqlParameter("@_msparam_3", System.Data.SqlDbType.NVarChar) { Value = viewName },
                  new SqlParameter("@_msparam_4", System.Data.SqlDbType.NVarChar) { Value = viewSchema },
                  new SqlParameter("@_msparam_5", System.Data.SqlDbType.NVarChar) { Value = dataBaseName }
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                TriggerSchemaCollection collection = new TriggerSchemaCollection();
                while (reader.Read())
                {
                    TriggerSchema schema = new TriggerSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    //schema.Properties["IsEnabled"] = reader["IsEnabled"];
                    //schema.Properties["IsEncrypted"] = reader["IsEncrypted"];
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static IndexSchemaCollection ReadViewIndexSchema(string connString, string dataBaseName, string viewName, string viewSchema = "dbo")
        {
            string sqlScript = string.Format(ReadViewIndexSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                 new SqlParameter("@_msparam_0", System.Data.SqlDbType.Int) { Value = 0 } ,
                  new SqlParameter("@_msparam_1", System.Data.SqlDbType.Bit) { Value = 0 },
                  new SqlParameter("@_msparam_2", "V"),
                  new SqlParameter("@_msparam_3", System.Data.SqlDbType.NVarChar) { Value = viewName },
                  new SqlParameter("@_msparam_4", System.Data.SqlDbType.NVarChar) { Value = viewSchema },
                  new SqlParameter("@_msparam_5", System.Data.SqlDbType.NVarChar) { Value = dataBaseName }
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                IndexSchemaCollection collection = new IndexSchemaCollection();
                while (reader.Read())
                {
                    IndexSchema schema = new IndexSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.IsClustered = Tools.ToBoolean(reader["IsClustered"]);
                    //schema.IsUnique = Tools.ToBoolean(reader["IsUnique"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    //schema.Properties["IsClustered"] = reader["IsClustered"];
                    //schema.Properties["IsUnique"] = reader["IsUnique"];
                    //schema.Properties["IsXmlIndex"] = reader["IsXmlIndex"];
                    //schema.Properties["SecondaryXmlIndexType"] = reader["SecondaryXmlIndexType"];
                    //schema.Properties["IsSpatialIndex"] = reader["IsSpatialIndex"];
                    //schema.Properties["HasFilter"] = reader["HasFilter"];
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static ViewSchemaCollection ReadViewSchema(string connString, string dataBaseName)
        {
            return ReadViewSchema(connString, ReadDataViewSqlScript, dataBaseName, false);
        }
        public static ViewSchemaCollection ReadSysViewSchema(string connString, string dataBaseName)
        {
            return ReadViewSchema(connString, ReadDataViewSqlScript, dataBaseName, true);
        }

        public static ColumnSchemaCollection ReadViewColumnSchema(string connString, string dataBaseName, string viewName, string viewSchema = "dbo")
        {
            string sqlScript = string.Format(ReadViewColumnSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@ViewName", viewName) ,
                  new SqlParameter("@ViewSchema", viewSchema)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ColumnSchemaCollection collection = new ColumnSchemaCollection();
                while (reader.Read())
                {
                    ColumnSchema schema = new ColumnSchema();
                    schema.ObjectID = TypeHelper.ToInt(reader["ObjectID"], 0);
                    schema.ColumnID = TypeHelper.ToInt(reader["ColumnID"], 0);
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.IsIdentity = TypeHelper.ToBoolean(reader["IsIdentity"]);
                    schema.IsNullable = TypeHelper.ToBoolean(reader["IsNullable"]);
                    schema.IsPrimaryKey = TypeHelper.ToBoolean(reader["IsPrimaryKey"]);
                    schema.IsForeignKey = TypeHelper.ToBoolean(reader["IsForeignKey"]);
                    schema.DataType = TypeHelper.ToString(reader["DataType"]);
                    schema.MaxLength = TypeHelper.ToInt16(reader["MaxLength"], 0);
                    schema.Scale = TypeHelper.ToInt16(reader["Scale"], 0);
                    schema.DefaultValue = TypeHelper.ToString(reader["DefaultValue"]);
                    schema.Description = TypeHelper.ToString(reader["Description"]);
                    schema.CollationName = TypeHelper.ToString(reader["CollationName"]);
                    schema.FullDataType = TypeHelper.DataTypeToFullDataType(schema.DataType, schema.MaxLength, schema.Scale);
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static ProcedureSchemaCollection ReadProcedureSchema(string connString, string dataBaseName)
        {
            return ReadProcedureSchema(connString, dataBaseName, false);
        }
        public static ProcedureSchemaCollection ReadSysProcedureSchema(string connString, string dataBaseName)
        {
            return ReadProcedureSchema(connString, dataBaseName, true);
        }

        public static FunctionSchemaCollection Read表值FunctionSchema(string connString, string dataBaseName)
        {
            string sqlScript = string.Format(Read表值FunctionSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@_msparam_0", "3") ,
                  new SqlParameter("@_msparam_1", "2"),
                  new SqlParameter("@_msparam_2", "0"),
                  new SqlParameter("@_msparam_3", dataBaseName)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                FunctionSchemaCollection collection = new FunctionSchemaCollection();
                while (reader.Read())
                {
                    FunctionSchema schema = new FunctionSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Schema"] = reader["Schema"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    //schema.Properties["CreateDate"] = reader["CreateDate"];
                    //schema.Properties["Owner"] = reader["Owner"];
                    //schema.Properties["FunctionType"] = reader["FunctionType"];
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static FunctionSchemaCollection Read标量值FunctionSchema(string connString, string dataBaseName)
        {
            string sqlScript = string.Format(Read标量值FunctionSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@_msparam_0", "1") ,
                  new SqlParameter("@_msparam_1", "0"), 
                  new SqlParameter("@_msparam_2", dataBaseName)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                FunctionSchemaCollection collection = new FunctionSchemaCollection();
                while (reader.Read())
                {
                    FunctionSchema schema = new FunctionSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Schema"] = reader["Schema"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    //schema.Properties["CreateDate"] = reader["CreateDate"];
                    //schema.Properties["Owner"] = reader["Owner"];
                    //schema.Properties["FunctionType"] = reader["FunctionType"];
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static FunctionSchemaCollection Read聚合FunctionSchema(string connString, string dataBaseName)
        {
            string sqlScript = string.Format(Read聚合FunctionSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                {  
                  new SqlParameter("@_msparam_0", dataBaseName)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                FunctionSchemaCollection collection = new FunctionSchemaCollection();
                while (reader.Read())
                {
                    FunctionSchema schema = new FunctionSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Schema"] = reader["Schema"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static TriggerSchemaCollection ReadDataBaseTriggerSchema(string connString, string dataBaseName)
        {
            string sqlScript = string.Format(ReadDataBaseTriggerSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript))
            {
                TriggerSchemaCollection collection = new TriggerSchemaCollection();
                while (reader.Read())
                {
                    TriggerSchema schema = new TriggerSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ModifyDate = TypeHelper.ToDateTime(reader["ModifyDate"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static UserSchemaCollection ReadUserSchema(string connString)
        {
            const string sqlScript = ReadUserSchemaSqlScript;
            DBHelper.SqlHelper.SqlConnectionString = connString;
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript))
            {
                UserSchemaCollection collection = new UserSchemaCollection();
                while (reader.Read())
                {
                    UserSchema schema = new UserSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    //schema.Properties["PolicyHealthState"] = reader["PolicyHealthState"];
                    //schema.Properties["CreateDate"] = reader["CreateDate"];
                    //schema.Properties["LoginType"] = reader["LoginType"];
                    //schema.Properties["IsDisabled"] = reader["IsDisabled"];
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static RoleSchemaCollection ReadRoleSchema(string connString)
        {
            const string sqlScript = ReadRoleSchemaSqlScript;
            DBHelper.SqlHelper.SqlConnectionString = connString;
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript))
            {
                RoleSchemaCollection collection = new RoleSchemaCollection();
                while (reader.Read())
                {
                    RoleSchema schema = new RoleSchema();
                    //schema.Name = Tools.ToString(reader["Name"]);
                    //schema.Properties["Name"] = reader["Name"];
                    //schema.Properties["Urn"] = reader["Urn"];
                    collection.Add(schema);
                }
                return collection;
            }
        }

        private static DataBaseSchemaCollection ReadDataBaseSchema(string connString, string sqlScript, bool isSysDataBase)
        {
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@IsSysDataBase", isSysDataBase ? 1 : 0)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                DataBaseSchemaCollection collection = new DataBaseSchemaCollection();
                while (reader.Read())
                {
                    DataBaseSchema schema = new DataBaseSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.Owner = TypeHelper.ToString(reader["Owner"]);
                    schema.Status = TypeHelper.ToString(reader["Status"]);
                    schema.CollationName = TypeHelper.ToString(reader["CollationName"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ConnectionString = connString;
                    collection.Add(schema);
                }
                return collection;
            }
        }
        private static TableSchemaCollection ReadTableSchema(string connString, string sqlScript, string dataBaseName, bool isSysDataTable)
        {
            sqlScript = string.Format(sqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@IsSysDataTable", SqlDbType.Bit) { Value = isSysDataTable ? 1 : 0 }
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                TableSchemaCollection collection = new TableSchemaCollection();
                while (reader.Read())
                {
                    TableSchema schema = new TableSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.Schema = TypeHelper.ToString(reader["Schema"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ModifyDate = TypeHelper.ToDateTime(reader["ModifyDate"]);
                    schema.Columns = ReadTableColumnSchema(connString, dataBaseName, schema.Name, schema.Schema);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        private static ViewSchemaCollection ReadViewSchema(string connString, string sqlScript, string dataBaseName, bool isSysDataTable)
        {
            sqlScript = string.Format(sqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@IsSysDataTable", SqlDbType.Bit) { Value = isSysDataTable ? 1 : 0 }
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ViewSchemaCollection collection = new ViewSchemaCollection();
                while (reader.Read())
                {
                    ViewSchema schema = new ViewSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.Schema = TypeHelper.ToString(reader["Schema"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ModifyDate = TypeHelper.ToDateTime(reader["ModifyDate"]);
                    schema.Columns = ReadViewColumnSchema(connString, dataBaseName, schema.Name, schema.Schema);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        private static ProcedureSchemaCollection ReadProcedureSchema(string connString, string dataBaseName, bool isSysProcedure)
        {
            string sqlScript = string.Format(ReadProcedureSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                  new SqlParameter("@isSysProcedure", (isSysProcedure ? "1" : "0"))
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ProcedureSchemaCollection collection = new ProcedureSchemaCollection();
                while (reader.Read())
                {
                    ProcedureSchema schema = new ProcedureSchema();
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.Schema = TypeHelper.ToString(reader["Schema"]);
                    schema.CreateDate = TypeHelper.ToDateTime(reader["CreateDate"]);
                    schema.ModifyDate = TypeHelper.ToDateTime(reader["ModifyDate"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static ParameterSchemaCollection ReadProcedureParameterSchema(string connString, string dataBaseName, string procedureName)
        {
            string sqlScript = string.Format(ReadProcedureParameterSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                 new SqlParameter("@procedureName", procedureName)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ParameterSchemaCollection collection = new ParameterSchemaCollection();
                while (reader.Read())
                {
                    ParameterSchema schema = new ParameterSchema();
                    schema.ParameterType = TypeHelper.ToBoolean(reader["IsOutputParameter"]) ? ParameterType.Out : ParameterType.In;
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.DataType = TypeHelper.ToString(reader["DataType"]);
                    schema.Length = TypeHelper.ToInt16(reader["Length"], 0);
                    schema.NumericPrecision = TypeHelper.ToInt16(reader["NumericPrecision"], 0);
                    schema.NumericScale = TypeHelper.ToInt16(reader["NumericScale"], 0);
                    schema.DefaultValue = TypeHelper.ToString(reader["DefaultValue"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }
        public static ParameterSchemaCollection ReadFunctionParameterSchema(string connString, string dataBaseName, string functionName)
        {
            string sqlScript = string.Format(ReadFunctionParameterSchemaSqlScript, dataBaseName);
            DBHelper.SqlHelper.SqlConnectionString = connString;
            SqlParameter[] sqlParams = new SqlParameter[]               
                { 
                new SqlParameter("@functionName", functionName)
                 };
            using (IDataReader reader = DBHelper.SqlHelper.ExecuteDataReader(sqlScript, sqlParams))
            {
                ParameterSchemaCollection collection = new ParameterSchemaCollection();
                while (reader.Read())
                {
                    ParameterSchema schema = new ParameterSchema();
                    schema.ParameterType = TypeHelper.ToBoolean(reader["IsOutputParameter"]) ? ParameterType.Out : ParameterType.In;
                    schema.Name = TypeHelper.ToString(reader["Name"]);
                    schema.DataType = TypeHelper.ToString(reader["DataType"]);
                    schema.Length = TypeHelper.ToInt16(reader["Length"], 0);
                    schema.NumericPrecision = TypeHelper.ToInt16(reader["NumericPrecision"], 0);
                    schema.NumericScale = TypeHelper.ToInt16(reader["NumericScale"], 0);
                    schema.DefaultValue = TypeHelper.ToString(reader["DefaultValue"]);
                    collection.Add(schema);
                }
                return collection;
            }
        }

        public static DataTable GetSchemaDataTableByCollectionName(string connString)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                DataTable dataTable = conn.GetSchema("DataSourceInformation");
                return dataTable;
            }
        }
    }
}
