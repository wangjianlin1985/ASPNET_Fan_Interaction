<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Admin_Left.aspx.cs" Inherits="WebSystem.Admin.Admin_Left" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title></title>
    <link href="Style/Manage.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="JavaScript/Jquery.js"></script>
    <script src="JavaScript/Admin.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div class="LeftNote">
    <img src="Images/MenuTop.jpg"/><br /><img src="images/menu_topline.gif" alt=""/>
    
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;用户管理</div>
        <div class="MenuNote" style="display:none;" id="UserInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="UserInfoEdit.aspx" target="main">添加球星</a></li>
                <li><a href="UserInfoList.aspx" target="main">用户查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;球星关注管理</div>
        <div class="MenuNote" style="display:none;" id="StarFollowDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="StarFollowEdit.aspx" target="main">添加球星关注</a></li>
                <li><a href="StarFollowList.aspx" target="main">球星关注查询</a></li> 
            </ul>
        </div>
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;帖子相关</div>
        <div class="MenuNote" style="display:none;" id="PostInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="PostInfoEdit.aspx" target="main">添加帖子</a></li>
                <li><a href="PostInfoList.aspx" target="main">帖子查询</a></li> <!--
                 <li><a href="ReplyEdit.aspx" target="main">添加帖子回复</a></li>
                <li><a href="ReplyList.aspx" target="main">帖子回复查询</a></li> 
                <li><a href="ThumbsUpEdit.aspx" target="main">添加点赞</a></li>
                <li><a href="ThumbsUpList.aspx" target="main">点赞查询</a></li> -->
            </ul>
        </div>

        <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;回复点赞管理</div>
        <div class="MenuNote" style="display:none;" id="Div1" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL"> 
                 <li><a href="ReplyEdit.aspx" target="main">添加帖子回复</a></li>
                <li><a href="ReplyList.aspx" target="main">帖子回复查询</a></li> 
                <li><a href="ThumbsUpEdit.aspx" target="main">添加点赞</a></li>
                <li><a href="ThumbsUpList.aspx" target="main">点赞查询</a></li> 
            </ul>
        </div>

          
         
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;商品管理</div>
        <div class="MenuNote" style="display:none;" id="ProductClassDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="ProductClassEdit.aspx" target="main">添加商品类别</a></li>
                <li><a href="ProductClassList.aspx" target="main">商品类别查询</a></li> 
                 <li><a href="ProductEdit.aspx" target="main">添加商品</a></li>
                <li><a href="ProductList.aspx" target="main">商品查询</a></li> 
            </ul>
        </div>
          
          <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;订单管理</div>
        <div class="MenuNote" style="display:none;" id="OrderInfoDiv" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
             <li><a href="OrderInfoEdit.aspx" target="main">添加订单</a></li>
                <li><a href="OrderInfoList.aspx" target="main">订单查询</a></li>
                 <li><a href="OrderStateEdit.aspx" target="main">添加订单状态</a></li>
                <li><a href="OrderStateList.aspx" target="main">订单状态查询</a></li> 
            </ul>
        </div>
          
 
 <!--
         <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;客户信息管理</div>
        <div class="MenuNote" style="display:none;" id="Div2" runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
          
                <li><a href="M_CusList.aspx" target="main">客户信息列表</a></li>  
            </ul>
        </div> --->
        
       <div class="Menu"><img src="Images/News.gif" alt=""/>&nbsp;系统信息管理</div>
        <div class="MenuNote" style="display:none;" id="sysDiv"  runat="server">
            <img src="images/menu_topline.gif" alt="" />
            <ul class="MenuUL">
           <li><a href="M_AddUsersInfo.aspx" target="main">添加管理员</a></li>
             <li><a href="M_UsersList.aspx" target="main">管理员列表</a></li>           
            </ul>
        </div>
        <asp:HiddenField ID="Hvalue" runat="server" />
    </div>
    </form>
</body>
</html>
