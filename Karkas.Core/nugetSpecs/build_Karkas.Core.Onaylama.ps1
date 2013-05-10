remove-item lib -recurse
mkdir lib
#mkdir tools
#mkdir content
msbuild   "..\Karkas.Core.2010.sln"
copy ../Karkas.Core.Validation/bin/Debug/Karkas.Core.Onaylama.dll lib
../packages/NuGet.CommandLine.2.5.0/tools/NuGet pack  Karkas.Core.Onaylama.nuspec

