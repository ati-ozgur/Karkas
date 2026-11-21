#!/bin/bash

# One SQLite database file per tenant: generate code from one Chinook file,
# copy it into several tenant files and check that tenants stay isolated.

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
# The -e option will cause a bash script to exit immediately when a command fails.
# The -u option causes the bash shell to treat unset variables as an error and exit immediately.
# The -x option causes bash to print each command before executing it.
# The -o pipefail option sets the exit code of a pipeline to
# that of the rightmost command to exit with a non-zero status.

set -euxo pipefail

export current_script_directory=$(dirname "$0")
echo "The script you are running has:"
echo "basename: [$(basename "$0")]"
echo "dirname : [$current_script_directory]"
echo "pwd     : [$(pwd)]"

cd "$current_script_directory/../.."


rm -rf Karkas.Examples/GeneratedProjects/ChinookSqliteMultiTenant
dotnet run --project Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp -- --connectionname ChinookSqliteMultiTenant
cd Karkas.Examples/GeneratedProjects/ChinookSqliteMultiTenant
dotnet new console
# Optional: test a specific target framework of the multi-targeted Karkas.Data libraries
if [ -n "${KARKAS_TEST_FRAMEWORK:-}" ]; then
    sed -i -E "s#<TargetFramework>[^<]+</TargetFramework>#<TargetFramework>${KARKAS_TEST_FRAMEWORK}</TargetFramework>#" ./*.csproj
fi
# Microsoft.Data.Sqlite comes transitively from Karkas.Data.Sqlite
dotnet add reference "../../../Karkas.Data/Karkas.Data/Karkas.Data.csproj"
dotnet add reference "../../../Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj"

cp ../../TestCSharp/Programs/ProgramChinookMultiTenant.cs Program.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsings.cs GlobalUsings.cs
cp ../../TestCSharp/GlobalUsings/GlobalUsingsChinook.cs GlobalUsingsChinook.cs

cp ../../TestCSharp/HelpersTest/TestHelperChinookMultiTenant.cs .
# provides the Microsoft.Data.Sqlite / Karkas.Data.Sqlite global usings
cp ../../TestCSharp/HelpersConnection/ConnectionHelperSqliteChinook.cs ConnectionHelper.cs
cp --recursive ../../TestCSharp/Bs/Karkas.Examples.Chinook.Bs .
cp --recursive ../../TestCSharp/Dal/Karkas.Examples.Chinook.Dal .

# tenant databases: same schema, one file each (the Guid tenant is lower-case "D" format)
# (the test uses the relative pattern "tenants/{tenant}.sqlite", resolved against this directory)
mkdir -p tenants
for tenant in acme globex 3f2504e0-4f89-41d3-9a0c-0305e82c3301; do
    cp ../../Databases/Chinook-auto-increment.sqlite "tenants/$tenant.sqlite"
done
dotnet build
dotnet run
