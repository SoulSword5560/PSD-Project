<%@ Page Title="" Language="C#" MasterPageFile="~/View/navbarAdmin.Master" AutoEventWireup="true" CodeBehind="ManageCard.aspx.cs" Inherits="testProjek.View.ManageCard" %>

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
            <asp:TemplateField HeaderText="Action">
                <ItemTemplate>
                    <asp:Button ID="updateBtn" runat="server" Text="update" UseSubmitBehavior="false" CommandName="Edit"/>
                    <asp:Button ID="deleteBtn" runat="server" Text="delete" UseSubmitBehavior="false" CommandName="Delete" />
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
    </asp:GridView>
    <div>
        <asp:Label ID="idLBL" runat="server" Text="CardID"></asp:Label>
        <br />
        <asp:TextBox ID="idTB" runat="server"></asp:TextBox>
    </div>
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
    <asp:Button ID="updateBTN" runat="server" Text="update" OnClick="updateBTN_Click" />
    <asp:Button ID="insertBTN" runat="server" Text="insert" OnClick="insertBTN_Click" />
</asp:Content>
