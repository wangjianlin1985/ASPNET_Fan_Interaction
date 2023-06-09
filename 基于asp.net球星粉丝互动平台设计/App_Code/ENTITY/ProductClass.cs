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
    ///ProductClass 的摘要说明：商品类别实体
    /// </summary>

    public class ProductClass
    {
        /*商品类别id*/
        private int _producClassId;
        public int producClassId
        {
            get { return _producClassId; }
            set { _producClassId = value; }
        }

        /*商品类别名称*/
        private string _productClassName;
        public string productClassName
        {
            get { return _productClassName; }
            set { _productClassName = value; }
        }

    }
}
