<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="MemberManage.aspx.cs" Inherits="MemberManage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="tableborder" cellSpacing="1" cellPadding="5" width="100%" align=center>
              <tbody>
              <tr>
                <td class="header" colSpan="2" align="left">
                    会员管理 &nbsp; &nbsp; [双击可以进行查看详细信息]</td></tr>
              <tr>
                <td colspan="2" valign="top" class="altbg1"><div align="left">
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="LightGoldenrodYellow"
                        BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None"
                        Width="100%" DataKeyNames="ID" OnRowCommand="GridView1_RowCommand" OnRowDeleting="GridView1_RowDeleting" OnRowDataBound="GridView1_RowDataBound">
                        <FooterStyle BackColor="Tan" />
                        <Columns>
                            <asp:BoundField DataField="ID" HeaderText="编号">
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Email" HeaderText="邮箱" >
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Nickname" HeaderText="QQ" >
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Phone" HeaderText="电话" >
                                <ItemStyle HorizontalAlign="Left" />
                                <HeaderStyle HorizontalAlign="Left"/>
                            </asp:BoundField>
                            <asp:BoundField DataField="Type" HeaderText="类别" >
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Gender" HeaderText="性别" >
                                <ItemStyle HorizontalAlign="Center" Width="30px" />
                                <HeaderStyle HorizontalAlign="Center" Width="30px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LoginTimes" HeaderText="登陆次数" >
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>                            
                            <asp:BoundField DataField="Integral" HeaderText="积分" >
                                <ItemStyle HorizontalAlign="Center" Width="60px" />
                                <HeaderStyle HorizontalAlign="Center" Width="60px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Status" HeaderText="状态" >
                                <ItemStyle HorizontalAlign="Center" Width="50px" />
                                <HeaderStyle HorizontalAlign="Center" Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="LastLoginDateTime" HeaderText="上次登陆时间" >
                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CreateTime" HeaderText="创建时间" >
                                <ItemStyle HorizontalAlign="Left" Width="120px" />
                                <HeaderStyle HorizontalAlign="Left" Width="120px" />
                            </asp:BoundField>
                            <asp:ButtonField CommandName="Update" HeaderText="详细" Text="详细">
                                <ItemStyle HorizontalAlign="Right" Width="30px" />
                                <HeaderStyle HorizontalAlign="Right" Width="30px" />
                            </asp:ButtonField>
                            <asp:CommandField HeaderText="删除" ShowDeleteButton="True">
                                <HeaderStyle HorizontalAlign="Right" Width="30px" />
                                <ItemStyle HorizontalAlign="Right" Width="30px" />
                            </asp:CommandField>
                        </Columns>
                        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
                        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
                        <HeaderStyle BackColor="Tan" Font-Bold="True" />
                        <AlternatingRowStyle BackColor="PaleGoldenrod" />
                    </asp:GridView>
                </div></td>
                </tr>
              </tbody></table>
</asp:Content>

