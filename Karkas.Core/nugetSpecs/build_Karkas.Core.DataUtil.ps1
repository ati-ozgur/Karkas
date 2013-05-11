$projectName = "Karkas.Core.DataUtil"
$version = Get-Content version.txt
$nugetCacheFolder = "$Home/AppData/Local/NuGet/Cache"
$nugetPackageName = "$projectName.$version.nupkg"
remove-item $projectName/lib -recurse
mkdir $projectName/lib
#mkdir tools
#mkdir content
msbuild   "..\Karkas.Core.2010.sln"
copy ../$projectName/bin/Debug/$projectName.dll $projectName/lib
../packages/NuGet.CommandLine.2.5.0/tools/NuGet pack  $projectName/$projectName.nuspec -Version $version
move $nugetPackageName  $nugetCacheFolder -Force
write-host "moved $nugetPackageName to $nugetCacheFolder "
