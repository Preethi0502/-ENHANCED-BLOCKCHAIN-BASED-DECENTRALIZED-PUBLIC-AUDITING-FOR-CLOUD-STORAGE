<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="AddCloudStorage.aspx.cs" Inherits="AddCloudStorage" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Add Cloud Storage</h1>
    <table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">Storage Name</td>
            <td class="tc250">
                <asp:TextBox ID="txtUserID" runat="server" 
                    Width="250px"></asp:TextBox>
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="txtUserID" ErrorMessage="Enter Storage Name" 
                    ValidationGroup="Create"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnCreate" runat="server" CssClass="btn" 
                    onclick="btnCreate_Click" Text="Create" ValidationGroup="Create" />
&nbsp;
                </td>
            <td class="tc150">&nbsp;</td>
        </tr>
        <tr>
            <td class="tc150" colspan="3">
                <asp:Label ID="lblNotification" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <h1>Decrypt Storage Names</h1>
    <table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">Upload Key File</td>
            <td class="tc250">
                <asp:FileUpload ID="fuKeyFile" runat="server" />
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" 
                    ControlToValidate="fuKeyFile" ErrorMessage="Select Key File" 
                    ValidationGroup="KeyFile"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnUpload" runat="server" CssClass="btn" 
                    onclick="btnUpload_Click" Text="Upload" ValidationGroup="KeyFile" />
&nbsp;
                </td>
            <td class="tc150">&nbsp;</td>
        </tr>
        <tr>
            <td class="tc150" colspan="3">
                <asp:Label ID="lblNotification0" runat="server" ForeColor="Red"></asp:Label>
            </td>
        </tr>
    </table>
    <br />
    <br />
    <asp:DataList ID="dlStorage" runat="server" 
        RepeatColumns="4" style="text-align: center" Width="590px">
        <ItemTemplate>
            <asp:Image ID="imgIcon" runat="server" Height="96px" Width="96px" 
                ImageUrl='<%# "~/icons/1.png" %>' />
            <br />
            <asp:Label ID="lblStorageName" runat="server" Text='<%# Eval("StorageName") %>'></asp:Label>
            <br />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    </asp:Content>

