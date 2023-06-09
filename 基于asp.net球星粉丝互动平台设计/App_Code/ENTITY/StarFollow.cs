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
    ///StarFollow 的摘要说明：球星关注实体
    /// </summary>

    public class StarFollow
    {
        /*关注id*/
        private int _followId;
        public int followId
        {
            get { return _followId; }
            set { _followId = value; }
        }

        /*被关注球星*/
        private string _starObj;
        public string starObj
        {
            get { return _starObj; }
            set { _starObj = value; }
        }

        /*关注的用户*/
        private string _userObj;
        public string userObj
        {
            get { return _userObj; }
            set { _userObj = value; }
        }

        /*关注时间*/
        private DateTime _followTime;
        public DateTime followTime
        {
            get { return _followTime; }
            set { _followTime = value; }
        }

    }
}
