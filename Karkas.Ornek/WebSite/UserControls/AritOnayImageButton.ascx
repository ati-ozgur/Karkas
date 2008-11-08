<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AritOnayImageButton.ascx.cs"
    Inherits="Arit.Web.UserControls.AritOnayImageButton" %>
<asp:ImageButton ID="OnayImageButton" runat="server"></asp:ImageButton>
<ajt:ConfirmButtonExtender ID="cbe" runat="server" ConfirmText="Onaylıyormusunuz?"
    TargetControlID="OnayImageButton" />
