<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

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
                <asp:Label ID="Label1" runat="server" Text="昵称：" Font-Bold="False" Font-Italic="False" ForeColor="White"></asp:Label>
                <asp:TextBox ID="txtNickName" runat="server" CssClass="Txt" MaxLength="10" 
                    Width="180px" Font-Bold="False" Font-Size="12pt" Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtNickName"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
            <div id="DivLoginMail" class ="DivLogin">
                <asp:Label ID="Label4" runat="server" Text="邮箱：" Font-Bold="False" Font-Italic="False" ForeColor="White"></asp:Label>
                <asp:TextBox ID="txtEmail" runat="server" CssClass="Txt" MaxLength="30" 
                    Width="180px" Font-Bold="False" Font-Size="12pt" Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="*"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请输入正确的邮箱地址" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            </div>
            <div id="DivLoginPwd" class ="DivLogin">
                <asp:Label ID="Label2" runat="server" Text="密码：" Font-Bold="False" Font-Italic="False" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtPassWord" runat="server" CssClass="Txt" MaxLength="20" 
                    Width="180px" TextMode="Password" Font-Bold="False" Font-Size="12pt" 
                    Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtPassWord"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>

            <div id="DivPassword2" class ="DivPassword2">
                <asp:Label ID="Label5" runat="server" Text="确认密码：" Font-Bold="False" Font-Italic="False" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtPassWordVerify" runat="server" CssClass="Txt" MaxLength="20" 
                    Width="180px" TextMode="Password" Font-Bold="False" Font-Size="12pt" 
                    Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtPassWordVerify"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
            <div id="DivValidate" class ="DivValidateCode" style="vertical-align:bottom">
                <asp:Label ID="Label3" runat="server" Text="验证码：" Font-Bold="False" Font-Italic="False" ForeColor="Wheat"></asp:Label>
                <asp:TextBox ID="txtValidateCode" runat="server" CssClass="Txt" MaxLength="4" 
                    Width="180px" Font-Bold="False" Font-Size="12pt" Font-Italic="False" />
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtValidateCode" ErrorMessage="*"></asp:RequiredFieldValidator>
                <a href="javascript:reloadcode();" title="更换一张验证码图片"><img id="imgCode" style="padding-bottom:0px" src="CreateImgCode.aspx" border="0"  alt="看不清?请换一张" height="20" width="70"/></a> <a href="javascript:reloadcode();" title="看不清?请换一张"><span style="color:Blue">看不清?请换一张</span></a>
            </div>
            <div id="Div1" class ="DivLoginB">
                <asp:Button ID="btnRegister" runat="server" Text="注册" CssClass="BTN" 
                      OnClick="btnRegister_Click" Font-Bold="True" Width="100px" />
            </div>
            <div id="DivLoginMessage">
                <asp:Literal ID="lbRegisterMsg" runat="server"></asp:Literal>
            </div>
            <div id="DivDirections" style="color:#ffffff">
                <asp:Literal ID="Literal2" runat="server" Text="《服务协议》<br>进一步完善资料"></asp:Literal>
            </div>
        </div>
    </div>
</asp:Content>

