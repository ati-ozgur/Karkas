$x = [xml] (type "azmanStore.xml")

$str = ""
$str = $str + "namespace Simetri.Core.DataUtil.TestConsoleApp`r`n"
$str = $str + "{`r`n"
$str = $str + "    public partial class YetkiEnum`r`n"
$str = $str + "    {`r`n"
foreach($op in $x.AzAdminManager.AzApplication.AzOperation)
{
$str = $str +    "	public const int " + $op.Name + " = " + $op.OperationID+ ";`r`n"
}
$str = $str + "    }`r`n"
$str = $str + "}`r`n"

$str | Out-file -filepath OrnekYetkiEnum.generated.cs

