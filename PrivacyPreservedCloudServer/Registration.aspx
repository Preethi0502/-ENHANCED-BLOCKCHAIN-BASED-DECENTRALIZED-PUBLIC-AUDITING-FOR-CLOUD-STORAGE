<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>User Registration</h1>
    <table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">Name</td>
            <td class="tc250">
                <asp:TextBox ID="txtName" runat="server" Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Enter Name" 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Gender</td>
            <td class="tc250">
                <asp:DropDownList ID="drpGender" runat="server" Width="250px">
                    <asp:ListItem>Male</asp:ListItem>
                    <asp:ListItem>Female</asp:ListItem>
                </asp:DropDownList>
            </td>
            <td class="tc150">&nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">Birth Date</td>
            <td class="tc250">
                <asp:TextBox ID="txtBirthDate" PlaceHolder="Example: 1/1/2015" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                    ControlToValidate="txtBirthDate" ErrorMessage="Enter Birth Date" 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Mobile Number</td>
            <td class="tc250">
                <asp:TextBox ID="txtMobileNumber" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" 
                    ControlToValidate="txtMobileNumber" ErrorMessage="Enter Mobile No." 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Email ID</td>
            <td class="tc250">
                <asp:TextBox ID="txtEmailID" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" 
                    ControlToValidate="txtEmailID" ErrorMessage="Enter Email ID" 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">&nbsp;</td>
            <td class="tc250">&nbsp;</td>
            <td class="tc150">&nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">User ID</td>
            <td class="tc250">
                <asp:TextBox ID="txtUserID" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtName" ErrorMessage="Enter User ID" 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Password</td>
            <td class="tc250">
                <asp:TextBox ID="txtPassword1" runat="server" 
                    Width="250px" TextMode="Password"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" 
                    ControlToValidate="txtPassword1" ErrorMessage="Enter Password" 
                    ValidationGroup="Register"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">Confirm Password</td>
            <td class="tc250">
            
                <asp:TextBox ID="txtPassword2" runat="server" 
                    Width="250px" TextMode="Password"></asp:TextBox>
            
            
            
            </td>
            <td class="tc150">
                <asp:CompareValidator ID="CompareValidator1" runat="server" 
                    ControlToCompare="txtPassword2" ControlToValidate="txtPassword1" 
                    ErrorMessage="Password Not Match" ValidationGroup="Register"></asp:CompareValidator>
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
                <asp:Button ID="btnRegister" runat="server" CssClass="btn" 
                    onclick="btnRegister_Click" Text="Register" ValidationGroup="Register" />
&nbsp;
                <asp:Button ID="btnClear" runat="server" CssClass="btn" 
                    onclick="btnClear_Click" Text="Clear" />
            </td>
            <td class="tc150">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

