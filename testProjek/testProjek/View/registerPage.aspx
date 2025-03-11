<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registerPage.aspx.cs" Inherits="testProjek.View.registerPage" %>

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
            <div class="boxInput">
            <asp:Label ID="emailLbl" runat="server" Text="Email"></asp:Label>
                <br />
            <asp:TextBox ID="emailTB" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class="boxInput">
            <asp:Label ID="genderLbl" runat="server" Text="Gender"></asp:Label>
                <br />
            <asp:DropDownList ID="genderDDL" runat="server">
                <asp:ListItem Selected="True">Male</asp:ListItem>
                <asp:ListItem>Female</asp:ListItem>
            </asp:DropDownList>
            </div>
            <br />
            <div class="boxInput">
            <asp:Label ID="conPassLbl" runat="server" Text="Confirm Password"></asp:Label>
                <br />
            <asp:TextBox ID="conPassTB" runat="server"></asp:TextBox>
            </div>
            <br />
            <div class ="boxInput">
                <asp:Label ID="dateLbl" runat="server" Text="DOB"></asp:Label>
                <br />
                <asp:TextBox ID="dateTB" runat="server" TextMode="Date"></asp:TextBox>
            </div>
            <br />
            <div class="boxInput">
            <asp:Label ID="roleLbl" runat="server" Text="Role"></asp:Label>
                <br />
                <asp:DropDownList ID="roleDDL" runat="server">
                    <asp:ListItem>Customer</asp:ListItem>
                    <asp:ListItem Selected="True">Admin</asp:ListItem>
                </asp:DropDownList>
            </div>
            <br />
            <asp:Label ID="errorMsg" runat="server" Text=""></asp:Label>
            <br />
            <asp:Button ID="RegBTN" runat="server" Text="Register" OnClick="RegBTN_Click" />
            <br />
            <asp:HyperLink ID="already" runat="server" NavigateUrl="~/View/loginPage.aspx">already have an account?</asp:HyperLink>
        </div>
    </form>
</body>
</html>
