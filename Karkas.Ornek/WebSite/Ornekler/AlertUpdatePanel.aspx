<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlertUpdatePanel.aspx.cs"
    Inherits="Ornekler_AlertUpdatePanel" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager runat="server" ID="sm1">
        <Scripts>
            <asp:ScriptReference Path="~/javascript/dimensions.js" />
        </Scripts>
    </asp:ScriptManager>
    <div>
        <asp:UpdatePanel runat="server" ID="updatePanel1">
            <Triggers>
                <asp:AsyncPostBackTrigger ControlID="KaydetButton" />
            </Triggers>
            <ContentTemplate>
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
                            &nbsp;
                        </td>
                        <td>
                            <asp:Button ID="KaydetButton" runat="server" Text="Kaydet" OnClick="KaydetButton_Click" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
    </form>
</body>
</html>
