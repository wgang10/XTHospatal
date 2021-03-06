﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="MemberInfo.aspx.cs" Inherits="MebmerInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="regkg1">        
        <br/><asp:Image ID="imgPhoto" runat="server" />
        <br/><br/><asp:Label ID="lbNickname" runat="server" Text=""/>
        <br/><asp:Label ID="lbLoginID" runat="server" Text=""/>
        <br/><asp:Label ID="lbLoginTimes" runat="server" Text=""/>
        <br/><asp:Label ID="lbLastLoginDateTime" runat="server" Text=""/>
        <br/><asp:Label ID="lbIntegral" runat="server" Text=""/>
        <br/><asp:Label ID="lbBindQQ" runat="server" Text=""/>
        <br/><asp:Button ID="btnUnBindQQ" Visible="false" runat="server" Text="解除绑定QQ" OnClick="btnUnBindQQ_Click" />
        <asp:Button ID="btnChangeBindQQ" Visible="false" runat="server" Text="绑定其他QQ" OnClick="btnChangeBindQQ_Click"  />
        <br/><asp:Label ID="lbMessageMember" runat="server" Text=""/>
        <div id="divBindEmail" runat="server" visible="false">
            <br/><strong>请绑定您的邮箱</strong>
            <br/>
            <asp:RadioButton ID="rdbNotExist" runat="server" Text="没有网站账号" 
                AutoPostBack="True" Checked="True" 
                oncheckedchanged="rdbNotExist_CheckedChanged" GroupName="Exist" />
            <asp:RadioButton ID="rdbExist" runat="server"  Text="已有网站账号" 
                AutoPostBack="True" oncheckedchanged="rdbExist_CheckedChanged" 
                GroupName="Exist"/>
            <br/><asp:Label ID="lbEmail" runat="server" Text="邮箱地址:"/>
            <asp:TextBox ID="txtEmail" Width="150px" runat="server" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                ControlToValidate="txtEmail" Display="Dynamic" ErrorMessage="请输入正确的邮箱地址" 
                ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
            <br/><asp:Label ID="lbPassWord" runat="server" Text="设置密码:"/>
            <asp:TextBox ID="txtPassWord" Width="150px" runat="server" 
                TextMode="Password" />
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                ControlToValidate="txtPassWord" Display="Dynamic" ErrorMessage="*"></asp:RequiredFieldValidator>
            <br/><asp:Button ID="btnBindEmail" Width="80px" runat="server" Text="绑定账号" OnClick="btnBindEmail_Click" />
        </div>
        <div id="divBingQQ" runat="server" visible="false">
            <br/><strong>绑定QQ账号</strong>
            <br/>绑定QQ后你可使用QQ账号快速登录网站
            <br/><a href="https://graph.qq.com/oauth2.0/authorize?response_type=code&client_id=100289171&redirect_uri=www.ziyangsoft.com/BindingToQQ.aspx&scope=get_user_info,do_like&state=115039554">
                立刻绑定</a>
        </div>
        <br/><asp:Label ID="lbMessage" runat="server" Visible="false" ForeColor="White" BackColor="Red" />        
    </div>
</asp:Content>

