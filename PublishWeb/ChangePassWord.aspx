<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="ChangePassWord.aspx.cs" Inherits="ChangePassWord" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div style="text-align:center;">
        <div id="DivLogin" style="text-align:center; color:#ffffff">
            <div id="DivLoginID" class="DivChangePWD">
            <asp:Label ID="Label1" runat="server" Text="原始密码：" Font-Bold="False" 
                Font-Italic="False" ForeColor="White"></asp:Label>
            <asp:TextBox ID="txtOldPWD" runat="server" CssClass="Txt" MaxLength="18" 
                Width="180px" TextMode="Password" Font-Bold="False" Font-Italic="False"></asp:TextBox>
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtOldPWD"
                ErrorMessage="*"></asp:RequiredFieldValidator>
            </div>
            <div id="DivLoginPwd" class="DivChangePWD1" style="color:#ffffff">
                <asp:Label ID="Label2" runat="server" Text="新密码：" Font-Bold="False" 
                    Font-Italic="False" ForeColor="White"></asp:Label>
                <asp:TextBox ID="txtNewPWD" runat="server" CssClass="Txt" MaxLength="18" TextMode="Password"
                    Width="180px" Font-Bold="False" Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtNewPWD"
                    ErrorMessage="*"></asp:RequiredFieldValidator></div>
            <div id="DivValidate" class="DivChangePWD" style="color:#ffffff">
                <asp:Label ID="Label3" runat="server" Text="确认密码：" Font-Bold="False" 
                    Font-Italic="False" ForeColor="White"></asp:Label>
                <asp:TextBox ID="txtConfirmNewPWD" runat="server" CssClass="Txt" MaxLength="18" 
                    Width="180px" TextMode="Password" Font-Bold="False" Font-Italic="False"></asp:TextBox>
                <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtConfirmNewPWD"
                    ErrorMessage="*"></asp:RequiredFieldValidator>&nbsp;
            </div>
        
            <div id="DivTipsMessage" style="color:#ffffff">
                <asp:Literal ID="Literal1" runat="server"></asp:Literal>
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

