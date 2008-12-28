<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RaporAcma.aspx.cs" Inherits="Ornekler_RaporOrnekleri_RaporAcma" %>

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
    <table class="style1">
        <tr>
            <td>
                <asp:Label ID="Ad" runat="server" Text="Ad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxAdi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="Soyad" runat="server" Text="Soyad"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="TextBoxSoyadi" runat="server"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="ButtonRaporAc" runat="server" Text="Rapor Al" 
                    onclick="ButtonRaporAc_Click" />
                <asp:Button ID="ButtonRaporTarayiciIcindeAc" runat="server" Text="Rapor Al" 
                    onclick="ButtonRaporTarayiciIcindeAc_Click" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
    <div>
    
    </div>
    </form>
</body>
</html>
