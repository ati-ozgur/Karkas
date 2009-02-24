<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ExportHelperToCsv.aspx.cs" Inherits="Ornekler_ExportHelper_ExportHelperToCsv" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <table class="style1">
            <tr>
                <td>
                    Adı</td>
                <td>
                    <asp:TextBox ID="TextBoxAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Soyadı</td>
                <td>
                    <asp:TextBox ID="TextBoxSoyadi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonAra" runat="server" Text="Ara" />
                </td>
                <td>
                    <asp:Button ID="ButtonCsv" runat="server" Text="Csv Al" 
                        onclick="ButtonCsv_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
