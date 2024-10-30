<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>User Login</h1>
    <table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">User ID</td>
            <td class="tc250">
                <asp:TextBox ID="txtUserID" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="Enter User ID" 
                    ValidationGroup="Login"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Password</td>
            <td class="tc250">
                <asp:TextBox ID="txtPassword" runat="server" 
                    Width="250px" TextMode="Password"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtPassword" ErrorMessage="Enter Password" 
                    ValidationGroup="Login"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Key File</td>
            <td class="tc250">
            
                <asp:FileUpload ID="fuKeyFile" runat="server" Width="250px" />
            
            
            
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" 
                    ControlToValidate="fuKeyFile" ErrorMessage="Upload Key File" 
                    ValidationGroup="Login"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150" colspan="3">
                <asp:Label ID="lblNotification" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tc150">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnLogin" runat="server" CssClass="btn" 
                    onclick="btnLogin_Click" Text="Login" ValidationGroup="Login" />
&nbsp;
                </td>
            <td class="tc150">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

