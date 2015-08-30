<%@ Page Language="C#" %>

<!DOCTYPE html>

<script runat="server">

</script>

<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
<title></title>
<link href="style/login.css" rel="stylesheet" />
    <script src="../../../Scripts/jquery.v1.11.js"></script>
       <script src="../../../Scripts/jquery.unobtrusive-ajax.js"></script>
    <script src="../../../layer/layer.js"></script>
    <script src="../../../Scripts/Common.js"></script>
    <style>        #mes {    color:tomato; 
        }
       #Loading {
               background-position: center left;
    background-image: url('../images/loading.gif'); /*cross_octagon*/
    background-repeat: no-repeat;
    cursor: pointer;     padding-left:34px;
    display: inline-block;    height:31px;
        }
    </style>
</head>
<body style="background:url(images/login_bg.jpg) no-repeat center top;">
<div class="login">
  <div class="login_main">
    <div class="name">XXXXXXXXXXXXXX管理系统</div>
    <div style="float:left; margin:20px 0 0 20px;"><%--<img src="images/zzlogo.png">--%></div>
    <div class="denglu">
        <form action="/user/login" method="post" data-ajax="true"  data-ajax-loading="#loading" >
      <ul>
        <li><span class="font1">账户登录</span><span class="font2">Login in</span></li>
        <li>
          <input id="UserName" name="UserName" type="text" class="nm" placeholder="请输入用户名" />
        </li>
        <li>
          <input type="password" id="Password" name="Password" class="key" placeholder="请输入密码" />
        </li>
        <li>
          <input type="text"  name="ValidateCode" id="ValidateCode" class="yzm" placeholder="请输入验证码" />
           <img id="codeImg" alt="刷新验证码！" style="margin-bottom: -8px; cursor: pointer;" src="verify_code.ashx" onclick="this.src=this.src+'?'" />
           <a href="javascript:$('#codeImg').trigger('click').void(0)"> 刷新</a>
        </li>
        
        <li style="padding-top: 10px;">   

            <input id="Submit1" type="image" src="images/button_login.png" value="submit" style="width: 124px;height: 39px; padding-left: 0px;border: solid 0px #dadada;" />                            
           </li>                                    
      </ul> </form>
    </div>
    <div class="copy"> CopyRight © 2015 </div>
  </div>
</div>
     <div id="loading" style="display:none;"><p>
            加载中....
        </p> </div>
</body>
   
</html>
