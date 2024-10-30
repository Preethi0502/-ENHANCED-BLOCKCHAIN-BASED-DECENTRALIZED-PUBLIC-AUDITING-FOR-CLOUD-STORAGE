<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCloudStorageInvalidKey.aspx.cs" Inherits="AddCloudStorageInvalidKey" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Incorrect Key File</h1>
<p>Incorrect Key file entered!</p>
<p>Try Again?
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Click Here" CssClass="btn" 
            onclick="btnBack_Click" /></p>
</asp:Content>

