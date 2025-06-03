<%@ Page Language="C#" MasterPageFile="~/View/navbarCustomer.Master" AutoEventWireup="true" CodeBehind="AddNewCart.aspx.cs" Inherits="testProjek.View.AddNewCart" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <h1>CART</h1>
    </div>
    <div> 
        <asp:GridView ID="gridview" runat="server" DataKeyNames="CartId" AutoGenerateColumns="false" OnRowDataBound="gridview_RowDataBound" OnRowDeleting="gridview_RowDeleting" OnRowUpdating="gv_RowUpdating">
             <Columns>
                 <asp:TemplateField HeaderText="Number">
                     <ItemTemplate>
                          <asp:Label ID="lblNumber" runat="server" />
                     </ItemTemplate>
                 </asp:TemplateField>
                 <asp:BoundField DataField="CartId" HeaderText="Cart ID"/>
                 <asp:BoundField DataField="CardName" HeaderText="Card Name"/>
                 <asp:BoundField DataField="CardPrice" HeaderText="Card Price"/>
                 <asp:BoundField DataField="Quantity" HeaderText="Quantity"/>
                 <asp:BoundField DataField="Subtotal" HeaderText="Subtotal">         
                 </asp:BoundField>
                 <asp:TemplateField HeaderText="Action">
                     <ItemTemplate>
                         <asp:Button ID="updBtn" runat="server" Text="Update" CommandName="Update" />
                         <asp:Button ID="dltBtn" runat="server" Text="Delete" CommandName="Delete"/>
                     </ItemTemplate>
                 </asp:TemplateField>
             </Columns>            
        </asp:GridView>
    </div>
    <div>
        <asp:Label ID="TotalTxt" runat="server" Text="Total: $"></asp:Label>
    </div>
    <div>
        <br />
        <asp:Label ID="idLbl" runat="server" Text="Id: "></asp:Label>
        <br />
        <asp:TextBox ID="idTxt" runat="server"></asp:TextBox>        
    </div>
    <div>
        <br />
        <asp:Label ID="updLbl" runat="server" Text="New Quantity: "></asp:Label>
        <br />
        <asp:TextBox ID="updTxt" runat="server"></asp:TextBox>        
    </div>
    <div>
        <br />
        <asp:Label Text="Choose Payment: " runat="server"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem>GoPay</asp:ListItem>
            <asp:ListItem>Ovo</asp:ListItem>
            <asp:ListItem>ShopeePay</asp:ListItem>
            <asp:ListItem>Dana</asp:ListItem>
            <asp:ListItem>Virtual Account</asp:ListItem>
            <asp:ListItem>Credit Card</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div>
        <br />
        <asp:Button ID="coutBtn" runat="server" Text="Check Out" OnClick="coutBtn_Click" />
    </div>
    <div>
        <br />
        <asp:Button ID="uptBtn" runat="server" Text="Update" OnClick="updateBtn_Click" />
        <asp:HiddenField ID="userIdHidden" runat="server" />
    </div>
    <div>
        <br />
        <asp:Button ID="clrBtn" runat="server" Text="Clear Cart" OnClick="clearBtn_Click"/>
    </div>
</asp:Content>

