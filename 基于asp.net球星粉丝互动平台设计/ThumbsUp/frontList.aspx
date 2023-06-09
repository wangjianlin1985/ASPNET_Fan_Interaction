<%@ Page Language="C#" AutoEventWireup="true" CodeFile="frontList.aspx.cs" Inherits="ThumbsUp_frontList" %>
<%@ Register Src="../header.ascx" TagName="header" TagPrefix="uc" %>
<%@ Register Src="../footer.ascx" TagName="footer" TagPrefix="uc" %>
<%
    String path = Request.ApplicationPath;
    String basePath = path + "/"; 
%>
<!DOCTYPE html>
<html>
<head>
<meta charset="utf-8">
<meta http-equiv="X-UA-Compatible" content="IE=edge">
<meta name="viewport" content="width=device-width, initial-scale=1 , user-scalable=no">
<title>点赞查询</title>
<link href="<%=basePath %>plugins/bootstrap.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-dashen.css" rel="stylesheet">
<link href="<%=basePath %>plugins/font-awesome.css" rel="stylesheet">
<link href="<%=basePath %>plugins/animate.css" rel="stylesheet">
<link href="<%=basePath %>plugins/bootstrap-datetimepicker.min.css" rel="stylesheet" media="screen">
</head>
<body style="margin-top:70px;">
<div class="container">
<uc:header ID="header" runat="server" />
 <form id="form2" runat="server">
	<div class="row"> 
		<div class="col-md-9 wow fadeInDown" data-wow-duration="0.5s">
			<div>
				<!-- Nav tabs -->
				<ul class="nav nav-tabs" role="tablist">
			    	<li><a href="../index.aspx">首页</a></li>
			    	<li role="presentation" class="active"><a href="#thumbsUpListPanel" aria-controls="thumbsUpListPanel" role="tab" data-toggle="tab">点赞列表</a></li>
			    	<li role="presentation" ><a href="frontAdd.aspx" style="display:none;">添加点赞</a></li>
				</ul>
			  	<!-- Tab panes -->
			  	<div class="tab-content">
				    <div role="tabpanel" class="tab-pane active" id="thumbsUpListPanel">
				    		<div class="row">
				    			<div class="col-md-12 top5">
				    				<div class="table-responsive">
				    				<table class="table table-condensed table-hover">
				    					<tr class="success bold"><td>序号</td><td>点赞id</td><td>被赞帖子</td><td>点赞用户</td><td>点赞时间</td><td>操作</td></tr>
				    					<asp:Repeater ID="RpThumbsUp" runat="server">
 										<ItemTemplate>
 										<tr>
 											<td><%#(Container.ItemIndex + 1)%></td>
 											<td><%#Eval("thumbsUpId")%></td>
 											<td><%#GetPostInfopostInfoObj(Eval("postInfoObj").ToString())%></td>
 											<td><%#GetUserInfouserObj(Eval("userObj").ToString())%></td>
 											<td><%#Eval("thumbsUpTime")%></td>
 											<td>
 												<a href="frontshow.aspx?thumbsUpId=<%#Eval("thumbsUpId")%>"><i class="fa fa-info"></i>&nbsp;查看</a>&nbsp;
 												<a href="#" onclick="thumbsUpEdit('<%#Eval("thumbsUpId")%>');" style="display:none;"><i class="fa fa-pencil fa-fw"></i>编辑</a>&nbsp;
 												<a href="#" onclick="thumbsUpDelete('<%#Eval("thumbsUpId")%>');" style="display:none;"><i class="fa fa-trash-o fa-fw"></i>删除</a>
 											</td> 
 										</tr>
 										</ItemTemplate>
 										</asp:Repeater>
				    				</table>
				    				</div>
				    			</div>
				    		</div>

				    		<div class="row">
					            <div class="col-md-12">
						            <nav class="pull-left">
						                <ul class="pagination">
						                    <asp:LinkButton ID="LBHome" runat="server" CssClass="pageBtn"
						                      onclick="LBHome_Click">[首页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBUp" runat="server" CssClass="pageBtn" 
						                      onclick="LBUp_Click">[上一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBNext" runat="server" CssClass="pageBtn"
						                      onclick="LBNext_Click">[下一页]</asp:LinkButton>
						                    <asp:LinkButton ID="LBEnd" runat="server" CssClass="pageBtn"
						                      onclick="LBEnd_Click">[尾页]</asp:LinkButton>
						                    <asp:HiddenField ID="HSelectID" runat="server" Value=""/>
						                    <asp:HiddenField ID="HWhere" runat="server" Value=""/>
						                    <asp:HiddenField ID="HNowPage" runat="server" Value="1"/>
						                    <asp:HiddenField ID="HPageSize" runat="server" Value="8"/>
						                    <asp:HiddenField ID="HAllPage" runat="server" Value="0"/>
						                </ul>
						            </nav>
						            <div class="pull-right" style="line-height:75px;" ><asp:Label runat="server" ID="PageMes"></asp:Label></div>
					            </div>
				            </div> 
				    </div>
				</div>
			</div>
		</div>
	<div class="col-md-3 wow fadeInRight">
		<div class="page-header">
    		<h1>点赞查询</h1>
		</div>
            <div class="form-group">
            	<label for="postInfoObj_thumbsUpId">被赞帖子：</label>
                <asp:DropDownList ID="postInfoObj" runat="server"  CssClass="form-control" placeholder="请选择被赞帖子"></asp:DropDownList>
            </div>
            <div class="form-group">
            	<label for="userObj_thumbsUpId">点赞用户：</label>
                <asp:DropDownList ID="userObj" runat="server"  CssClass="form-control" placeholder="请选择点赞用户"></asp:DropDownList>
            </div>
			<div class="form-group">
				<label for="thumbsUpTime">点赞时间:</label>
				<asp:TextBox ID="thumbsUpTime"  runat="server" CssClass="form-control" placeholder="请选择点赞时间" onclick="SelectDate(this,'yyyy-MM-dd');"></asp:TextBox>
			</div>
            <input type=hidden name=currentPage value="" />
            <button type="submit" class="btn btn-primary">查询</button>
	</div>

	</div>
 </form>
</div> 
<div id="thumbsUpEditDialog" class="modal fade" tabindex="-1" role="dialog">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title"><i class="fa fa-edit"></i>&nbsp;点赞信息编辑</h4>
      </div>
      <div class="modal-body" style="height:450px; overflow: scroll;">
      	<form class="form-horizontal" name="thumbsUpEditForm" id="thumbsUpEditForm" enctype="multipart/form-data" method="post"  class="mar_t15">
		  <div class="form-group">
			 <label for="thumbsUp_thumbsUpId_edit" class="col-md-3 text-right">点赞id:</label>
			 <div class="col-md-9"> 
			 	<input type="text" id="thumbsUp_thumbsUpId_edit" name="thumbsUp.thumbsUpId" class="form-control" placeholder="请输入点赞id" readOnly>
			 </div>
		  </div> 
		  <div class="form-group">
		  	 <label for="thumbsUp_postInfoObj_postInfoId_edit" class="col-md-3 text-right">被赞帖子:</label>
		  	 <div class="col-md-9">
			    <select id="thumbsUp_postInfoObj_postInfoId_edit" name="thumbsUp.postInfoObj.postInfoId" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thumbsUp_userObj_user_name_edit" class="col-md-3 text-right">点赞用户:</label>
		  	 <div class="col-md-9">
			    <select id="thumbsUp_userObj_user_name_edit" name="thumbsUp.userObj.user_name" class="form-control">
			    </select>
		  	 </div>
		  </div>
		  <div class="form-group">
		  	 <label for="thumbsUp_thumbsUpTime_edit" class="col-md-3 text-right">点赞时间:</label>
		  	 <div class="col-md-9">
                <div class="input-group date thumbsUp_thumbsUpTime_edit col-md-12" data-link-field="thumbsUp_thumbsUpTime_edit">
                    <input class="form-control" id="thumbsUp_thumbsUpTime_edit" name="thumbsUp.thumbsUpTime" size="16" type="text" value="" placeholder="请选择点赞时间" readonly>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-remove"></span></span>
                    <span class="input-group-addon"><span class="glyphicon glyphicon-calendar"></span></span>
                </div>
		  	 </div>
		  </div>
		</form> 
	    <style>#thumbsUpEditForm .form-group {margin-bottom:5px;}  </style>
      </div>
      <div class="modal-footer"> 
      	<button type="button" class="btn btn-default" data-dismiss="modal">关闭</button>
      	<button type="button" class="btn btn-primary" onclick="ajaxThumbsUpModify();">提交</button>
      </div>
    </div><!-- /.modal-content -->
  </div><!-- /.modal-dialog -->
</div><!-- /.modal -->
<uc:footer ID="footer" runat="server" />
<script src="<%=basePath %>plugins/jquery.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap.js"></script>
<script src="<%=basePath %>plugins/wow.min.js"></script>
<script src="<%=basePath %>plugins/bootstrap-datetimepicker.min.js"></script>
<script src="<%=basePath %>plugins/locales/bootstrap-datetimepicker.zh-CN.js"></script>
<script type="text/javascript" src="<%=basePath %>js/jsdate.js"></script>
<script>
var basePath = "<%=basePath%>";
/*弹出修改点赞界面并初始化数据*/
function thumbsUpEdit(thumbsUpId) {
	$.ajax({
		url :  basePath + "ThumbsUp/ThumbsUpController.aspx?action=getThumbsUp&thumbsUpId=" + thumbsUpId,
		type : "get",
		dataType: "json",
		success : function (thumbsUp, response, status) {
			if (thumbsUp) {
				$("#thumbsUp_thumbsUpId_edit").val(thumbsUp.thumbsUpId);
				$.ajax({
					url: basePath + "PostInfo/PostInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(postInfos,response,status) { 
						$("#thumbsUp_postInfoObj_postInfoId_edit").empty();
						var html="";
		        		$(postInfos).each(function(i,postInfo){
		        			html += "<option value='" + postInfo.postInfoId + "'>" + postInfo.title + "</option>";
		        		});
		        		$("#thumbsUp_postInfoObj_postInfoId_edit").html(html);
		        		$("#thumbsUp_postInfoObj_postInfoId_edit").val(thumbsUp.postInfoObjPri);
					}
				});
				$.ajax({
					url: basePath + "UserInfo/UserInfoController.aspx?action=listAll",
					type: "get",
					dataType: "json",
					success: function(userInfos,response,status) { 
						$("#thumbsUp_userObj_user_name_edit").empty();
						var html="";
		        		$(userInfos).each(function(i,userInfo){
		        			html += "<option value='" + userInfo.user_name + "'>" + userInfo.name + "</option>";
		        		});
		        		$("#thumbsUp_userObj_user_name_edit").html(html);
		        		$("#thumbsUp_userObj_user_name_edit").val(thumbsUp.userObjPri);
					}
				});
				$("#thumbsUp_thumbsUpTime_edit").val(thumbsUp.thumbsUpTime);
				$('#thumbsUpEditDialog').modal('show');
			} else {
				alert("获取信息失败！");
			}
		}
	});
}

/*删除点赞信息*/
function thumbsUpDelete(thumbsUpId) {
	if(confirm("确认删除这个记录")) {
		$.ajax({
			type : "POST",
			url : basePath + "ThumbsUp/ThumbsUpController.aspx?action=delete",
			data : {
				thumbsUpId : thumbsUpId,
			},
			dataType: "json",
			success : function (obj) {
				if (obj.success) {
					alert("删除成功");
					$("#btnSearch").click();
					//location.href= basePath + "ThumbsUp/frontList.aspx";
				}
				else 
					alert(obj.message);
			},
		});
	}
}

/*ajax方式提交点赞信息表单给服务器端修改*/
function ajaxThumbsUpModify() {
	$.ajax({
		url :  basePath + "ThumbsUp/ThumbsUpController.aspx?action=update",
		type : "post",
		dataType: "json",
		data: new FormData($("#thumbsUpEditForm")[0]),
		success : function (obj, response, status) {
            if(obj.success){
                alert("信息修改成功！");
                $("#btnSearch").click();
            }else{
                alert(obj.message);
            } 
		},
		processData: false,
		contentType: false,
	});
}

$(function(){
	/*小屏幕导航点击关闭菜单*/
    $('.navbar-collapse a').click(function(){
        $('.navbar-collapse').collapse('hide');
    });
    new WOW().init();

    /*点赞时间组件*/
    $('.thumbsUp_thumbsUpTime_edit').datetimepicker({
    	language:  'zh-CN',  //语言
    	format: 'yyyy-mm-dd hh:ii:ss',
    	weekStart: 1,
    	todayBtn:  1,
    	autoclose: 1,
    	minuteStep: 1,
    	todayHighlight: 1,
    	startView: 2,
    	forceParse: 0
    });
})
</script>
</body>
</html>

