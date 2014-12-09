<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="Login" %>

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
                <asp:Label ID="Label1" runat="server" Text="账号：" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtLoginID" runat="server" CssClass="Txt" MaxLength="30" 
                    Width="180px" Font-Bold="False" Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtLoginID"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
            <div id="DivLoginPwd" class ="DivLogin">
                <asp:Label ID="Label2" runat="server" Text="密码：" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtLoginPWD" runat="server" CssClass="Txt" MaxLength="30" 
                    Width="180px" TextMode="Password" Font-Bold="False" 
                    Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtLoginPWD"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
            <div id="DivValidate" class ="DivValidateCode" style="vertical-align:bottom">
                <asp:Label ID="Label3" runat="server" Text="验证码：" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtValidateCode" runat="server" CssClass="Txt" MaxLength="4" 
                    Width="180px" Font-Bold="False" Font-Italic="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidateCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                <a href="javascript:reloadcode();" title="更换一张验证码图片"><img id="imgCode" style="padding-bottom:0px" src="CreateImgCode.aspx" border="0"  alt="看不清?请换一张" height="20" width="70"/></a> <a href="javascript:reloadcode();" title="看不清?请换一张"><span style="color:Blue">看不清?请换一张</span></a>
            </div>
            <div id="Div1" class ="DivLoginB">
                <asp:Button ID="btnLogin" runat="server" Text="登录" CssClass="BTN" 
                     OnClick="btnLogin_Click" Font-Bold="True" Width="100px" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                <asp:Button ID="btnFindPassWord" runat="server" Text="忘记密码" CssClass="BTN" 
                     OnClick="btnFindPassWord_Click" CausesValidation="False" Font-Bold="True" 
                    Width="100px" />
                <a href="https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=100289171&redirect_uri=www.ziyangsoft.com&scope=get_user_info,do_like&state=115039554">
					        <img alt="使用QQ账号登陆" style="float:none; MARGIN:0px 0px 0px 10px" src="images/Connect_logo_3.png" /></a>
            </div>
            <div id="DivLoginMessage">
                <asp:Literal ID="lbLoginMessage" runat="server"></asp:Literal>
            </div>
            <div id="DivDirections" style="color:#ffffff">
                <asp:Literal ID="Literal2" runat="server" Text="提示：首次登陆成功后请进一步完善资料。<br>定期修改密码是保证账号安全的一个有效措施。"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>

