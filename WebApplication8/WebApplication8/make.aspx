
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="make.aspx.cs" Inherits="WebApplication8.make" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<title> Генератор ребусов</title>
<head runat="server">
    <link rel="stylesheet" type="text/css" href="make.css" />
    <title></title>
    <script src=JScript1.js></script>
    <script type="text/javascript">
        function calling() {
            document.getElementById("ID1").innerHTML = '<p> ololol </p>';
            var str = "DOIFODFIJ";       
        }
    
    </script>
</head>
<body>
    <img src = "b-ground.jpg" class="background" />
    <form id="form1" runat="server">   
    <div id="div1" class="class1" runat="server">
        <center>
        <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Назад" />
        <asp:Label ID="Label1" runat="server"></asp:Label>
        
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Преобразовать еще раз" />
        <asp:Button ID="Button3" runat="server" onclick="Button3_Click" Text="Сохранить картинку" />
        </center>
    </div>

    <br />
    <center>
    <div id="id1" style="                        text-align :center;
                        vertical-align: middle;
                        height: 60%;
                        width: 100%;"
                        runat="server">
           
    </div>
    </center>

    <div id="id2"><a class="link1" href="http://google.com"></a></div>
    </form>
    
</body>
</html>
