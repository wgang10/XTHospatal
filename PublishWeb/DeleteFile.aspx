<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="DeleteFile.aspx.cs" Inherits="DeleteFile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <asp:TextBox ID="txtFileName" runat="server" Width="300px"></asp:TextBox>
    <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="查找" Width="80px" />
    <asp:TextBox ID="txtFilePath" runat="server" Width="300px"></asp:TextBox>
    <br />
    <asp:TextBox ID="txtVerification" runat="server"></asp:TextBox>
    <asp:Button ID="btnDelateFile" runat="server" OnClick="btnDelate_Click" Text="删除文件" Width="80px" />
    <asp:Button ID="btnDeleteFolder" runat="server" OnClick="btnDeleteFolder_Click" Text="删除文件夹" />
    <br />
    <asp:Label ID="lbMessage" runat="server" ForeColor="Red" Text="Label"></asp:Label>

</asp:Content>

