<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShareSuccess.aspx.cs" Inherits="UserDetailsInvalidKey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Share Successfull</h1>
<p>The selected Storage has been shared successfully!</p>
<p>
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Click Here" CssClass="btn" 
            onclick="btnBack_Click" /></p>
</asp:Content>

