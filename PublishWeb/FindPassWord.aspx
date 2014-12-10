<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="FindPassWord.aspx.cs" Inherits="FindPassWord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
    <!--
    function reloadcode(){
        document.getElementById('imgCode').src = 'CreateImgCode.aspx?' + Math.random();
    }
    -->
    </script>
    <div style="text-align:center;">
    <div id="DivLogin" style="text-align:center;">
        
        <div id="Div1" class="DivLogin">
            <asp:Label ID="Label2" runat="server" Text="邮箱：" Font-Bold="False" 
                Font-Italic="False" ForeColor="White"></asp:Label>
            <asp:TextBox ID="txtMail" runat="server" CssClass="Txt" MaxLength="50"
                Width="180px" Font-Bold="False" Font-Italic="False" Font-Overline="False"></asp:TextBox>
    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtMail"
        ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
        <div id="DivValidate" class ="DivValidateCode" style="vertical-align:bottom">
                <asp:Label ID="Label3" runat="server" Text="验证码：" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtValidateCode" runat="server" CssClass="Txt" MaxLength="4" 
                    Width="180px" Font-Bold="False" Font-Italic="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidateCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                <a href="javascript:reloadcode();" title="更换一张验证码图片"><img id="imgCode" style="padding-bottom:0px" src="CreateImgCode.aspx" border="0"  alt="看不清?请换一张" height="20" width="70"/></a> <a href="javascript:reloadcode();" title="看不清?请换一张"><span style="color:Blue">看不清?请换一张</span></a>
            </div>
        <div id="DivTipsMessage">
            <asp:Literal ID="Literal1" runat="server" Text="请输入您的邮箱地址，新密码将发送到您的邮箱。"></asp:Literal>
        </div>
        <div id="DivLoginBtn">
            <asp:Button ID="btnSave" runat="server" CssClass="BTN" Text="找回密码" 
                OnClick="btnSave_Click" Font-Bold="True" Width="100px" />
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:Button ID="btnCancel" runat="server" CssClass="BTN" Text="返回" 
                CausesValidation="False" OnClick="btnCancel_Click" Font-Bold="True" 
                Width="100px" /></div>
        <div id="DivLoginMessage">
            <asp:Literal ID="lbLoginMessage" runat="server"></asp:Literal>
        </div>
    </div>
   </div> 
</asp:Content>

