<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="LoginFailed.aspx.cs" Inherits="LoginFailed" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Login Failed</h1>
<p>Invalid Authentication! Incorrect User ID or Password or Key File</p>
<p>Try Again?
    <br />
    <asp:Button ID="btnBack" runat="server" Text="Click Here" CssClass="btn" 
            onclick="btnBack_Click" /></p>
</asp:Content>

