﻿<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<%@ Register src="WebUserControlEmployeeInfo.ascx" tagname="WebUserControlEmployeeInfo" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>西安体育学院教职工健康信息查询</title>	
	<meta http-equiv="content-type" content="text/html;charset=UTF-8" /> 
    <style type="text/css">
        body
        {background:#d8e6ec url(../images/bg_body.gif) repeat-x;
        font:80% Arial, Helvetica, Sans-Serif;
		color:#555;
		line-height:150%;
		margin:0;
		padding:0;
		text-align:center;
        }
        .ContentPrint{
		margin:0px auto 0px auto;
		width:820px;
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


<div id="container">
	<div id="header">
	    <div id="Links">
		    <a href="ChangePassWord.aspx">修改密码</a>
		    <a href="LogOut.aspx">退出系统</a>
		</div>
	</div>
    
    <div id="content" style="text-align:center;">
	    <uc1:WebUserControlEmployeeInfo ID="WebUserControlEmployeeInfo1" runat="server" />
    </div>
    <div id="footer">
		    版权所有©西安运动创伤医院 技术支持：<a href="http://www.shangmeisi.com/" target="_blank">尚美思</a>
	</div>	
</div>


    </form>


</body>
</html>

