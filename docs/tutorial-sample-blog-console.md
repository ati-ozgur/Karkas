# tutorial-sample-blog-console

1. Install karkas-codegen

```bash
dotnet tool install --global Karkas.CodeGeneration.ConsoleApp
```


2. Check it is installed correctly by running **karkas-codegen** in your shell, cmd or bash.

```bash
$ karkas-codegen
Karkas.CodeGeneration.ConsoleApp 1.0.3+eaac63ca88056d611bbe10f434fc9ebcc67aad00
Copyright (C) 2024 Karkas.CodeGeneration.ConsoleApp
ERROR(S):
Required option 'c, connectionname' is missing.
  -v, --verbose           Enable verbose output.
  -c, --connectionname    Required. Which connection name will be used in config.json
  -f, --configfilename    default configuration filename is karkas-config.json
  --help                  Display this help screen.
  --version               Display version information.   
```

3. Create following karkas-config.json file. You can [download](../Karkas.Examples/karkas-config-sample.json) it also. 


```json
[
    {
    "ConnectionName": "sample",
    "ConnectionDatabaseType": "sqlite",
    "ConnectionDbProviderName": "Microsoft.Data.Sqlite",
    "ConnectionString": "Data Source=Databases/sample.sqlite;Mode=ReadWrite;",
    "ProjectNameSpace": "Karkas.Examples.Sample",
    "CodeGenerationDirectory": "./GeneratedProjects/sample"
    }
]
```

Above attributes in karkas-config.json is obvious.
More information could be found in [docs](../docs/karkas-config.md).

4. ConnectionString attribute in karkas-config.json points to sqlite sample database with a Blog table. 
You can also [download this sqlite database](../Karkas.Examples/Databases/sample.sqlite).



5. run following command

```bash
karkas-codegen -c sample -f karkas-config-sample.json
```

6. You should see following output.

```bash
arguments ConfigFileName: karkas-config-sample.json, ConnectionName: sample
DatabaseEntry sample, sqlite, Data Source=Databases/sample.sqlite;Mode=ReadWrite;, ./GeneratedProjects/sample
sqlite
trying connection string Data Source=Databases/sample.sqlite;Mode=ReadWrite;
Successfully connected. Starting code generation in folder ./GeneratedProjects/sample
Code generation finished
Errors:   
```

Most important lines are following

> Successfully connected

This confirms that your database connection string works.

> Errors:

This confirms that there are no errors in code generation.

7. Goto CodeGenerationDirectory here, ./GeneratedProjects/sample

```bash
cd ./GeneratedProjects/sample
```

8. See generated files using tree command.

```bash
.
├── Bs
│   └── Karkas.Examples.Sample.Bs
│       ├── BlogBs.cs
│       └── BlogBs.generated.cs
├── Dal
│   └── Karkas.Examples.Sample.Dal
│       ├── BlogDal.cs
│       └── BlogDal.generated.cs
└── TypeLibrary
    └── Karkas.Examples.Sample.TypeLibrary
        ├── Blog.cs
        └── Blog.generated.cs

7 directories, 7 files
```

9. run dotnet new

```bash
dotnet new console
```

10. Add Karkas packages

```bash
dotnet add package Karkas.Data
dotnet add package Karkas.Data.Sqlite
```
