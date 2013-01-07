<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="FindPassWord.aspx.cs" Inherits="FindPassWord" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center;">
    <div id="DivLogin" style="text-align:center;">
        
        <div id="Div2" class="DivLogin">
            <asp:Label ID="Label1" runat="server" Text="账号：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>

            <asp:TextBox ID="txtLoginID" runat="server" CssClass="Txt" MaxLength="50"
                Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="15pt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginID"
        ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        <div id="Div1" class="DivLogin">
            <asp:Label ID="Label2" runat="server" Text="邮箱：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtMail" runat="server" CssClass="Txt" MaxLength="50"
                Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="15pt"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMail"
        ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        <div id="DivTipsMessage">
            <asp:Literal ID="Literal1" runat="server" Text="请输入您的账号和原先绑定的邮箱，密码将发送到您已绑定的邮箱。"></asp:Literal>
        </div>
        <div id="DivLoginBtn">
            <asp:Button ID="btnSave" runat="server" CssClass="BTN" Text="找回密码" 
                OnClick="btnSave_Click" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" CssClass="BTN" Text="返回" 
                CausesValidation="False" OnClick="btnCancel_Click" Font-Bold="True" 
                Width="100px" /></div>
        <div id="DivLoginMessage">
            <asp:Literal ID="LiteralMsg" runat="server"></asp:Literal>
        </div>
    </div>
   </div> 
</asp:Content>

