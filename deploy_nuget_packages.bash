source <(grep = version.txt)

echo "KarkasDataVersion: $KarkasDataVersion"
echo "KarkasCodeGenVersion: $KarkasCodeGenVersion"

echo "KARKAS_NUGET_API_KEY: $KARKAS_NUGET_API_KEY"

dotnet pack Karkas.Data/Karkas.Data/Karkas.Data.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.Oracle/Karkas.Data.Oracle.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj /property:Version=$KarkasDataVersion
dotnet nuget push Karkas.Data/Karkas.Data/bin/Release/Karkas.Data.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.Sqlite/bin/Release/Karkas.Data.Sqlite.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.Oracle/bin/Release/Karkas.Data.Oracle.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
dotnet nuget push Karkas.Data/Karkas.Data.SqlServer/bin/Release/Karkas.Data.SqlServer.$KarkasDataVersion.nupkg --api-key $KARKAS_NUGET_API_KEY --source https://api.nuget.org/v3/index.json --skip-duplicate
