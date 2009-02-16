<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KarkasTreeView.aspx.cs" Inherits="Ornekler_KarkasTreeView" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <karkas:KarkasTreeView ShowLines="true" ID="trvEvrakSafahati" runat="server" NodeIndent="15"
            ExpandDepth="0" PathSeparator="\" PopulateNodesFromClient="true" EnableClientScript="true"
            OnTreeNodePopulate="trvEvrakSafahati_TreeNodePopulate" Width="100%">
        </karkas:KarkasTreeView>
    </div>
    </form>
</body>
</html>

