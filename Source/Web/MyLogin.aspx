<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="MyLogin.aspx.cs" Inherits="MyLogin" Title="西安体育学院教职工健康信息查询" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<script type="text/javascript">
    <!--
    function reloadcode(){
    document.getElementById('imgCode').src = 'CreateImgCode.aspx?' + Math.random();
    }
    -->
</script>
<div style="text-align:center;">
<div id="DivLogin">
<div id="DivLoginID" class ="DivLogin">
    <asp:Label ID="Label1" runat="server" Text="账号：" Font-Bold="True" 
        Font-Size="15pt" Font-Italic="True"></asp:Label>
    <asp:TextBox ID="txtLoginID" runat="server" CssClass="Txt" MaxLength="10" 
        Width="150px" Font-Bold="True" Font-Size="15pt" Font-Italic="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginID"
        ErrorMessage="*"></asp:RequiredFieldValidator></div>
<div id="DivLoginPwd" class ="DivLogin">
    <asp:Label ID="Label2" runat="server" Text="密码：" Font-Bold="True" 
        Font-Size="15pt" Font-Italic="True"></asp:Label>
    <asp:TextBox ID="txtPWD" runat="server" CssClass="Txt" MaxLength="20" 
        Width="150px" TextMode="Password" Font-Bold="True" Font-Size="15pt" 
        Font-Italic="True"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPWD"
        ErrorMessage="*"></asp:RequiredFieldValidator></div>
<div id="DivValidate" class ="DivValidateCode" style="vertical-align:bottom">
    <asp:Label ID="Label3" runat="server" Text="验证码：" Font-Bold="True" 
        Font-Size="15pt" Font-Italic="True"></asp:Label>
    <asp:TextBox ID="txtValidateCode" runat="server" CssClass="Txt" MaxLength="4" 
        Width="150px" Font-Bold="True" Font-Size="15pt" Font-Italic="True" />
    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidateCode" ErrorMessage="*"></asp:RequiredFieldValidator>
    <a href="javascript:reloadcode();" title="更换一张验证码图片"><img id="imgCode" style="padding-bottom:0px" src="CreateImgCode.aspx" border="0"  alt="看不清?请换一张" height="20" width="70"/></a> <a href="javascript:reloadcode();" title="看不清?请换一张"><span style="color:Blue">看不清?请换一张</span></a>
</div>
<div id="Div1" class ="DivLoginB">
    <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="BTN" 
        OnClick="btnLogin_Click" Font-Bold="True" Width="100px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
    <asp:Button ID="btnFindPassWord" runat="server" Text="忘记密码" CssClass="BTN" 
        OnClick="btnFindPassWord_Click" CausesValidation="False" Font-Bold="True" 
        Width="100px" /></div>
<div id="DivLoginMessage">
    <asp:Literal ID="LiteralMsg" runat="server"></asp:Literal>
</div>
<div id="DivDirections">
    <asp:Literal ID="Literal2" runat="server" Text="提示：账号为体检编号，初始密码为身份证号码。<br>登录后请及时修改密码，并绑定邮箱。尽可能填写电话以方便联系。"></asp:Literal>
</div>
</div>
</div>
</asp:Content>

