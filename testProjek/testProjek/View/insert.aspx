<%@ Page Title="" Language="C#" MasterPageFile="~/View/navbarAdmin.Master" AutoEventWireup="true" CodeBehind="insert.aspx.cs" Inherits="testProjek.View.insert" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
    <asp:Label ID="nameLBL" runat="server" Text="CardName"></asp:Label>
    <br />
    <asp:TextBox ID="nameTB" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="priceLBL" runat="server" Text="CardPrice"></asp:Label>
    <br />
    <asp:TextBox ID="priceTB" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="descLBL" runat="server" Text="CardDesc"></asp:Label>
    <br />
    <asp:TextBox ID="descTB" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="typeLBL" runat="server" Text="CardType"></asp:Label>
    <br />
    <asp:TextBox ID="typeTB" runat="server"></asp:TextBox>
</div>
<div>
    <asp:Label ID="foilLBL" runat="server" Text="isFoil"></asp:Label>
    <br />
    <asp:DropDownList ID="foilDDL" runat="server">
        <asp:ListItem Text="No" Value="0"></asp:ListItem>
        <asp:ListItem Text="Yes" Value="1"></asp:ListItem>
    </asp:DropDownList>
</div>
    <asp:Button ID="insertBtn" runat="server" Text="Insert" OnClick="insertBtn_Click"/>
    <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click" />
</asp:Content>
