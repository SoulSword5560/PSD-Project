<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Profile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
                <tr>
                    <td>Password:</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" /></td>
                </tr>
                <tr>
                    <td>Gender:</td>
                    <td>
                        <asp:DropDownList ID="ddlGender" runat="server">
                            <asp:ListItem Text="Select" Value="" />
                            <asp:ListItem Text="Male" Value="Male" />
                            <asp:ListItem Text="Female" Value="Female" />
                        </asp:DropDownList>
                    </td>
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
    </form>
</body>
</html>
