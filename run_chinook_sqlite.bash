rm -rf Karkas.Examples/GeneratedProjects/ChinookSqlite
dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp ChinookSqlite
cd Karkas.Examples/GeneratedProjects/ChinookSqlite
dotnet new console
dotnet add package Microsoft.Data.Sqlite
dotnet add reference "../../../Karkas.Core/Karkas.Core.DataUtil/Karkas.Core.DataUtil.csproj"
dotnet add reference "../../../Karkas.Core/Karkas.Core.Data.Sqlite/Karkas.Core.Data.Sqlite.csproj"
cp ../../TestCodes/SqliteProgramChinook.cs Program.cs
cp ../../Chinook/Chinook.db Chinook.db
dotnet build
dotnet run

