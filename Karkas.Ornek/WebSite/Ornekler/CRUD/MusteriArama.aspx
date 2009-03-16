<%@ Page Language="C#" AutoEventWireup="true" CodeFile="MusteriArama.aspx.cs" Inherits="Ornekler_CRUD_MusteriArama" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <script src="../../javascript/PopUp.js" type="text/javascript"></script>
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
                    Soyadı :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxSoyadi" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Aktif mi :
                </td>
                <td>
                    <asp:CheckBox ID="CheckBoxAktifmi" runat="server" Checked="true" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="ButtonAra" runat="server" Text="Ara" OnClick="ButtonAra_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridViewArama" runat="server" Width="100%" AutoGenerateColumns="false"
                        OnRowDataBound="GridViewArama_RowDataBound" DataKeyNames="MusteriKey,AktifMi"
                        OnPageIndexChanging="GridViewArama_PageIndexChanging">
                        <Columns>
                            <asp:BoundField DataField="Adi" HeaderText="Adı" />
                            <asp:BoundField DataField="IkinciAdi" HeaderText="İkinci Adı" />
                            <asp:BoundField DataField="Soyadi" HeaderText="Soyadi" />
                            <asp:BoundField DataField="DogumTarihi" HeaderText="Doğum Tarihi" />
                            <asp:BoundField DataField="AktifMi" HeaderText="Aktif Mi" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkSiparis" runat="server" Text="Siparişler"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:HyperLink ID="HyperLinkGuncelle" runat="server" Text="Güncelle"></asp:HyperLink>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
