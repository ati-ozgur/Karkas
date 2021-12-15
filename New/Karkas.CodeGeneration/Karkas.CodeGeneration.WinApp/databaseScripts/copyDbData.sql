INSERT INTO "main"."DatabaseEntry" SELECT 
ConnectionName  
,ConnectionDatabaseType  
,ConnectionDbProviderName  
,ConnectionString  
,DatabaseNamePhysical 
,DatabaseNameLogical 
,ProjectNameSpace  
,CodeGenerationDirectory  
,ViewCodeGenerate  
,StoredProcedureCodeGenerate  
, null --,SequenceCodeGenerate  
,UseSchemaNameInSqlQueries  
,UseSchemaNameInFolders  
,IgnoreSystemTables  
,IgnoredSchemaList  
,AbbrevationsAsString 
,CreationTime 
,LastAccessTime 
,LastWriteTime 

FROM "main"."temp"
