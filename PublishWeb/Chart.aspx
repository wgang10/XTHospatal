<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Chart.aspx.cs" Inherits="_Chart" %>

<%@ Register assembly="System.Web.DataVisualization, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    本金<asp:TextBox ID="txtBenjin" runat="server">50000</asp:TextBox>
        年利率<asp:TextBox ID="txtLiLv" runat="server">0.18</asp:TextBox>
        时间<asp:TextBox ID="txtTime" runat="server">10</asp:TextBox>
        每年追加<asp:TextBox ID="txtAdd" runat="server">50000</asp:TextBox>
        复利次数<asp:TextBox ID="txtTimesOfYear" runat="server">1</asp:TextBox>
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="计算" Height="53px" Width="198px" />
        <br />
        回报<asp:TextBox ID="txtHuibao" runat="server"></asp:TextBox>
        <br />
        投入<asp:TextBox ID="txtTouRu" runat="server"></asp:TextBox>
        <br />
        利息<asp:TextBox ID="txtLiXi" runat="server"></asp:TextBox>
        <br />
        <asp:Chart ID="chart2" runat="server" Width="816px">
            <Legends>
                <asp:Legend Name="Legend1">
                </asp:Legend>
            </Legends>
            <series>
                <asp:Series Legend="Legend1" Name="Series1">
                </asp:Series>
            </series>
            <chartareas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </chartareas>
        </asp:Chart>
        <br />
        <br />
        <asp:GridView ID="dataGridView1" runat="server" Width="735px">
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
