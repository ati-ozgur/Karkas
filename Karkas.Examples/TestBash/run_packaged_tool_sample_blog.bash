#!/bin/bash

# Tests the packaged artifacts users get from NuGet, without publishing anything:
# 1. packs Karkas.Data* and the karkas-codegen tool from this repository into a local NuGet feed
# 2. installs karkas-codegen from that feed
# 3. runs the sample-blog tutorial with it and builds/runs the generated code
#    against the Karkas.Data / Karkas.Data.Sqlite packages from the same feed
#
# Optional: KARKAS_TEST_FRAMEWORK=net8.0 (etc.) builds the generated project for that target framework.

# https://vaneyckt.io/posts/safer_bash_scripts_with_set_euxo_pipefail/
set -euxo pipefail

export current_script_directory=$(dirname "$0")
cd "$current_script_directory/../.."
REPO_ROOT=$(pwd)

WORK_DIR="$REPO_ROOT/Karkas.Examples/GeneratedProjects/PackagedToolSampleBlog"
FEED="$WORK_DIR/feed"
TOOLS="$WORK_DIR/tools"
APP="$WORK_DIR/app"
# A unique version every run, so NuGet's global package cache never serves an older local build
VERSION="0.0.0-local.$(date +%Y%m%d%H%M%S)"

rm -rf "$WORK_DIR"
mkdir -p "$FEED" "$TOOLS" "$APP"

for project in \
	Karkas.Data/Karkas.Data/Karkas.Data.csproj \
	Karkas.Data/Karkas.Data.Sqlite/Karkas.Data.Sqlite.csproj \
	Karkas.Data/Karkas.Data.SqlServer/Karkas.Data.SqlServer.csproj \
	Karkas.Data/Karkas.Data.Oracle/Karkas.Data.Oracle.csproj \
	Karkas.CodeGeneration/Karkas.CodeGeneration.ConsoleApp/Karkas.CodeGeneration.ConsoleApp.csproj
do
	dotnet pack "$project" -c Release -o "$FEED" /property:Version="$VERSION"
done

dotnet --list-runtimes
dotnet tool install Karkas.CodeGeneration.ConsoleApp --version "$VERSION" --add-source "$FEED" --tool-path "$TOOLS"
"$TOOLS/karkas-codegen" --version

cp docs/tutorial-sample-blog/blog.sql docs/tutorial-sample-blog/karkas-config-sample-blog.json "$APP/"
cd "$APP"
sqlite3 sample-blog.sqlite < blog.sql

"$TOOLS/karkas-codegen" -c sample-blog -f karkas-config-sample-blog.json

cd GeneratedProjects/sample-blog
dotnet new console
if [ -n "${KARKAS_TEST_FRAMEWORK:-}" ]; then
	sed -i -E "s#<TargetFramework>[^<]+</TargetFramework>#<TargetFramework>${KARKAS_TEST_FRAMEWORK}</TargetFramework>#" ./*.csproj
fi

cat > nuget.config <<EOF
<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="karkas-local" value="$FEED" />
    <add key="nuget.org" value="https://api.nuget.org/v3/index.json" />
  </packageSources>
</configuration>
EOF

dotnet add package Karkas.Data --version "$VERSION"
dotnet add package Karkas.Data.Sqlite --version "$VERSION"

cp "$REPO_ROOT/Karkas.Examples/TestCSharp/Programs/ProgramSampleBlogPackaged.cs" Program.cs
cp "$APP/sample-blog.sqlite" .

dotnet build
dotnet run
