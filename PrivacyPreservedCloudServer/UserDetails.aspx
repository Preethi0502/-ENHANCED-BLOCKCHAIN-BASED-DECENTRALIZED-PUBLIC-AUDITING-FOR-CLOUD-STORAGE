<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDetails.aspx.cs" Inherits="UserDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style type="text/css">
        .style1
        {
            width: 148px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>User Details</h1>
<table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="style1">Upload Key File</td>
            <td class="tc250">
                <asp:FileUpload ID="fuKeyFile" runat="server" />
            </td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnUpload" runat="server" CssClass="btn" 
                    onclick="btnUpload_Click" Text="Upload" />
            </td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="tc250">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style1">Name</td>
            <td class="tc250">
                <asp:Label ID="lblUserName" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">Gender</td>
            <td class="tc250">
                <asp:Label ID="lblGender" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">Birth Date</td>
            <td class="tc250">
                <asp:Label ID="lblBirthDate" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">Mobile Number</td>
            <td class="tc250">
                <asp:Label ID="lblMobileNumber" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">Email ID</td>
            <td class="tc250">
                <asp:Label ID="lblEmailID" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">User ID</td>
            <td class="tc250">
                <asp:Label ID="lblUserID" runat="server" Font-Size="Smaller"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="style1">&nbsp;</td>
            <td class="tc250">
                &nbsp;</td>
        </tr>
    </table>
    <asp:Label ID="lblNotification" runat="server" ForeColor="Red"></asp:Label>
    <br />
</asp:Content>

