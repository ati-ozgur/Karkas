<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrnekGridToExcelVeWord.aspx.cs"
    Inherits="Ornekler_OrnekGridToExcelVeWord" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table>
            <tr>
                <td style="margin-left: 40px">
                    <asp:Button ID="ButtonAra" runat="server" Text="Ara" 
                        onclick="ButtonAra_Click" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:GridView ID="GridViewArama" runat="server" ShowHeader="True" Width="100%">
                    
                    </asp:GridView>
                </td>
            </tr>
            <tr>
            <td>
                <asp:Button ID="ButtonExcel" runat="server" Text="Excel'e Aktar" 
                    onclick="ButtonExcel_Click" />
                <asp:Button ID="ButtonWord" runat="server" Text="Word'e Aktar" 
                    onclick="ButtonWord_Click" />
            </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
