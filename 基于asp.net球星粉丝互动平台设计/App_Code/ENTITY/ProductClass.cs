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
    ///ProductClass ��ժҪ˵������Ʒ���ʵ��
    /// </summary>

    public class ProductClass
    {
        /*��Ʒ���id*/
        private int _producClassId;
        public int producClassId
        {
            get { return _producClassId; }
            set { _producClassId = value; }
        }

        /*��Ʒ�������*/
        private string _productClassName;
        public string productClassName
        {
            get { return _productClassName; }
            set { _productClassName = value; }
        }

    }
}
