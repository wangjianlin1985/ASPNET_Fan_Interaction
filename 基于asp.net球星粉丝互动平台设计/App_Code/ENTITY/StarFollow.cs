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
    ///StarFollow ��ժҪ˵�������ǹ�עʵ��
    /// </summary>

    public class StarFollow
    {
        /*��עid*/
        private int _followId;
        public int followId
        {
            get { return _followId; }
            set { _followId = value; }
        }

        /*����ע����*/
        private string _starObj;
        public string starObj
        {
            get { return _starObj; }
            set { _starObj = value; }
        }

        /*��ע���û�*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*��עʱ��*/
        private DateTime _followTime;
        public DateTime followTime
        {
            get { return _followTime; }
            set { _followTime = value; }
        }

    }
}
