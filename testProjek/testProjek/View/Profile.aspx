<%@ Page Language="C#" MasterPageFile="~/View/navbarCustomer.Master"AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="testProjek.View.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h2>Your Profile</h2>
        <br />
        <asp:Label ID="usnTxt" runat="server" Text="Username: "></asp:Label>
        <br />
        <asp:Label ID="emailTxt" runat="server" Text="Email: "></asp:Label>
        <br />
        <asp:Label ID="genderTxt" runat="server" Text="Gender: "></asp:Label>
        <br />
        <asp:Label ID="roleTxt" runat="server" Text="Role: "></asp:Label>
        <br />
        <asp:Label ID="dobTxt" runat="server" Text="Date Of Birth: "></asp:Label>
        <br />
    </div>
    <div>
        <h2>Update Profile</h2>
        <asp:Label ID="lblMessage" runat="server" ForeColor="Red" />
        <table>
            <tr>
                <td>Username:</td>
                <td>
                    <asp:TextBox ID="txtUsername" runat="server" /></td>
            </tr>
            <tr>
                <td>Email:</td>
                <td>
                    <asp:TextBox ID="txtEmail" runat="server" /></td>
            </tr>
        </table>
        <h4>Change Password (optional)</h4>
        <table>
            <tr>
                <td>Old Password:</td>
                <td>
                    <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>New Password:</td>
                <td>
                    <asp:TextBox ID="txtNewPassword" runat="server" TextMode="Password" /></td>
            </tr>
            <tr>
                <td>Confirm Password:</td>
                <td>
                    <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" /></td>
            </tr>
        </table>
        <asp:Button ID="btnUpdate" runat="server" Text="Update" OnClick="btnUpdate_Click" />
    </div>
</asp:Content>
