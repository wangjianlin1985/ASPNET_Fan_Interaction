using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*帖子业务逻辑层*/
    public class bllPostInfo{
        /*添加帖子*/
        public static bool AddPostInfo(ENTITY.PostInfo postInfo)
        {
            return DAL.dalPostInfo.AddPostInfo(postInfo);
        }

        /*根据postInfoId获取某条帖子记录*/
        public static ENTITY.PostInfo getSomePostInfo(int postInfoId)
        {
            return DAL.dalPostInfo.getSomePostInfo(postInfoId);
        }

        /*更新帖子*/
        public static bool EditPostInfo(ENTITY.PostInfo postInfo)
        {
            return DAL.dalPostInfo.EditPostInfo(postInfo);
        }

        /*删除帖子*/
        public static bool DelPostInfo(string p)
        {
            return DAL.dalPostInfo.DelPostInfo(p);
        }

        /*查询帖子*/
        public static System.Data.DataSet GetPostInfo(string strWhere)
        {
            return DAL.dalPostInfo.GetPostInfo(strWhere);
        }

        /*根据条件分页查询帖子*/
        public static System.Data.DataTable GetPostInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPostInfo.GetPostInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的帖子*/
        public static System.Data.DataSet getAllPostInfo()
        {
            return DAL.dalPostInfo.getAllPostInfo();
        }
    }
}
