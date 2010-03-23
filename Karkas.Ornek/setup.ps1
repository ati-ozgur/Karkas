$scope = "Development"
$ApplicationName = "KarkasOrnek"
$dbName = "KARKAS_ORNEK"

$global:SqlCmdCommandLine = ""



$expectedFile = "WebSite/ConnectionStrings$scope.config"

$dosya = dir $ExpectedFile 2>&1


if ($dosya.CategoryInfo.Category -eq "ObjectNotFound")
{
	$host.ui.writeline("Connection String bulunamadi. beklenen dosya = $expectedFile")
	exit;
}


function SetEnvironmentVariables()
{
	$Env:Path= $Env:PATH + "C:\Program Files\Microsoft.NET\SDK\v2.0\Bin;C:\WINDOWS\Microsoft.NET\Framework\v2.0.50727;C:\Program Files\Microsoft Visual Studio 8\VC\bin;C:\Program Files\Microsoft Visual Studio 8\Common7\IDE;C:\Program Files\Microsoft Visual Studio 8\VC\vcpackages;C:\Program Files\Microsoft SQL Server\90\Tools\Binn";
	$Env:LIB= $env:LIB + "C:\Program Files\Microsoft Visual Studio 8\VC\lib;C:\Program Files\Microsoft.NET\SDK\v2.0\Lib;"
	$Env:INCLUDE= $Env:INCLUDE + "C:\Program Files\Microsoft Visual Studio 8\VC\include;C:\Program Files\Microsoft.NET\SDK\v2.0\include;"
	$Env:NetSamplePath="C:\Program Files\Microsoft.NET\SDK\v2.0"
	echo "Setting environment to use Microsoft .NET Framework v2.0 SDK tools."
	echo "$ApplicationName Setup basliyor."

}

function Get-ConnectionString
([string]$PathToConfig=$(throw 'Configuration file is required'),
         [string]$Key = $(throw 'No Key Specified'))
{
    if (Test-Path $PathToConfig)
    {
        $x = [xml] (type $PathToConfig)
        $node = $x.connectionStrings.SelectSingleNode("add[@name='$Key']")
        return $node.connectionString
    }
} 



function executeSql([string]$sql=$(throw 'Sql gerekli'),
         [string]$ConnectionString = $(throw 'ConnectionString yok'))

{
	$conn = new-object System.Data.SqlClient.SqlConnection
	$conn.ConnectionString = $ConnectionString
	$conn.Open()
	
	
	$cmd = new-object System.Data.SqlClient.SqlCommand
	$cmd.Connection = $conn
	$cmd.CommandText =   $sql
	$cmd.ExecuteNonQuery()
	$conn.Close()

}

function executeSqlWithConnectionString
([string]$sql=$(throw 'Sql String is required'),
         [string]$ConnectionString = $(throw 'No Connection String Specified')
)
{
	$conn = new-object System.Data.SqlClient.SqlConnection
	$conn.ConnectionString = $ConnectionString
	$conn.Open()
	
	
	$cmd = new-object System.Data.SqlClient.SqlCommand
	$cmd.Connection = $conn
	$cmd.CommandText =   $sql
	trap 
		{
		"sql hatasý oluþtu: Çalýþan sql = $sql";
		"SISTEMDEN CIKIS";
		exit;
		} 
	$cmd.ExecuteNonQuery();
	$conn.Close()

}


function executeFileContentsViaSql
( $sqlFiles , $ConnectionString )
{

	foreach ($f in $sqlFiles) 
	{
		$host.ui.writeline("Çalýþtýrýlan Dosya : " + $f)
		$words = Get-Content $f
		
		$commandToExecute = ''
	
		foreach($word in $words)
		{
			if($word -eq $null)
      {
        Write-Warning "Dosyanin icerisi bos"
      }
			else
			{
        $trimmedWord = [string]$word.Trim()			
			
        if ($trimmedWord.Contains("--EkranaYaz"))
        {
          $trimmedWord
        }
        
        if (!$trimmedWord.Contains("GO --ExecuteThisSql"))
        {
          $CommandToExecute += "`n" + $word
        }
        else
        {
          $trimmedWord = [string]$CommandToExecute.Trim()
          
          if ($trimmedWord -ne "")
          {
            trap {"Hatalý Dosya = $f"} 
            . executeSqlWithConnectionString -sql $CommandToExecute -ConnectionString $ConnectionString;
          }
          $CommandToExecute = ""
        }
      }
		}
	}
}

