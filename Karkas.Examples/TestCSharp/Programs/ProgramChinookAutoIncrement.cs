﻿using System;
using System.Data.Common;
using Karkas.Data;

using Karkas.Examples;
using Karkas.Examples.Chinook.Bs;
using Karkas.Examples.Chinook.Dal;
using Karkas.Examples.Chinook.TypeLibrary;

ConnectionHelper.SetupDatabaseConnection();

TestHelper.TestQueryAll();


TestHelper.TestQueryUsingWrongColumnName();

TestHelper.TestQueryByForeignKey1();

TestHelper.TestInsertAlbum();

TestHelper.TestCrudCustomer();

TestHelper.TestTransactionWorks();

TestHelper.TestTransactionRollback();



TestHelper.TestTemplateTopRows();
TestHelper.TestTemplateOneRow();

TestHelper.TestQueryByColumnNameWhereOperators();
