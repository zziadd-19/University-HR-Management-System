<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            please log in</div>
        <p>
            username:</p>
        <p>
            <asp:TextBox ID="username" runat="server"></asp:TextBox>
        </p>
        password:<p>
            <asp:TextBox ID="password" runat="server"></asp:TextBox>
        </p>
        <p>
            &nbsp;</p>
        <p>
            <asp:Button ID="signin" runat="server" OnClick="login" Text="log in" />
        </p>
    </form>
</body>
</html>
