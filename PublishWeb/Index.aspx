<%@ Page Title="子扬软件" Language="C#" MasterPageFile="~/MasterPageZiYang.master" AutoEventWireup="true" CodeFile="Index.aspx.cs" Inherits="Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <script type="text/javascript">
        var _gaq = _gaq || [];
        _gaq.push(['_setAccount', 'UA-8272227-1']);
        _gaq.push(['_setDomainName', 'dbank.com']);
        _gaq.push(['_trackPageview']);
        (function () {
            var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
            ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
            var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
        })();

        //无插件 banner切换效果
        $(function () {
            //获取可点触发编号
            $('#bannerTextBox').find('li').mouseover(function () {
                //停止自动切换
                clearInterval(t1);
                //获取编号自定义值 以获取对应图片
                var i = $(this).attr('set');
                //调用切换效果，切换到当前鼠标焦点编号的banner
                changeBanner('x', i);
                //设置当前编号的颜色 
                setListNo.apply(this, ['x']);
            }).mouseout(function () {
                //鼠标离开编号 自动开始继续切换
                t1 = setInterval(changeBanner, '3000');
            })
            //定义可触发编号 该变量用来自动切换过程中累加计算 用于判断是否到达最好一个banner位置
            var bannerListIndex = 1;

            //设置编号 参数setNo 用来判断方法是setInterval自动触发的还是 mouseover手动触发
            function setListNo(setNo) {
                //清空历史的选中位置
                $('#bannerTextBox').find(".thisHover").removeClass('thisHover');
                //如果是setInterval自动触发
                if (setNo != "x") {
                    //通过 定义可触发编号bannerListIndex 累加参数判断选中位置
                    $('#bannerTextBox').find("li").eq(setNo).addClass("thisHover");
                }
                    //如果是手动触发
                else {
                    //通过设置当前鼠标点击对象设置 选中位置
                    $(this).addClass("thisHover");
                }
            }

            //切换方法 参数o 用来判断是否是手动出发  i 用来记录手动出发位置，以便真确定义显示图片
            function changeBanner(o, i) {
                $("#bannerImgesBox").find('a').hide();
                if (o != 'x') {
                    setListNo(bannerListIndex);
                    $("#bannerImgesBox").find('a').eq(bannerListIndex).fadeIn("slow");
                } else {

                    $("#bannerImgesBox").find('a').eq(i).fadeIn("slow");
                    bannerListIndex = i;
                }
                // 累加bannerListIndex 于判断是否到达最后一个banner位置 
                bannerListIndex++;
                if (bannerListIndex > 4) {
                    bannerListIndex = 0
                }
            }
            //changeBanner();
            var t1 = setInterval(changeBanner, '3500');
        })
</script>
    <div class="introbg">
        <div class="leftkg">
            <div class="moviekg">
                <div id="barScroll" class="mrwm_slide">
                    <div id="bannerBox">
                        <div id="bannerImgesBox"> 
                            <a href="Default.aspx" target="_blank" style="display:block;"><img src="images/banner/1.jpg"></a> 
                            <a href="Default.aspx" target="_blank"><img src="images/banner/2.jpg"/></a>
                            <a href="#"><img src="images/banner/3.jpg"/></a> 
                         </div>
                         <div id="bannerTextBox">
                            <ul>
                                <li class="thisHover" set="0"><a href="###">1</a></li>
                                <li set="1"><a href="###">2</a></li>
                                <li set="2"><a href="###">3</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <div class="noticekg">
                <span class="notice"><a title="最新新闻" href="#/">最新新闻</a></span> 
                    <ul runat="server" id="ulNews">
                    </ul>
             </div>
        </div> 
        <div class="regkg" runat="server" id="divRegiste" visible="true">
            <ul>
              <li>
                  <div class="btlist">
                                <div class="btctn">
                                    <ul>
                                      <LI class="wd1"><a href="Default.aspx" target="_blank"><IMG title="点击进入系统" src="images/icon1.png"></a> </li>
                                      <LI class="wd2"><a href="Default.aspx" target="_blank" title="点击进入系统"><FONT class="font14wz b"><strong> 健康体检信息管理系统</strong></FONT></a>
                                          <BR>
                                          <font style="color:#ffffff">本产品在2009年专门为西安体育学院运动创伤医院开发。一直沿用至今，在5年多时间中不断完善和加强，已经成为一个非常成熟的健康信息管理系统。为西安体院每年的健康体检信息管理做出了巨大的贡献。</font>
                                      </li>
                                    </ul>
                                    <!--
                                    <ul>
                                        <LI class="wd1"><a href="#"><IMG title=WMS仓库/贩卖管理系统 alt=MS仓库/贩卖管理系统 src="images/icon2.png"></a> </li>
                                        <LI class="wd2"><a href="#"><FONT class="font14wz b">MS仓库/贩卖管理系统</FONT><BR>WMS是仓库管理系统(Warehouse Management System) 的缩写，仓库管理系统是通过入库业务、出库业务、仓库调拨、库存调拨和虚仓管理等功能，综合批次管理、物料对应、库存盘点、质检管理、虚仓管理和即时库存管理等功能综合运用的管理系统，有效控制并跟踪仓库业务的物流和成本管理全过程，实现完善的企业仓储信息管理。该系统可以独立执行库存操作，与其他系统的单据和凭证等结合使用，可提供更为完整全面的企业业务流程和财务管理信息。</a> </li>
                                    </ul>
                                    -->
                                    <ul>
                                      <LI class="wd1"><a href="#"><IMG title="运动会报名系统" src="images/icon3.png"></a> </li>
                                      <LI class="wd2"><a href="#" title="运动会报名系统"><FONT class="font14wz b">运动会报名系统</FONT></a>
                                          <BR>
                                          <font style="color:#ffffff">运动会报名管理系统使运动会报名的管理模式从手工方式转变成信息管理，为报名管理人员提供方便条件。本系统对各类运动会报名的实际情况进行调研之后，进行详细的需求分析，对现有的管理模式进行改进，开发出一套新型的管理系统。系统可以围绕运动会工作的实际情况，使之能迅速适应运动会报名、编排、执行、统计、信息发布等需要。</font>
                                      </li>
                                    </ul>
						        </div>
					        </div>
              </li>
            </ul>
        </div>
    </div>
</asp:Content>

