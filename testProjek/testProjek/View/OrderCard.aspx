<%@ Page Language="C#" MasterPageFile="~/View/navbarCustomer.Master" AutoEventWireup="true" CodeBehind="OrderCard.aspx.cs" Inherits="testProjek.View.OrderCard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False" OnRowDeleting="gv_RowDeleting" OnRowEditing="gv_RowEditing">
        <Columns>
            <asp:BoundField DataField="CardID" HeaderText="CardID" SortExpression="CardID" />
            <asp:BoundField DataField="CardName" HeaderText="CardName" SortExpression="CardName" />
            <asp:BoundField DataField="CardPrice" HeaderText="CardPrice" SortExpression="CardPrice" />
            <asp:BoundField DataField="CardDesc" HeaderText="CardDesc" SortExpression="CardDesc" />
            <asp:BoundField DataField="CardType" HeaderText="CardType" SortExpression="CardType" />
            <asp:TemplateField HeaderText="isFoil">
                <ItemTemplate>
                    <asp:Label ID="lblIsFoil" runat="server"
                        Text='<%# ConvertIsFoil(Eval("isFoil")) %>'>
                    </asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            </Columns>
</asp:GridView>
</asp:Content>