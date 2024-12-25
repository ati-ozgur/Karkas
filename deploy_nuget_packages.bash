source <(grep = version.txt)

echo "KarkasDataVersion: $KarkasDataVersion"
echo "KarkasCodeGenVersion: $KarkasCodeGenVersion"

echo "KARKAS_NUGET_API_KEY: $KARKAS_NUGET_API_KEY"

dotnet pack Karkas.Data/Karkas.Data/Karkas.Data.csproj /property:Version=$KarkasDataVersion --include-symbols
dotnet pack Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj /property:Version=$KarkasDataVersion --include-symbols
dotnet pack Karkas.Data/Karkas.Data.Oracle/Karkas.Data.Oracle.csproj /property:Version=$KarkasDataVersion --include-symbols
dotnet pack Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj /property:Version=$KarkasDataVersion --include-symbols

dotnet pack Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp/Karkas.CodeGeneration.ConsoleApp.csproj /property:Version=$KarkasCodeGenVersion --include-symbols
echo "packing works"

dotnet nuget push Karkas.Data/Karkas.Data/nupkg/Karkas.Data.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.Sqlite/nupkg/Karkas.Data.Sqlite.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.Oracle/nupkg/Karkas.Data.Oracle.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.SqlServer/nupkg/Karkas.Data.SqlServer.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate

dotnet nuget push Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp/nupkg/Karkas.CodeGeneration.ConsoleApp.$KarkasCodeGenVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
