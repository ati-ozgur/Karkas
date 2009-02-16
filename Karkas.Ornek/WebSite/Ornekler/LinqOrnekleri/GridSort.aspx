<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridSort.aspx.cs" Inherits="Ornekler_LinqOrnekleri_GridSort" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
    </div>
    <asp:GridView ID="GridViewMusteriListesi" AllowSorting="true"  
        AutoGenerateColumns="false" runat="server" 
        onsorting="GridViewMusteriListesi_Sorting">
        <Columns>
            <asp:BoundField HeaderText="Adı" DataField="Adi" SortExpression="Adi" />
            <asp:BoundField HeaderText="Soyadı" DataField="Soyadi" />
            <asp:BoundField HeaderText="Önemi" DataField="Onemi" />
            
        
        </Columns>
    </asp:GridView>
    </form>
</body>
</html>

