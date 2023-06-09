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
    ///Product 的摘要说明：商品实体
    /// </summary>

    public class Product
    {
        /*商品id*/
        private int _productId;
        public int productId
        {
            get { return _productId; }
            set { _productId = value; }
        }

        /*商品类别*/
        private int _productClassObj;
        public int productClassObj
        {
            get { return _productClassObj; }
            set { _productClassObj = value; }
        }

        /*宝贝名称*/
        private string _productName;
        public string productName
        {
            get { return _productName; }
            set { _productName = value; }
        }

        /*商品图片*/
        private string _productPhoto;
        public string productPhoto
        {
            get { return _productPhoto; }
            set { _productPhoto = value; }
        }

        /*宝贝描述*/
        private string _productDesc;
        public string productDesc
        {
            get { return _productDesc; }
            set { _productDesc = value; }
        }

        /*售价*/
        private float _price;
        public float price
        {
            get { return _price; }
            set { _price = value; }
        }

        /*商品状态*/
        private string _productState;
        public string productState
        {
            get { return _productState; }
            set { _productState = value; }
        }

        /*发布用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*发布时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
