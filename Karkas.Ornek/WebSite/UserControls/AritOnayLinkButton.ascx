<%@ Control Language="C#" AutoEventWireup="true" CodeFile="AritOnayLinkButton.ascx.cs" Inherits="Arit.Core.UserControls.AritOnayLinkButton" %>
<asp:ScriptManager ID="smm" runat="server" ></asp:ScriptManager>
<asp:LinkButton ID="OnayButton" runat="server" CssClass="btn" Text=" "></asp:LinkButton>
<ajt:ConfirmButtonExtender ID="cbe" runat="server" TargetControlID="OnayButton" OnClientCancel="CancelClick" />
    