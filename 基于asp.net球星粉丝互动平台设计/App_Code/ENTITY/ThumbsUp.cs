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
    ///ThumbsUp ��ժҪ˵��������ʵ��
    /// </summary>

    public class ThumbsUp
    {
        /*����id*/
        private int _thumbsUpId;
        public int thumbsUpId
        {
            get { return _thumbsUpId; }
            set { _thumbsUpId = value; }
        }

        /*��������*/
        private int _postInfoObj;
        public int postInfoObj
        {
            get { return _postInfoObj; }
            set { _postInfoObj = value; }
        }

        /*�����û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*����ʱ��*/
        private DateTime _thumbsUpTime;
        public DateTime thumbsUpTime
        {
            get { return _thumbsUpTime; }
            set { _thumbsUpTime = value; }
        }

    }
}
