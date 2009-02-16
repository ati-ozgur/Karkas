

$strDosyaContent = ""

Get-ChildItem -Path . -include "*.cs"  -Recurse  | ForEach-Object {
	
	$strDosyaContent = ""
	
	$dosya = $_
    get-content -encoding String -path $_.FullName | ForEach-Object {
					
		$strDosyaContent = $strDosyaContent +  $_ + "`r`n"
		
    }
    
    Set-Content -encoding utf8 $dosya.FullName $strDosyaContent
}


Get-ChildItem -Path . -include "*.aspx"  -Recurse  | ForEach-Object {
	
	$strDosyaContent = ""
	
	$dosya = $_
    get-content -encoding String -path $_.FullName | ForEach-Object {
					
		$strDosyaContent = $strDosyaContent +  $_ + "`r`n"
		
    }
    
    Set-Content -encoding utf8 $dosya.FullName $strDosyaContent
}


Get-ChildItem -Path . -include "*.ascx"  -Recurse  | ForEach-Object {
	
	$strDosyaContent = ""
	
	$dosya = $_
    get-content -encoding String -path $_.FullName | ForEach-Object {
					
		$strDosyaContent = $strDosyaContent +  $_ + "`r`n"
		
    }
    
    Set-Content -encoding utf8 $dosya.FullName $strDosyaContent
}
