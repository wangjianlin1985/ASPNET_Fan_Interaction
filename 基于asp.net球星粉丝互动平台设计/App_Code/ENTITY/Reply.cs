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
    ///Reply 的摘要说明：帖子回复实体
    /// </summary>

    public class Reply
    {
        /*回复id*/
        private int _replyId;
        public int replyId
        {
            get { return _replyId; }
            set { _replyId = value; }
        }

        /*被回帖子*/
        private int _postInfoObj;
        public int postInfoObj
        {
            get { return _postInfoObj; }
            set { _postInfoObj = value; }
        }

        /*回复内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*回复人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*回复时间*/
        private DateTime _replyTime;
        public DateTime replyTime
        {
            get { return _replyTime; }
            set { _replyTime = value; }
        }

    }
}
