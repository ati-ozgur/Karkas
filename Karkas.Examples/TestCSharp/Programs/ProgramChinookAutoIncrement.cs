using System;
using System.Data.Common;
using Karkas.Data;

using Karkas.Examples;
using Karkas.Examples.Chinook.Bs;
using Karkas.Examples.Chinook.Dal;
using Karkas.Examples.Chinook.TypeLibrary;

ConnectionHelper.SetupDatabaseConnection();

// every query below runs with a "/* karkas:QueryId */" comment in front of its SQL,
// so the tagged SQL is checked on each database (see docs/query-tracing.md)
Karkas.Data.Tracing.KarkasTracing.TagMode = Karkas.Data.Tracing.QueryTagMode.QueryId;

TestHelper.TestGetOneRowGenericVersion();

TestHelper.TestQueryUsingColumnName_StringDateTimeColumns();
TestHelper.TestQueryUsingColumnName_TwoStringColumnsWithLike();
TestHelper.TestQueryUsingColumnName_TwoStringColumns();

TestHelper.TestQueryAll();
TestHelper.TestQueryAllOrderBy();


TestHelper.TestQueryUsingWrongColumnName();

TestHelper.TestQueryByForeignKey1();

TestHelper.TestInsertAlbum();

TestHelper.TestCrudCustomer();

TestHelper.TestTransactionWorks();

TestHelper.TestTransactionRollback();



TestHelper.TestTemplateTopRows();
TestHelper.TestTemplateOneRow();

TestHelper.TestQueryByColumnNameWhereOperators();

TestHelper.TestQueryTracing();
