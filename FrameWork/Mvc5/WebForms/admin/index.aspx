<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Mvc5.WebForms.admin.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
    <script src="/Scripts/jquery-1.10.2.js"></script>
    <script src="../../easyUI/jquery.easyui.min.js"></script>
    <link href="../../easyUI/themes/default/easyui.css" rel="stylesheet" />
    <link href="../../easyUI/themes/icon.css" rel="stylesheet" />
    <script src="../../easyUI/locale/easyui-lang-zh_CN.js"></script>
    <script src="js/XiuCai.index.js"></script>
    <link href="css/default.css" rel="stylesheet" />
    <script src="../../layer1.9.0/layer.js"></script>
    <script src="../../Scripts/Common.js"></script>
    <script type="text/javascript">
        var _menus = {
            "menus": [

                   {
                       "menuid": "560",
                       "icon": "icon-sys",
                       "menuname": "基本资料",
                       "menus": [{
                           "menuid": "310",
                           "menuname": "客户列表",
                           "icon": "icon-nav",
                           "url": "customer.aspx"
                       },
                       {
                           "menuid": "21",
                           "menuname": "收货方",
                           "icon": "icon-nav",
                           "url": "/shop/index"
                       }
                       ,
                        {
                            "menuid": "3220",
                            "menuname": "商品资料",
                            "icon": "icon-nav",
                            "url": "aboutadd.aspx?specid=1"
                        },
                         {
                             "menuid": "3220",
                             "menuname": "包规资料",
                             "icon": "icon-nav",
                             "url": "aboutadd.aspx?specid=1"
                         },
                          {
                              "menuid": "3220",
                              "menuname": "分类管理",
                              "icon": "icon-nav",
                              "url": "Category.aspx"
                          }
                          ,
                          {
                              "menuid": "3220",
                              "menuname": "站点信息",
                              "icon": "icon-nav",
                              "url": "aboutadd.aspx?specid=1"
                          }

                       ]
                   },


                {
                    "menuid": "1",
                    "icon": "icon-sys",
                    "menuname": "单据管理",
                    "menus": [

                {
                    "menuid": "141",
                    "menuname": "订单作业",
                    "icon": "icon-basket",
                    "url": "prolist.aspx"
                }
                   

                    ]
                },
            {
                "menuid": "56",
                "icon": "icon-sys",
                "menuname": "相关报表",
                "menus": [{
                    "menuid": "31",
                    "menuname": "运输费用报表",
                    "icon": "icon-nav",
                    "url": "aboutlist.aspx?specid=1"
                },
                 {
                     "menuid": "322",
                     "menuname": "库存报表",
                     "icon": "icon-nav",
                     "url": "aboutadd.aspx?specid=1"
                 },
               
                 {
                     "menuid": "322",
                     "menuname": "出入库明细",
                     "icon": "icon-nav",
                     "url": "aboutadd.aspx?specid=1"
                 },
              
                 {
                     "menuid": "322",
                     "menuname": "储位费用报表",
                     "icon": "icon-nav",
                     "url": "aboutadd.aspx?specid=1"
                 }]
            },
                 {
                     "menuid": "56",
                     "icon": "icon-sys",
                     "menuname": "配送设置",
                     "menus": [{
                         "menuid": "31",
                         "menuname": "司机管理",
                         "icon": "icon-nav",
                         "url": "aboutlist.aspx?specid=2"
                     },
                      {
                          "menuid": "322",
                          "menuname": "车辆管理",
                          "icon": "icon-nav",
                          "url": "aboutadd.aspx?specid=2"
                      }]
                 },
              {
                  "menuid": "56",
                  "icon": "icon-sys",
                  "menuname": "系统设置",
                  "menus": [{
                      "menuid": "31",
                      "menuname": "用户管理",
                      "icon": "icon-nav",
                      "url": "./user/userlist.aspx"
                  },
                  {
                      "menuid": "321",
                      "menuname": "角管理",
                      "icon": "icon-nav",
                      "url": "./user/role.aspx"
                  }]
              }
               
            ]
        };

        //设置登录窗口
        function openPwd() {
            $('#w').window({
                title: '修改密码',
                width: 300,
                modal: true,
                shadow: true,
                closed: true,
                height: 160,
                resizable: false
            });
        }
        //关闭登录窗口
        function closePwd() {
            $('#w').window('close');
        }

        $(function () {
            openPwd();

            $('#editpass').click(function () {
                $('#w').window('open');
            });

            $('#btnCancel').click(function () { closePwd(); })

        });



    </script>
    
</head>

<body class="easyui-layout" style="overflow-y: hidden" fit="true" scroll="no">
    <noscript>
<div style=" position:absolute; z-index:100000; height:2046px;top:0px;left:0px; width:100%; background:white; text-align:center;">
    <img src="images/noscript.gif" alt='抱歉，请开启脚本支持！' />
