<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="XTHospatalChangePassWord.aspx.cs" Inherits="ChangePassWord" Title="修改密码" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<div style="text-align:center;">
    <div id="DivLogin" style="text-align:center;">
        <div id="DivLoginID" class="DivChangePWD">
            <asp:Label ID="Label1" runat="server" Text="原始密码：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtOldPWD" runat="server" CssClass="Txt" MaxLength="18" 
                Width="250px" TextMode="Password" Font-Bold="True" Font-Italic="True" 
                Font-Size="15pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPWD"
                ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div id="DivLoginPwd" class="DivChangePWD" style="color: #555555">
            <asp:Label ID="Label2" runat="server" Text="修改密码：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtNewPWD" runat="server" CssClass="Txt" MaxLength="18" TextMode="Password"
                Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="15pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPWD"
                ErrorMessage="*"></asp:RequiredFieldValidator></div>
        <div id="DivValidate" class="DivChangePWD" style="color: #555555">
            <asp:Label ID="Label3" runat="server" Text="确认密码：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtConfirmNewPWD" runat="server" CssClass="Txt" MaxLength="18" 
                Width="250px" TextMode="Password" Font-Bold="True" Font-Italic="True" 
                Font-Size="15pt"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmNewPWD"
                ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;
        </div>
        
        <div id="Div2" class="DivChangePWD">
            <asp:Label ID="Label4" runat="server" Text="电话号码：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtEmployeePhone" runat="server" CssClass="Txt" MaxLength="50"
                Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="15pt"></asp:TextBox>
            </div>
        <div id="Div1" class="DivChangePWD">
            <asp:Label ID="Label5" runat="server" Text="电子邮箱：" Font-Bold="True" 
                Font-Italic="True" Font-Size="15pt"></asp:Label>
            <asp:TextBox ID="txtMail" runat="server" CssClass="Txt" MaxLength="50"
                Width="250px" Font-Bold="True" Font-Italic="True" Font-Size="15pt"></asp:TextBox>
            </div>
        <div id="DivTipsMessage">
            <asp:Literal ID="Literal1" runat="server" Text="电子邮箱用于找回密码，请认真填写，一经填写不可修改。"></asp:Literal>
        </div>
        <div id="DivLoginBtn">
            <asp:Button ID="btnSave" runat="server" CssClass="BTN" Text="确认" 
                OnClick="btnSave_Click" Font-Bold="True" Width="100px" />
            &nbsp;
            <asp:Button ID="btnCancel" runat="server" CssClass="BTN" Text="返回" 
                CausesValidation="False" OnClick="btnCancel_Click" Font-Bold="True" 
                Width="100px" /></div>
        <div id="DivLoginMessage">
            <asp:Literal ID="LiteralMsg" runat="server"></asp:Literal>
        </div>
    </div>
   </div> 
</asp:Content>

