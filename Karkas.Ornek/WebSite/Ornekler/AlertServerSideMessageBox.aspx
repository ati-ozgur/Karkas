<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlertServerSideMessageBox.aspx.cs" Inherits="Ornekler_AlertServerSideMessageBox" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
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
                    <asp:Label ID="Label1" runat="server" Text="Adı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="AdiTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label2" runat="server" Text="Soyadı"></asp:Label>
                </td>
                <td>
                    <asp:TextBox ID="SoyadiTextBox" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    &nbsp;</td>
                <td>
                    <asp:Button ID="KaydetButton" runat="server" Text="Kaydet" 
                        onclick="KaydetButton_Click" />
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>

