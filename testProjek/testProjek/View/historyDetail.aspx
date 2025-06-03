<%@ Page Title="" Language="C#" MasterPageFile="~/View/navbarCustomer.Master" AutoEventWireup="true" CodeBehind="historyDetail.aspx.cs" Inherits="testProjek.View.historyDetail" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <asp:Label ID="cIdLbl" runat="server" Text="Card ID: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="cNameLbl" runat="server" Text="Card Name: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="tIdLbl" runat="server" Text="Transaction ID: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="tDateLbl" runat="server" Text="Transaction Date: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="tStsLbl" runat="server" Text="Status: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="tQtyLbl" runat="server" Text="Quantity: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="cPriceLbl" runat="server" Text="Unit Price: "></asp:Label>
    </div>
    <div>
        <asp:Label ID="totalLbl" runat="server" Text="Total: "></asp:Label>
    </div>
    <div>
        <br />
        <asp:Button ID="backBtn" runat="server" Text="Back" OnClick="backBtn_Click"/>
    </div>
</asp:Content>
