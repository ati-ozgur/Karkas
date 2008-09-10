<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrnekDataTableBind.aspx.cs"
    Inherits="Ornekler_OrnekDataTableBind" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td>
                    <asp:DropDownList ID="MusteriDropDownList" runat="server" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:DropDownList ID="MusteriLutfenDropDownList" runat="server" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
