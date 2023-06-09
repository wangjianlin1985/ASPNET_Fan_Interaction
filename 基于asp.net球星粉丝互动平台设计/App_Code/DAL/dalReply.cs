using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*帖子回复业务逻辑层实现*/
    public class dalReply
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加帖子回复实现*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            string sql = "insert into Reply(postInfoObj,content,userObj,replyTime) values(@postInfoObj,@content,@userObj,@replyTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = reply.postInfoObj; //被回帖子
            parm[1].Value = reply.content; //回复内容
            parm[2].Value = reply.userObj; //回复人
            parm[3].Value = reply.replyTime; //回复时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据replyId获取某条帖子回复记录*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            /*构建查询sql*/
            string sql = "select * from Reply where replyId=" + replyId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Reply reply = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                reply = new ENTITY.Reply();
                reply.replyId = Convert.ToInt32(DataRead["replyId"]);
                reply.postInfoObj = Convert.ToInt32(DataRead["postInfoObj"]);
                reply.content = DataRead["content"].ToString();
                reply.userObj = DataRead["userObj"].ToString();
                reply.replyTime = Convert.ToDateTime(DataRead["replyTime"].ToString());
            }
            return reply;
        }

        /*更新帖子回复实现*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            string sql = "update Reply set postInfoObj=@postInfoObj,content=@content,userObj=@userObj,replyTime=@replyTime where replyId=@replyId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime),
             new SqlParameter("@replyId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = reply.postInfoObj;
            parm[1].Value = reply.content;
            parm[2].Value = reply.userObj;
            parm[3].Value = reply.replyTime;
            parm[4].Value = reply.replyId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除帖子回复*/
        public static bool DelReply(string p)
        {
            string sql = "delete from Reply where replyId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询帖子回复*/
        public static DataSet GetReply(string strWhere)
        {
            try
            {
                string strSql = "select * from Reply" + strWhere + " order by replyId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询帖子回复*/
        public static System.Data.DataTable GetReply(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Reply";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "replyId", strShow, strSql, strWhere, " replyId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllReply()
        {
            try
            {
                string strSql = "select * from Reply";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
