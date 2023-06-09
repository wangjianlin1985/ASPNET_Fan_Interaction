<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontShow.aspx.cs" Inherits="PostInfo_frontShow" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/";
    ENTITY.PostInfo postInfo = BLL.bllPostInfo.getSomePostInfo(int.Parse(Request.QueryString["postInfoId"]));
    postInfo.viewNum++;
    BLL.bllPostInfo.EditPostInfo(postInfo);
    
    System.Data.DataSet replyDs = BLL.bllReply.GetReply("  where postInfoObj = " + postInfo.postInfoId + " ");


    System.Data.DataSet thumpDs = BLL.bllThumbsUp.GetThumbsUp(" where postInfoObj = " + postInfo.postInfoId + " ");
    
%>
<!DOCTYPE html>
<html>
<head>
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
  <TITLE>查看帖子详情</TITLE>
  <link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
  <link href="<%=basePath %>plugins/animate.css" rel="stylesheet"> 
</head>
<body style="margin-top:70px;"> 
<uc:header ID="header" runat="server" />
<div class="container">
	<ul class="breadcrumb">
  		<li><a href="<%=basePath %>index.aspx">首页</a></li>
  		<li><a href="<%=basePath %>PostInfo/frontList.aspx">帖子信息</a></li>
  		<li class="active">详情查看</li>
	</ul>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">帖子id:</div>
		<div class="col-md-10 col-xs-6"><%=postInfo.postInfoId%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">帖子标题:</div>
		<div class="col-md-10 col-xs-6"><%=postInfo.title%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">帖子图片:</div>
		<div class="col-md-10 col-xs-6"><img class="img-responsive" src="<%=basePath %><%=postInfo.upPhoto %>"  border="0px"/></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">帖子内容:</div>
		<div class="col-md-10 col-xs-6"><%=postInfo.content%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">浏览量:</div>
		<div class="col-md-10 col-xs-6"><%=postInfo.viewNum%></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发帖人:</div>
		<div class="col-md-10 col-xs-6"><%=BLL.bllUserInfo.getSomeUserInfo(postInfo.userObj).name %></div>
	</div>
	<div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">发帖时间:</div>
		<div class="col-md-10 col-xs-6"><%=postInfo.addTime%></div>
	</div>
    <div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold">回复内容:</div>
		<div class="col-md-10 col-xs-6">
			<textarea id="content" style="width:100%" rows=8></textarea>
		</div>
	</div>
	
	<div class="row bottom15">
		<div class="col-md-2 col-xs-4"></div>
		<div class="col-md-6 col-xs-6">
			<button onclick="userReply();" class="btn btn-primary">发布回复</button>
            <button onclick="userThumbsUp();" class="btn btn-primary">我要点赞</button>
			<button onclick="history.back();" class="btn btn-info">返回</button>
            &nbsp;&nbsp;共<font color=red><%=thumpDs.Tables[0].Rows.Count %></font>人点赞
		</div>
	</div>

    <div class="row bottom15"> 
		<div class="col-md-2 col-xs-4 text-right bold"></div>
		<div class="col-md-8 col-xs-7">
			<% for (int i = 0; i < replyDs.Tables[0].Rows.Count;i++ ) {
                System.Data.DataRow dr = replyDs.Tables[0].Rows[i];
		        String user_name = dr["userObj"].ToString();
                ENTITY.UserInfo userInfo = BLL.bllUserInfo.getSomeUserInfo(user_name);	    
            %>
			<div class="row" style="margin-top: 20px;">
				<div class="col-md-2 col-xs-3">
					<div class="row text-center"><img src="<%=basePath %><%=userInfo.userPhoto %>" style="border: none;width:60px;height:60px;border-radius: 50%;" /></div>
					<div class="row text-center" style="margin: 5px 0px;"><%=userInfo.name %></div>
				</div>
				<div class="col-md-7 col-xs-5"><%=dr["content"]%></div>
				<div class="col-md-3 col-xs-4" ><%=dr["replyTime"].ToString()%></div>
			</div>
		
			<% } %> 
		</div>
	</div>

     
</div> 
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script>
var basePath = "<%=basePath%>";
$(function () {
    /*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function () {
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();
});

//发表评论回复
function userReply() {
	var content = $("#content").val();
	if(content == "") {
		alert("请输入回复内容");
		return;
	} 
	$.ajax({
		url : basePath + "Reply/ReplyController.aspx?action=userAdd",
		type : "post",
        dataType: "json",
		data: {
			"reply.postInfoObj.postInfoId": <%=postInfo.postInfoId %>,
			"reply.content": content
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("回复成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
	});
}

//用户点赞
function userThumbsUp() {
    $.ajax({
		url : basePath + "ThumbsUp/ThumbsUpController.aspx?action=userAdd",
		type : "post",
        dataType: "json",
		data: {
			"thumbsUp.postInfoObj.postInfoId": <%=postInfo.postInfoId %>, 
		},
		success : function (data, response, status) {
			//var obj = jQuery.parseJSON(data);
			if(data.success){
				alert("点赞成功~");
				location.reload();
			}else{
				alert(data.message);
			}
		}
	});
}


 </script> 
</body>
</html>

