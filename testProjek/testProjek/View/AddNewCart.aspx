<%@ Page Language="C#" MasterPageFile="~/View/navbarCustomer.Master" AutoEventWireup="true" CodeBehind="AddNewCart.aspx.cs" Inherits="testProjek.View.AddNewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>CART</h1>
    </div>
    <div>
        <asp:ListBox ID="lb" runat="server" OnSelectedIndexChanged="lb_SelectedIndexChanged">
            <asp:ListItem DataField="CardName"/>
            <asp:ListItem DataField="CardPrice"/>
            <asp:ListItem DataField="Quantity"/>
        </asp:ListBox>
    </div>
    <div>
        <asp:Label ID="qtyLbl" runat="server" Text="Quantity"></asp:Label>
        <asp:TextBox ID="qtyTxt" runat="server" OnTextChanged="qtyTxt_TextChanged"></asp:TextBox>
    </div>
    <div>
        <asp:Button ID="coutBtn" runat="server" Text="Check Out" OnClick="coutBtn_Click" />
    </div>
</asp:Content>

