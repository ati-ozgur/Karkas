<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrnekImageButton.aspx.cs"
    Inherits="Ornekler_OrnekImageButton" %>

<%@ Register Src="~/UserControls/AritOnayLinkButton.ascx" TagName="AritOnayLinkButton"
    TagPrefix="arit" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManagerAritOnayLinkButtonDeneme" runat="server">
        </asp:ScriptManager>
    </div>
    <arit:AritOnayLinkButton Text="deneme" OnClick="Deneme_Click" ID="AritOnayLinkButton1"
        OnayMesaj="Devam Etmek İstiyor musunuz?" runat="server" />
    </form>
</body>
</html>
