<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RaporKopyalaveDataSourceSetleme.aspx.cs" Inherits="Ornekler_RaporOrnekleri_RaporKopyalaveDataSourceSetleme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Adi" runat="server" Text="Adi"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Soaadi" runat="server" Text="Soyadi"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSoyadi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonRaporAc" runat="server" Text="Rapor Al" 
                    onclick="ButtonRaporAc_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    </div>
    </form>
</body>
</html>

