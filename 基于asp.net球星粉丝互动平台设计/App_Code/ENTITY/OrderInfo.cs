using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace ENTITY
{
    /// <summary>
    ///OrderInfo 的摘要说明：订单实体
    /// </summary>

    public class OrderInfo
    {
        /*订单编号*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*购买商品*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*购买用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*下单时间*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*订单状态*/
        private int _orderStateObj;
        public int orderStateObj
        {
            get { return _orderStateObj; }
            set { _orderStateObj = value; }
        }

    }
}
