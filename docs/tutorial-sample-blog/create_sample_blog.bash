dotnet tool install --global Karkas.CodeGeneration.ConsoleApp
karkas-codegen
rm -rf sample-blog.sqlite
rm -rf GeneratedProjects
cat blog.sql | sqlite3 sample-blog.sqlite
karkas-codegen -c sample-blog -f karkas-config-sample-blog.json
cd ./GeneratedProjects/sample-blog
tree
dotnet new console
dotnet add package Karkas.Data
dotnet add package Karkas.Data.Sqlite
dotnet run
rm -rf bin/
rm -rf obj
