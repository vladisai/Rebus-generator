<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rebusok.aspx.cs" Inherits="WebApplication8.Rebus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="make.css" />
    <sript type="text/javascript">
            alert("OK");
    </sript>
    
</head>
<body>
    <center><form id="form1" runat="server">
    <div id="div1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="Type your word here, please."></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    </div>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Rebus it!" />
    </p>
    </form>
    </center>
</body>
</html>
