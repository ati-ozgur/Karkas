<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AritOnayLinkButton.ascx.cs"
    Inherits="Arit.Web.UserControls.AritOnayLinkButton" %>
<asp:LinkButton ID="OnayButton" runat="server" CssClass="btn" Text=" "></asp:LinkButton>
<ajt:ConfirmButtonExtender  ID="cbe" runat="server" ConfirmText="Onaylıyormusunuz?"
    TargetControlID="OnayButton"  />

