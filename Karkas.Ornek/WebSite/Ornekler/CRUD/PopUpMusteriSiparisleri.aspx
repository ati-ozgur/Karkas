<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PopUpMusteriSiparisleri.aspx.cs"
    Inherits="Ornekler_CRUD_PopUpMusteriSiparisleri" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <asp:ScriptManager ID="Sm" runat="server">
    </asp:ScriptManager>
    <div>
        <table width="100%">
            <tr>
                <td>
                    Tutar :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTutar" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    Tarih :
                </td>
                <td>
                    <asp:TextBox ID="TextBoxTarih" runat="server"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:Button ID="ButtonKaydet" runat="server" Text="Kaydet" OnClick="ButtonKaydet_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2" align="center">
                    <asp:GridView ID="GridViewSiparis" runat="server" AutoGenerateColumns="false" Width="100%"
                        OnRowCommand="GridViewSiparis_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="Tutar" HeaderText="Tutar" />
                            <asp:BoundField DataField="SiparisTarihi" HeaderText="Sipariş Tarihi" DataFormatString="{0:dd.MM.yyyy}"
                                HtmlEncode="false" />
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <asp:LinkButton ID="LinkButtonSil" runat="server" Text="Sil" CommandArgument='<%#Eval("MusteriSiparisKey") %>'
                                        CommandName="Sil"></asp:LinkButton>
                                    <ajt:ConfirmButtonExtender ID="ConfirmSil" runat="server" ConfirmText="Kaydı silmek istediğinize emin misiniz?"
                                        TargetControlID="LinkButtonSil">
                                    </ajt:ConfirmButtonExtender>
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
