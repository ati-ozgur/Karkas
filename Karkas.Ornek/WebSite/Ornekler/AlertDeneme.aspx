<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AlertDeneme.aspx.cs" Inherits="Ornekler_AlertDeneme" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">



<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

<script type="text/javascript" language="javascript" src="../javascript/jquery.js"></script>
<script type="text/javascript" language="javascript" src="../javascript/jqDnR.js"></script>
<script type="text/javascript" language="javascript" src="../javascript/jqalert.js"></script>

<script type="text/javascript" language="javascript">
try {
    
	window.alert = window.jqalert;
} catch (err) {
	window.alert('Your browser does not support overloading window.alert. ' + err);
}


</script>


</head>
<body>
    <form id="form1" runat="server">
    <div>
            <input type="button" id="deneme" value="klik" onclick="alert('aaa');"  />
    </div>
    </form>
</body>
</html>