</div></noscript>

    <div id="loading-mask" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; background: #D2E0F2; z-index: 20000">
        <div id="pageloading" style="position: absolute; top: 50%; left: 50%; margin: -120px 0px 0px -120px; text-align: center; border: 2px solid #8DB2E3; width: 200px; height: 40px; font-size: 14px; padding: 10px; font-weight: bold; background: #fff; color: #15428B;">
            <img src="images/loading.gif" align="absmiddle" />
            正在加载中,请稍候...
        </div>
    </div>

    <div region="north" split="true" border="false" style="overflow: hidden; height: 30px; background: url(images/layout-browser-hd-bg.gif) #7f99be repeat-x center 50%; line-height: 20px; color: #fff; font-family: Verdana, 微软雅黑,黑体">
        <span style="float: right; padding-right: 20px;" class="head">当前用户: ,
             <a href="#" id="editpass">修改密码</a>   &nbsp;&nbsp;&nbsp;
            <a href="/user/loginOut" data-ajax="true"  data-ajax-confirm="您确定要退出本次登录吗？"   data-ajax-method="get"   id="loginOut">安全退出</a></span>
        <span style="padding-left: 10px; font-size: 16px;">
            <img src="images/blocks.gif" width="20" height="20" align="absmiddle" />
            XXXXXXXXXX管理系统</span>
    </div>
 <%--   <div region="south" split="true" style="height: 30px; background: #D2E0F2;">
        <div class="footer">By MingSoft</div>
    </div>--%>
    <div region="west" split="true" title="导航菜单" style="width: 180px;" id="west">
        <div id="nav">
            <!--  导航内容 -->

        </div>

    </div>
    <div id="mainPanle" region="center" style="background: #eee; overflow-y: hidden">
        <div id="tabs" class="easyui-tabs" fit="true" border="false" data-options="
                    tools:[  {iconCls : 'icon-arrow_refresh',text:'刷新',handler:refreshTab},
                    {iconCls : 'icon-delete3',text:'关闭全部',handler:closeTab2}   ]">
            <div title="欢迎使用" style="padding: 20px; overflow: hidden; color: tomato; font-size: larger; line-height: 40px;">

                <h1 style="font-size: 35px; letter-spacing: 5px;">歡迎使用XXXXXXXXXXX管理系統</h1>
                <p style="font-size: 20px; color: black;">推薦使用Google Chrome瀏覽器,電腦分辨率推薦：1366 x 786.</p>
                <p style="font-size: 20px; color: black;">如使用中有任何問題，請聯繫XXXXXXXXX，電話：XXXXXXXXXXXXX</p>
                <%--    <iframe  id="child5" frameborder="0"  src="iischeck.aspx" style="width: 100%;"  onload="javascript:{dyniframesize(this);}"></iframe>--%>
            </div>
        </div>
    </div>


    <!--修改密码窗口-->
    <div id="w" class="easyui-window" title="修改密码" collapsible="false" minimizable="false"
        maximizable="false" icon="icon-save" style="width: 300px; height: 150px; padding: 5px; background: #fafafa;">
        <div class="easyui-layout" fit="true">
           <form id="form2" action="/user/ChangePassword" method="get" data-ajax="true"  data-ajax-success="closePwd"  data-ajax-loading="#loading">  
             
             <div region="center" border="false" style="padding: 10px; background: #fff; border: 1px solid #ccc;">
                <table cellpadding="3">
                    <tr>
                        <td>新密码：</td>
                        <td>
                            <input name="pw" type="Password" class="txt01" /></td>
                    </tr>
                    <tr>
                        <td>确认密码：</td>
                        <td>
                            <input name="pw2" type="Password" class="txt01" /></td>
                    </tr>
                </table>
            </div>
        

            <div region="south" border="false" style="text-align: right; height: 30px; line-height: 30px;">
              <a id="btnEp" class="easyui-linkbutton" onclick="$('#form2').submit()" icon="icon-ok" href="javascript:void(0)">确定</a>
 <%--               <input type="submit" class="easyui-linkbutton" icon="icon-ok"  value="确定" />--%>
                 <a id="btnCancel" class="easyui-linkbutton" icon="icon-cancel" href="javascript:void(0)">取消</a>
            </div>     

           </form>
        </div>
    </div>

    <div id="mm" class="easyui-menu" style="width: 150px;">
        <div id="tabupdate">刷新</div>
        <div class="menu-sep"></div>
        <div id="close">关闭</div>
        <div id="closeall">全部关闭</div>
        <div id="closeother">除此之外全部关闭</div>
        <div class="menu-sep"></div>
        <div id="closeright">当前页右侧全部关闭</div>
        <div id="closeleft">当前页左侧全部关闭</div>
        <div class="menu-sep"></div>
        <div id="exit">退出</div>
    </div>

      <div id="loading" style="display:none;"><p>
            加载中....
        </p> </div>
  
</body>
</html>
