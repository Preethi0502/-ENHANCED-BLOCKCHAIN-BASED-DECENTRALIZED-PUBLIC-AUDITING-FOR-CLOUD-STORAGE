<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UploadFiles.aspx.cs" Inherits="UploadFiles" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    </asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Upload Files</h1>
    <table border="0" cellpadding="0" cellspacing="0" width="550">
        <tr>
            <td class="tc150">Cloud Storage</td>
            <td class="tc250">
                <asp:DropDownList ID="drpCloudStorage" runat="server" Width="250px">
                </asp:DropDownList>
            </td>
            <td class="tc150">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="tc150">Select File</td>
            <td class="tc250">
                <asp:FileUpload ID="fuFile" runat="server" Width="250px" />
            </td>
            <td class="tc150">
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" 
                    ControlToValidate="fuFile" ErrorMessage="Select File" 
                    ValidationGroup="Upload"></asp:RequiredFieldValidator>
            </td>
        </tr>
        <tr>
            <td class="tc150">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnUpload" runat="server" CssClass="btn" 
                    onclick="btnUpload_Click" Text="Upload" ValidationGroup="Upload" />
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
    </asp:Content>

