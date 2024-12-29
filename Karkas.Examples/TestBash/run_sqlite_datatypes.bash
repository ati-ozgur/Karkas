#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.

set -euxo pipefail

rm -rf Karkas.Examples/GeneratedProjects/DataTypesSqlite
dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname DataTypesSqlite
cd Karkas.Examples/GeneratedProjects/DataTypesSqlite
dotnet new console
dotnet add package Microsoft.Data.Sqlite
dotnet add reference "../../../Karkas.Data/Karkas.Data/Karkas.Data.csproj"
dotnet add reference "../../../Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj"

cp ../../TestCSharp/Programs/ProgramDataTypesSqlite.cs Program.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsings.cs GlobalUsings.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsingsDataTypes.cs GlobalUsingsDataTypes.cs


cp --recursive ../../TestCSharp/Helpers/ .
cp ../../TestCSharp/HelpersConnection/ConnectionHelperSqliteDataTypes.cs ConnectionHelper.cs
#cp --recursive ../../TestCSharp/Bs/ .
#cp --recursive ../../TestCSharp/Dal/ .
cp ../../Databases/datatypes.sqlite DataTypes.sqlite
dotnet build
dotnet run

