<%@ Page Title="" Language="C#" MasterPageFile="~/View/navbarAdmin.Master" AutoEventWireup="true" CodeBehind="handleTransaction.aspx.cs" Inherits="testProjek.View.handleTransaction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:GridView ID="gv" runat="server" AutoGenerateColumns="False"  OnRowCommand="gv_RowCommand">
    <Columns>
        <asp:BoundField DataField="TransactionID" HeaderText="TransactionID" SortExpression="TransactionID" />
        <asp:BoundField DataField="TransactionDate" HeaderText="TransactionDate" SortExpression="TransactionDate" />
        <asp:BoundField DataField="CustomerID" HeaderText="CustomerID" SortExpression="CustomerID" />
        <asp:BoundField DataField="Status" HeaderText="Status" SortExpression="Status" />
        <asp:TemplateField HeaderText="Action">
            <ItemTemplate>
                <asp:Button ID="HandleBtn" runat="server" Text="Handle" UseSubmitBehavior="false" CommandName="Handle"  CommandArgument='<%# ((GridViewRow) Container).RowIndex %>' />
            </ItemTemplate>
        </asp:TemplateField>
    </Columns>
</asp:GridView>
</asp:Content>
