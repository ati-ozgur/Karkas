source <(grep = version.txt)

echo "KarkasDataVersion: $KarkasDataVersion"
echo "KarkasCodeGenVersion: $KarkasCodeGenVersion"

echo "KARKAS_NUGET_API_KEY: $KARKAS_NUGET_API_KEY"

dotnet pack Karkas.Data/Karkas.Data/Karkas.Data.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.Oracle/Karkas.Data.Oracle.csproj /property:Version=$KarkasDataVersion
dotnet pack Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj /property:Version=$KarkasDataVersion
