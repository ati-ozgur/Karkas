<%@ Page Language="C#" AutoEventWireup="true" CodeFile="OrnekAnaSayfa.aspx.cs" Inherits="Ornekler_PopUpOrnekleri_OrnekAnaSayfa" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../javascript/PopUp.js"> </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>
            ANA SAYFA
        </h1>
    </div>
    <asp:Button ID="ButtonPopUpTilda1" runat="server" 
        onclick="ButtonPopUpTilda1_Click" Text="Tilda 1" />
        
        <asp:HyperLink runat="server" id="ButtonPopUpTilda2" Text="Tilda 2" />
        <asp:HyperLink runat="server" id="ButtonPopUp" Text="Normal 1" />
        
    </form>
</body>
</html>

