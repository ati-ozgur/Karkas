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
                <td colspan="3">
                    DataTable Ile
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonExcelDataTableDataTable1" runat="server" Text="Excel'e Aktar 1"
                        OnClick="ButtonExcelDataTable1_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonExcelDataTable2" runat="server" Text="Excel'e Aktar 2 " OnClick="ButtonExcelDataTable2_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonExcelDataTable3" runat="server" Text="Excel'e Aktar 3" OnClick="ButtonExcelDataTable3_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="3">
                    DataView Ile
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonExcelDataView1" runat="server" Text="Excel'e Aktar 1"
                        OnClick="ButtonExcelDataView1_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonExcelDataView2" runat="server" Text="Excel'e Aktar 2 " OnClick="ButtonExcelDataView2_Click" />
                </td>
                <td>
                    <asp:Button ID="ButtonExcelDataView3" runat="server" Text="Excel'e Aktar 3" OnClick="ButtonExcelDataView3_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
