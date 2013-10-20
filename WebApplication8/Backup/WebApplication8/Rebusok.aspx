<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Rebusok.aspx.cs" Inherits="WebApplication8.Rebus" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<title> Генератор ребусов</title>
<head runat="server">
   
    
    <link rel="stylesheet" type="text/css" href="make.css" />
    <script type="text/javascript">
        function check_text() {
            alert("Ok");
        }
    
    </script>
    
    
</head>
<body>
    <img src = "b-ground.jpg" class="background" />
    <center><form id="form1" runat="server">
    <div id="div1" runat="server">
    
        <asp:Label ID="Label1" runat="server" Text="Введите, пожалуйста, слово"></asp:Label>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
    
    </div>
    <p>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" 
            Text="Сделать ребус" />
        <asp:CheckBox ID="CheckBox1" runat="server" 
            oncheckedchanged="CheckBox1_CheckedChanged" style="display: none" Text="Облегченный режим" />
        <br />
        <asp:Label ID="Label2" runat="server"></asp:Label>
    </p>
    </form>
    </center>
</body>
</html>
