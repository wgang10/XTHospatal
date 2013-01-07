<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Print.aspx.cs" Inherits="Print" %>

<%@ Register src="WebUserControlEmployeeInfo.ascx" tagname="WebUserControlEmployeeInfo" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>西安体育学院教职工健康信息查询</title>
    <style type="text/css">
        body{font:75% Arial, Helvetica, Sans-Serif;
		color:#555;
		line-height:150%;
		margin:0;
		padding:0;
		text-align:center;
        }
        .ContentPrint{
		margin:0px auto 0px auto;
		width:600px;
		padding-left:20px;
		padding-top:0px;
		padding-bottom :0px;
		text-align:left;
		border:1px;
		border-style:dashed;
		}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="PrintContent" style="text-align:center;">
            <uc1:WebUserControlEmployeeInfo ID="WebUserControlEmployeeInfo1" runat="server" />
        </div>
    </form>
</body>
</html>
