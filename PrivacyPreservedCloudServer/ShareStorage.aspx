<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="ShareStorage.aspx.cs" Inherits="ShareStorage" Theme="SkinFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
                    <h1>Share Storage</h1>


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
            <td class="tc150">&nbsp;</td>
            <td class="tc250">
                <asp:Button ID="btnShare" runat="server" CssClass="btn" 
                    onclick="btnShare_Click" Text="Read Share" ValidationGroup="Upload" />
&nbsp;
                <asp:Button ID="btnWriteShare" runat="server" CssClass="btn" 
                    onclick="btnWriteShare_Click" Text="Write Share" 
                    ValidationGroup="Upload" />
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


                    <asp:GridView ID="dgvFiles" runat="server" 
        AutoGenerateColumns="False" CellPadding="4"
                        ForeColor="#333333" GridLines="None" Width="600px" 
        AllowPaging="True" DataKeyNames="FileID" 
                        EnableModelValidation="True">
                        <FooterStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" />
                        <Columns>
                            <asp:BoundField DataField="FileName" HeaderText="Filename" />
                            <asp:BoundField DataField="FileSize" HeaderText="Size" />
                            <asp:BoundField DataField="UploadedOn" HeaderText="Date" />
                        </Columns>
                        <RowStyle BackColor="#EFF3FB" />
                        <EditRowStyle BackColor="#2461BF" />
                        <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                        <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="#FF6600" Font-Bold="True" ForeColor="White" 
                            HorizontalAlign="Left" />
                        <AlternatingRowStyle BackColor="White" />
                    </asp:GridView>
                    <br />
                    <asp:Label ID="lblNotification" runat="server"></asp:Label>


</asp:Content>

