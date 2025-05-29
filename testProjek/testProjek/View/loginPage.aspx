<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="loginPage.aspx.cs" Inherits="testProjek.View.loginPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div class="boxInput">
                <asp:Label ID="nameLbl" runat="server" Text="Username"></asp:Label>
                <br />
                <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="boxInput">
                <asp:Label ID="passLbl" runat="server" Text="Password"></asp:Label>
                <br />
                <asp:TextBox ID="passTB" runat="server" TextMode="Password"></asp:TextBox>
            </div>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
            <br />
            <asp:CheckBox ID="remember" runat="server" Text="remember me" />
            <br />
            <asp:Button ID="login" runat="server" Text="Login" OnClick="login_Click" />
        </div>
    </form>
</body>
</html>
