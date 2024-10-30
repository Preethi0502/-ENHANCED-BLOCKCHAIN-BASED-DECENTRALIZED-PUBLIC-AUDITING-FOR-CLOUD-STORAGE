<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Download.aspx.cs" Inherits="Download" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>Download File</h1>
<table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">File Name</td>
            <td class="tc250">
                <asp:Label ID="lblFileName" runat="server"></asp:Label>
            </td>
            <td class="tc150">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">File Size</td>
            <td class="tc250">
                <asp:Label ID="lblFileSize" runat="server"></asp:Label>
            </td>
            <td class="tc150">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">Owner</td>
            <td class="tc250">
                <asp:Label ID="lblOwnerName" runat="server"></asp:Label>
            </td>
            <td class="tc150">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">Uploaded Date</td>
            <td class="tc250">
                <asp:Label ID="lblUploadedDate" runat="server"></asp:Label>
            </td>
            <td class="tc150">
                &nbsp;</td>
        </tr>
        </table>

                <asp:Button ID="btnDownload" runat="server" CssClass="btn" 
                    onclick="btnDownload_Click" Text="Download" />
            <br />
    <asp:Label ID="lblNotification" runat="server" ForeColor="Red"></asp:Label>
    <br />
</asp:Content>

