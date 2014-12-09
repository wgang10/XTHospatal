<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="ActivatMember.aspx.cs" Inherits="ActivatMember" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:Label ID="lbLoginID" runat="server" Text=""/>
        <br/><asp:Label ID="lbMsg1" runat="server" Text=""/>
        <br/><asp:Label ID="lbMsg2" runat="server" Text=""/>
        <br/><asp:TextBox ID="txtActivat" Width="300px" runat="server"/>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
        ErrorMessage="请输入验证码" Display="Dynamic" ControlToValidate="txtActivat"></asp:RequiredFieldValidator>
        <asp:HiddenField ID="HidMemberID" runat="server" />
        
        <asp:Button ID="btnActivat" runat="server" Text="激活" onclick="btnActivat_Click" />
        <br/><asp:Label ID="lbMsg3" runat="server" Text=""/>

</asp:Content>

