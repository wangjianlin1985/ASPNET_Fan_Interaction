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
    ///PostInfo ��ժҪ˵��������ʵ��
    /// </summary>

    public class PostInfo
    {
        /*����id*/
        private int _postInfoId;
        public int postInfoId
        {
            get { return _postInfoId; }
            set { _postInfoId = value; }
        }

        /*���ӱ���*/
        private string _title;
        public string title
        {
            get { return _title; }
            set { _title = value; }
        }

        /*����ͼƬ*/
        private string _upPhoto;
        public string upPhoto
        {
            get { return _upPhoto; }
            set { _upPhoto = value; }
        }

        /*��������*/
        private string _content;
        public string content
        {
            get { return _content; }
            set { _content = value; }
        }

        /*�����*/
        private int _viewNum;
        public int viewNum
        {
            get { return _viewNum; }
            set { _viewNum = value; }
        }

        /*������*/
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
