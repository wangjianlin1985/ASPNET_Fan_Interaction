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
    ///PostInfo 的摘要说明：帖子实体
    /// </summary>

    public class PostInfo
    {
        /*帖子id*/
        private int _postInfoId;
        public int postInfoId
        {
            get { return _postInfoId; }
            set { _postInfoId = value; }
        }

        /*帖子标题*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*帖子图片*/
        private string _upPhoto;
        public string upPhoto
        {
            get { return _upPhoto; }
            set { _upPhoto = value; }
        }

        /*帖子内容*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*浏览量*/
        private int _viewNum;
        public int viewNum
        {
            get { return _viewNum; }
            set { _viewNum = value; }
        }

        /*发帖人*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*发帖时间*/
        private DateTime _addTime;
        public DateTime addTime
        {
            get { return _addTime; }
            set { _addTime = value; }
        }

    }
}
