rm -rf sample-blog.sqlite
rm -rf GeneratedProjects
cat blog.sql | sqlite3 sample-blog.sqlite
karkas-codegen -c sample -f karkas-config-sample-blog.json
cd ./GeneratedProjects/sample
tree
dotnet new console
dotnet add package Karkas.Data
dotnet add package Karkas.Data.Sqlite