
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
		write-host Kod par�ac�klar�  $destination dizinine kopyaland�.
		write-host To uninstall snippets just remove $destination directory
		write-host Kald�rmak i�in $destination dizinini siliniz.

	}
}


write-host ==================================================================================
write-host 
write-host Snippets are available for every project in every solution!
write-host Kod par�ac�klar� bundan sonra a�aca��n�z her proje ve solution i�in ula��labilir olacakt�r.
write-host
write-host ==================================================================================



