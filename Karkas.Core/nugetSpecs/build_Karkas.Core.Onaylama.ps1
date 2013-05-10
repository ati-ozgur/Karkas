remove-item Karkas.Core.Onaylama/lib -recurse
mkdir Karkas.Core.Onaylama/lib
#mkdir tools
#mkdir content
msbuild   "..\Karkas.Core.2010.sln"
copy ../Karkas.Core.Validation/bin/Debug/Karkas.Core.Onaylama.dll Karkas.Core.Onaylama/lib
../packages/NuGet.CommandLine.2.5.0/tools/NuGet pack  Karkas.Core.Onaylama/Karkas.Core.Onaylama.nuspec

