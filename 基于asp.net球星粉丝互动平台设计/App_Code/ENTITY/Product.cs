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
    ///Product ��ժҪ˵������Ʒʵ��
    /// </summary>

    public class Product
    {
        /*��Ʒid*/
        private int _productId;
        public int productId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /*��Ʒ���*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*��������*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*��ƷͼƬ*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*��������*/
        private string _productDesc;
        public string productDesc
        {
            get { return _productDesc; }
            set { _productDesc = value; }
        }

        /*�ۼ�*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*��Ʒ״̬*/
        private string _productState;
        public string productState
        {
            get { return _productState; }
            set { _productState = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
