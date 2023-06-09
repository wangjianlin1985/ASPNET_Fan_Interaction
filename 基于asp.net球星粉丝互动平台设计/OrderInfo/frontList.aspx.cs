using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
public partial class OrderInfo_frontList : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindproductObj();
            BinduserObj();
            BindorderStateObj();
            string sqlstr = " where 1=1 ";
            if (Request["productObj"] != null && Request["productObj"].ToString() != "0")
            {
                    sqlstr += "  and productObj=" + Request["productObj"].ToString();
                    productObj.SelectedValue = Request["productObj"].ToString();
            }
            if (Request["userObj"] != null && Request["userObj"].ToString() != "")
            {
                sqlstr += "  and userObj='" + Request["userObj"].ToString() + "'";
                userObj.SelectedValue = Request["userObj"].ToString();
            }
            if (Request["orderTime"] != null && Request["orderTime"].ToString() != "")
            {
                sqlstr += "  and Convert(varchar,orderTime,120) like '" + Request["orderTime"].ToString() + "%'";
                orderTime.Text = Request["orderTime"].ToString();
            }
            if (Request["orderStateObj"] != null && Request["orderStateObj"].ToString() != "0")
            {
                    sqlstr += "  and orderStateObj=" + Request["orderStateObj"].ToString();
                    orderStateObj.SelectedValue = Request["orderStateObj"].ToString();
            }
            HWhere.Value = sqlstr;
            BindData("");
       }
    }
    private void BindproductObj()
    {
        ListItem li = new ListItem("������", "0");
        productObj.Items.Add(li);
        DataSet productObjDs = BLL.bllProduct.getAllProduct();
        for (int i = 0; i < productObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = productObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["productName"].ToString(),dr["productId"].ToString());
            productObj.Items.Add(li);
        }
        productObj.SelectedValue = "0";
    }

    private void BinduserObj()
    {
        ListItem li = new ListItem("������", "");
        userObj.Items.Add(li);
        DataSet userObjDs = BLL.bllUserInfo.getAllUserInfo();
        for (int i = 0; i < userObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = userObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["name"].ToString(),dr["user_name"].ToString());
            userObj.Items.Add(li);
        }
        userObj.SelectedValue = "";
    }

    private void BindorderStateObj()
    {
        ListItem li = new ListItem("������", "0");
        orderStateObj.Items.Add(li);
        DataSet orderStateObjDs = BLL.bllOrderState.getAllOrderState();
        for (int i = 0; i < orderStateObjDs.Tables[0].Rows.Count; i++)
        {
            DataRow dr = orderStateObjDs.Tables[0].Rows[i];
            li = new ListItem(dr["stateName"].ToString(),dr["stateId"].ToString());
            orderStateObj.Items.Add(li);
        }
        orderStateObj.SelectedValue = "0";
    }

    private void BindData(string strClass)
    {
        int DataCount = 0;
        int NowPage = 1;
        int AllPage = 0;
        int PageSize = Convert.ToInt32(HPageSize.Value);
        switch (strClass)
        {
            case "next":
                NowPage = Convert.ToInt32(HNowPage.Value) + 1;
                break;
            case "up":
                NowPage = Convert.ToInt32(HNowPage.Value) - 1;
                break;
            case "end":
                NowPage = Convert.ToInt32(HAllPage.Value);
                break;
            default:
                break;
        }
        DataTable dsLog = BLL.bllOrderInfo.GetOrderInfo(NowPage, PageSize, out AllPage, out DataCount, HWhere.Value);
        if (dsLog.Rows.Count == 0 || AllPage == 1)
        {
            LBEnd.Enabled = false;
            LBHome.Enabled = false;
            LBNext.Enabled = false;
            LBUp.Enabled = false;
        }
        else if (NowPage == 1)
        {
            LBHome.Enabled = false;
            LBUp.Enabled = false;
            LBNext.Enabled = true;
            LBEnd.Enabled = true;
        }
        else if (NowPage == AllPage)
        {
            LBHome.Enabled = true;
            LBUp.Enabled = true;
            LBNext.Enabled = false;
            LBEnd.Enabled = false;
        }
        else
        {
            LBEnd.Enabled = true;
            LBHome.Enabled = true;
            LBNext.Enabled = true;
            LBUp.Enabled = true;
        }
        RpOrderInfo.DataSource = dsLog;
        RpOrderInfo.DataBind();
        PageMes.Text = string.Format("[ÿҳ<font color=green>{0}</font>�� ��<font color=red>{1}</font>ҳ����<font color=green>{2}</font>ҳ   ��<font color=green>{3}</font>��]", PageSize, NowPage, AllPage, DataCount);
        HNowPage.Value = Convert.ToString(NowPage++);
        HAllPage.Value = AllPage.ToString();
    }

    protected void LBHome_Click(object sender, EventArgs e)
    {
        BindData("");
    }
    protected void LBUp_Click(object sender, EventArgs e)
    {
        BindData("up");
    }
    protected void LBNext_Click(object sender, EventArgs e)
    {
        BindData("next");
    }
    protected void LBEnd_Click(object sender, EventArgs e)
    {
        BindData("end");
    }
        public string GetProductproductObj(string productObj)
        {
            return BLL.bllProduct.getSomeProduct(int.Parse(productObj)).productName;
        }

        public string GetUserInfouserObj(string userObj)
        {
            return BLL.bllUserInfo.getSomeUserInfo(userObj).name;
        }

        public string GetOrderStateorderStateObj(string orderStateObj)
        {
            return BLL.bllOrderState.getSomeOrderState(int.Parse(orderStateObj)).stateName;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Response.Redirect("frontList.aspx?productObj=" + productObj.SelectedValue.Trim() + "&&userObj=" + userObj.SelectedValue.Trim()+ "&&orderTime=" + orderTime.Text.Trim() + "&&orderStateObj=" + orderStateObj.SelectedValue.Trim());
        }

}
