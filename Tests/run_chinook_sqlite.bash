#!/bin/bash

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails. 
# The -u option causes the bash shell to treat unset variables as an error and exit immediately. 
# The -x option causes bash to print each command before executing it. 
# The -o pipefail option sets the exit code of a pipeline to 
# that of the rightmost command to exit with a non-zero status.

set -euxo pipefail

rm -rf Karkas.Examples/GeneratedProjects/ChinookSqlite
dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname ChinookSqlite
cd Karkas.Examples/GeneratedProjects/ChinookSqlite
dotnet new console
dotnet add package Microsoft.Data.Sqlite
dotnet add reference "../../../Karkas.Core/Karkas.Core.DataUtil/Karkas.Core.DataUtil.csproj"
dotnet add reference "../../../Karkas.Core/Karkas.Core.Data.Sqlite/Karkas.Core.Data.Sqlite.csproj"
cp ../../TestCodes/SqliteProgramChinook.cs Program.cs
cp --recursive ../../TestCodes/Helpers/ .
cp ../../TestCodes/HelpersConnection/ConnectionHelperSqlite.cs ConnectionHelper.cs
cp ../../Chinook/Chinook.db Chinook.db
dotnet build
dotnet run