function connectionStringDegerleriniAyir($str)
{
	$Liste = $str.Split(";")
	$son = ""

	foreach($l in $Liste)
	{
		if ($l.Contains("Initial Catalog"))
		{
			$db = $l.Split("=")
			$Database = $db[1]
		}
		if ($l.ToLowerInvariant().Contains("integrated security"))
		{
			$integrated = $l.Split("=")
			$IntegratedSecurity = $integrated[1]
			$son = " -E"
		}
		if ($l.ToLowerInvariant().Contains("data source"))
		{
			$ds = $l.Split("=")
			$DataServer = $ds[1]
		}
		
		if ($l.ToLowerInvariant().Contains("user id"))
		{
			$ud = $l.Split("=")
			$UserID = $ud[1]
		}
		if ($l.ToLowerInvariant().Contains("password"))
		{
			$pwd = $l.Split("=")
			$Password = $pwd[1]
			$son = " -U " + $UserID + " -P " + $Password
		}
		
		$global:SqlCmdCommandLine = " -S " + $DataServer + " -d " +  $Database + " " + $son
		
	}
}

function SqlDosyasiCalistir($dosyalar)
{
	foreach($dosya in $dosyalar)
	{
		$arg = "SqlCmd.exe" + $global:SqlCmdCommandLine + " -i " + $dosya.FullName
		
		invoke-expression $arg
		#$arg
	}
}


$ConnStr = Get-ConnectionString "$expectedFile" "Main"
$ConnStr

$ConnStrMaster = $ConnStr.Replace("Initial Catalog=$dbName;","Initial Catalog=master;")
$ConnStrMaster

connectionStringDegerleriniAyir($ConnStr);
$host.ui.writeline("sqlCmd CommandLine = $global:SqlCmdCommandLine")

## Scope server yapinca calismiyor ifi comment edince veritabanini olusturuyor.
if ($scope -ne "Server")
{
	$CreateDb = "CREATE DATABASE $dbName"
	executeSql -sql $CreateDb -ConnectionString $ConnStrMaster
	
	$host.ui.writeline("Veritabani Olusturuldu.")
}

# Insert yapmak icin
SetEnvironmentVariables


$schemaFiles = Get-ChildItem -Path "Database" -include CreateSchema.sql -Recurse
executeFileContentsViaSql -sqlFiles $schemaFiles -ConnectionString $ConnStr

$host.ui.writeline("Schemalar Olusturuldu.")


$userDefinedFiles = Get-ChildItem -Path "Database" -include UserDefinedDataType.SQL -Recurse
executeFileContentsViaSql -sqlFiles $userDefinedFiles -ConnectionString $ConnStr

$host.ui.writeline("User Defined Types Olusturuldu.")
	


$CreateTableFiles = Get-ChildItem -Path "Database" -include *CreateTable.sql -Recurse
executeFileContentsViaSql -sqlFiles $CreateTableFiles -ConnectionString $ConnStr

$host.ui.writeline("Tablolar Olusturuldu.")


$CreateRelationFiles = Get-ChildItem -Path "Database" -include *Relations.sql -Recurse
executeFileContentsViaSql -sqlFiles $CreateRelationFiles -ConnectionString $ConnStr

$host.ui.writeline("Relationlar  Olusturuldu.")



$CalisicakDosyalar = Get-ChildItem -Path "Database/StoredProcedures" -include *.sql -Recurse
SqlDosyasiCalistir($CalisicakDosyalar)

echo "Stored Procedurelar eklendi"


$CalisicakDosyalar = Get-ChildItem -Path "Database/CreateViews" -include *.sql -Recurse
SqlDosyasiCalistir($CalisicakDosyalar)

