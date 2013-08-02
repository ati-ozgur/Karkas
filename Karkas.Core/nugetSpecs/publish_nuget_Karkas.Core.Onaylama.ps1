$projectName = "Karkas.Core.Onaylama"
$version = Get-Content karkas.core.version.txt
$nugetCacheFolder = "$Home/AppData/Local/NuGet/Cache"
$nugetPackageName = "$projectName.$version.nupkg"

../packages/NuGet.CommandLine.2.5.0/tools/NuGet push   $nugetCacheFolder/$nugetPackageName 

write-host "pushed $nugetPackageName"
