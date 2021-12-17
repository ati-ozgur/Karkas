
$snippetFolder = "Karkas"
$source = "./Karkas.Code.Snippets/tools/Snippets/*"
$vsVersions = @("2010","2012")
Foreach ($vsVersion in $vsVersions)
{
	$myCodeSnippetsFolder = "$HOME\Documents\Visual Studio $vsVersion\Code Snippets\Visual C#\My Code Snippets\"
	if (Test-Path $myCodeSnippetsFolder)
	{
		$destination = "$myCodeSnippetsFolder$snippetFolder"
		if (!(Test-Path $destination))
		{
		  New-Item $destination -itemType "directory"
		}

		write-host ========================================================================
		write-host Copying snippets to $destination
		write-host 

		Copy-Item $source -Destination $destination -Recurse -Force
		write-host Copying snippets to $destination
		write-host Kod parçacýklarý  $destination dizinine kopyalandý.
		write-host To uninstall snippets just remove $destination directory
		write-host Kaldýrmak için $destination dizinini siliniz.

	}
}


write-host ==================================================================================
write-host 
write-host Snippets are available for every project in every solution!
write-host Kod parçacýklarý bundan sonra açacaðýnýz her proje ve solution için ulaþýlabilir olacaktýr.
write-host
write-host ==================================================================================