echo "Viewlar eklendi"


$InsertFiles = Get-ChildItem -Path "Database" -include *Insert.sql -Recurse |  sort-object Name
executeFileContentsViaSql -sqlFiles $InsertFiles -ConnectionString $ConnStr

$host.ui.writeline("Insertler yapildi")


# SIG # Begin signature block
# MIIEMwYJKoZIhvcNAQcCoIIEJDCCBCACAQExCzAJBgUrDgMCGgUAMGkGCisGAQQB
# gjcCAQSgWzBZMDQGCisGAQQBgjcCAR4wJgIDAQAABBAfzDtgWUsITrck0sYpfvNR
# AgEAAgEAAgEAAgEAAgEAMCEwCQYFKw4DAhoFAAQUu31l8csY5xCHll5OM8tl7XSA
# 8K+gggI9MIICOTCCAaagAwIBAgIQCS12UAiXRLJBa+wKIJeQRDAJBgUrDgMCHQUA
# MCwxKjAoBgNVBAMTIVBvd2VyU2hlbGwgTG9jYWwgQ2VydGlmaWNhdGUgUm9vdDAe
# Fw0wNzA1MTcwNzU1NDNaFw0zOTEyMzEyMzU5NTlaMBoxGDAWBgNVBAMTD1Bvd2Vy
# U2hlbGwgVXNlcjCBnzANBgkqhkiG9w0BAQEFAAOBjQAwgYkCgYEAtSryrBFy/uFo
# c/qCrr7m1hWCWktV/E8kolkY0ZnlHEqMF9dmnxLgZ77iFNlzICyyGAW64Xjl7vZ7
# ujd4jAzlDVWnihDanmKJHQCSVVciOtPRA/ebkHgqxUAb3v/9mmlST8+sN2wzaPmH
# EYGBMw39Bd/kmjOQsq2LAy8cKBwBWvUCAwEAAaN2MHQwEwYDVR0lBAwwCgYIKwYB
# BQUHAwMwXQYDVR0BBFYwVIAQck1bL3yjn+7fATsXGxWbLKEuMCwxKjAoBgNVBAMT
# IVBvd2VyU2hlbGwgTG9jYWwgQ2VydGlmaWNhdGUgUm9vdIIQcQelrRk7LpBEg4jp
# HWJKAzAJBgUrDgMCHQUAA4GBACSmG5HKdvM420oH4RHKCQ9T64oR6+YkKEI8WcPy
# OUkZ4/7At2i1LMZl7jFAMwVH4q5L425SGpeS0/3QpcTE9cgvTPL6FaEQdeb3/x8a
# Tv/hmojBlp9mRNMENvXjezwL9vfgmfj1kFabg5y/YirE11uVm0qjrIjBo/XE97q7
# IrtjMYIBYDCCAVwCAQEwQDAsMSowKAYDVQQDEyFQb3dlclNoZWxsIExvY2FsIENl
# cnRpZmljYXRlIFJvb3QCEAktdlAIl0SyQWvsCiCXkEQwCQYFKw4DAhoFAKB4MBgG
# CisGAQQBgjcCAQwxCjAIoAKAAKECgAAwGQYJKoZIhvcNAQkDMQwGCisGAQQBgjcC
# AQQwHAYKKwYBBAGCNwIBCzEOMAwGCisGAQQBgjcCARUwIwYJKoZIhvcNAQkEMRYE
# FOLSjS/U08HU6M1UjqCTvdcqoBnUMA0GCSqGSIb3DQEBAQUABIGADC01CMath/67
# RGtQWVyP1MXU+xM6DTdEeG8pGgPyyI0zlhrHts6qkLggpO7pRvPPk8imyoWvbVzV
# t4KLSHZcsv8FPbKNigNvB+N9b8uIuEuMag9tIdqhTGUyBID/ZkICa9d9XEQscNhg
# NuthHdRhIXoJNK+EB5X05/yf5NdDQNE=
# SIG # End signature block
