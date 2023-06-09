using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*帖子回复业务逻辑层*/
    public class bllReply{
        /*添加帖子回复*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.AddReply(reply);
        }

        /*根据replyId获取某条帖子回复记录*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            return DAL.dalReply.getSomeReply(replyId);
        }

        /*更新帖子回复*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.EditReply(reply);
        }

        /*删除帖子回复*/
        public static bool DelReply(string p)
        {
            return DAL.dalReply.DelReply(p);
        }

        /*查询帖子回复*/
        public static System.Data.DataSet GetReply(string strWhere)
        {
            return DAL.dalReply.GetReply(strWhere);
        }

        /*根据条件分页查询帖子回复*/
        public static System.Data.DataTable GetReply(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReply.GetReply(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的帖子回复*/
        public static System.Data.DataSet getAllReply()
        {
            return DAL.dalReply.getAllReply();
        }
    }
}
