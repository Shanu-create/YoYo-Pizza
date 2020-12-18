<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="new1.aspx.cs" Inherits="Chatbot.new1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>YoYo Pizza</title>
	<link rel="icon" href="bot.png" />
  
</head>
<body style="height: 814px">
    <form id="form1" runat="server">
        <div align="center" style="background-image: url('bot1.jpg'); background-size: cover; background-repeat: no-repeat;
  background-attachment: fixed;
  background-size: 100% 100%; height: 2763px;">
            <asp:Label ID="Label2" runat="server" BackColor="White"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Height="89px" Width="514px" BackColor="White"></asp:Label>
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <br />
            <asp:TextBox ID="TextBox1" runat="server" Height="47px" Width="410px" namespace="Say hi...."></asp:TextBox>
            <asp:Button ID="Button1" runat="server" Height="60px" Text="Send" Width="101px" OnClick="Button1_Click1" />
        </div>
    </form>
</body>
</html>
