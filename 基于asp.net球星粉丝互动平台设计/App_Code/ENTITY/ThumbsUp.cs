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
    ///ThumbsUp 的摘要说明：点赞实体
    /// </summary>

    public class ThumbsUp
    {
        /*点赞id*/
        private int _thumbsUpId;
        public int thumbsUpId
        {
            get { return _thumbsUpId; }
            set { _thumbsUpId = value; }
        }

        /*被赞帖子*/
        private int _postInfoObj;
        public int postInfoObj
        {
            get { return _postInfoObj; }
            set { _postInfoObj = value; }
        }

        /*点赞用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*点赞时间*/
        private DateTime _thumbsUpTime;
        public DateTime thumbsUpTime
        {
            get { return _thumbsUpTime; }
            set { _thumbsUpTime = value; }
        }

    }
}
