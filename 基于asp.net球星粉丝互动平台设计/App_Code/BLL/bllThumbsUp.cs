using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*点赞业务逻辑层*/
    public class bllThumbsUp{
        /*添加点赞*/
        public static bool AddThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            return DAL.dalThumbsUp.AddThumbsUp(thumbsUp);
        }

        /*根据thumbsUpId获取某条点赞记录*/
        public static ENTITY.ThumbsUp getSomeThumbsUp(int thumbsUpId)
        {
            return DAL.dalThumbsUp.getSomeThumbsUp(thumbsUpId);
        }

        /*更新点赞*/
        public static bool EditThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            return DAL.dalThumbsUp.EditThumbsUp(thumbsUp);
        }

        /*删除点赞*/
        public static bool DelThumbsUp(string p)
        {
            return DAL.dalThumbsUp.DelThumbsUp(p);
        }

        /*查询点赞*/
        public static System.Data.DataSet GetThumbsUp(string strWhere)
        {
            return DAL.dalThumbsUp.GetThumbsUp(strWhere);
        }

        /*根据条件分页查询点赞*/
        public static System.Data.DataTable GetThumbsUp(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalThumbsUp.GetThumbsUp(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的点赞*/
        public static System.Data.DataSet getAllThumbsUp()
        {
            return DAL.dalThumbsUp.getAllThumbsUp();
        }
    }
}
