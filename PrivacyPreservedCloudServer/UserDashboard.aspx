<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="UserDashboard.aspx.cs" Inherits="UserDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<h1>User Dashboard</h1>
    <br />
    <asp:DataList ID="dlMenu" runat="server" DataKeyField="MenuID" 
        RepeatColumns="4" style="text-align: center" Width="590px" 
        onitemcommand="dlMenu_ItemCommand">
        <ItemTemplate>
            <asp:Image ID="imgIcon" runat="server" Height="96px" Width="96px" 
                ImageUrl='<%# "~/icons/" + Eval("MenuID") + ".png" %>' />
            <br />
            <asp:LinkButton ID="lbtIconLink" runat="server" 
                CommandArgument="<%# Container.ItemIndex %>" Font-Size="10pt" 
                Text='<%# Eval("MenuName") %>' CommandName="OpenLink"></asp:LinkButton>
            <br />
            <br />
            <br />
        </ItemTemplate>
    </asp:DataList>
    <br />
    <asp:Label ID="lblNotification" runat="server" ForeColor="Red"></asp:Label>
</asp:Content>

