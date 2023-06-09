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
    ///OrderInfo ��ժҪ˵��������ʵ��
    /// </summary>

    public class OrderInfo
    {
        /*�������*/
        private int _orderId;
        public int orderId
        {
            get { return _orderId; }
            set { _orderId = value; }
        }

        /*������Ʒ*/
        private int _productObj;
        public int productObj
        {
            get { return _productObj; }
            set { _productObj = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�µ�ʱ��*/
        private DateTime _orderTime;
        public DateTime orderTime
        {
            get { return _orderTime; }
            set { _orderTime = value; }
        }

        /*����״̬*/
        private int _orderStateObj;
        public int orderStateObj
        {
            get { return _orderStateObj; }
            set { _orderStateObj = value; }
        }

    }
}
