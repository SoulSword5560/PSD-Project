<%@ Page Title="" Language="C#" MasterPageFile="~/View/navbarCustomer.Master" AutoEventWireup="true" CodeBehind="history.aspx.cs" Inherits="testProjek.View.history" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="Label1" runat="server" Text="History"></asp:Label>
    <asp:GridView ID="GridView1" DataKeyNames="TransactionID" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField DataField="TransactionID" HeaderText="Transaction Id" />
            <asp:BoundField DataField="CardName" HeaderText="Card Name" />
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="detailBtn" runat="server" Text="Detail" OnClick="detailBtn_Click" />
                </ItemTemplate>                
            </asp:TemplateField>            
        </Columns>
    </asp:GridView>
</asp:Content>
