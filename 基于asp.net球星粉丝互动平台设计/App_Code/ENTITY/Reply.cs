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
    ///Reply ��ժҪ˵�������ӻظ�ʵ��
    /// </summary>

    public class Reply
    {
        /*�ظ�id*/
        private int _replyId;
        public int replyId
        {
            get { return _replyId; }
            set { _replyId = value; }
        }

        /*��������*/
        private int _postInfoObj;
        public int postInfoObj
        {
            get { return _postInfoObj; }
            set { _postInfoObj = value; }
        }

        /*�ظ�����*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�ظ���*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*�ظ�ʱ��*/
        private DateTime _replyTime;
        public DateTime replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

    }
}
