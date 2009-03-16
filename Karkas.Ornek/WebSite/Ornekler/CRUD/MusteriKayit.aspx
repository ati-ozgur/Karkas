<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MusteriKayit.aspx.cs" Inherits="Ornekler_CRUD_MusteriKayit" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <table width="100%" align="center">
            <tr>
                <td>
                    Adı :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    İkinci Adı :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxIkinciAdi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Soyadı :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSoyadi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Doğum Tarihi :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxDogumTarihi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Aktif mi :
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxAktifmi" runat="server" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="ButtonKaydet" runat="server" Text="Kaydet" 
                        onclick="ButtonKaydet_Click" />
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
