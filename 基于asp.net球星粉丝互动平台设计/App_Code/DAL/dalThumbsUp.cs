using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*点赞业务逻辑层实现*/
    public class dalThumbsUp
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加点赞实现*/
        public static bool AddThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            string sql = "insert into ThumbsUp(postInfoObj,userObj,thumbsUpTime) values(@postInfoObj,@userObj,@thumbsUpTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@thumbsUpTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = thumbsUp.postInfoObj; //被赞帖子
            parm[1].Value = thumbsUp.userObj; //点赞用户
            parm[2].Value = thumbsUp.thumbsUpTime; //点赞时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据thumbsUpId获取某条点赞记录*/
        public static ENTITY.ThumbsUp getSomeThumbsUp(int thumbsUpId)
        {
            /*构建查询sql*/
            string sql = "select * from ThumbsUp where thumbsUpId=" + thumbsUpId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ThumbsUp thumbsUp = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                thumbsUp = new ENTITY.ThumbsUp();
                thumbsUp.thumbsUpId = Convert.ToInt32(DataRead["thumbsUpId"]);
                thumbsUp.postInfoObj = Convert.ToInt32(DataRead["postInfoObj"]);
                thumbsUp.userObj = DataRead["userObj"].ToString();
                thumbsUp.thumbsUpTime = Convert.ToDateTime(DataRead["thumbsUpTime"].ToString());
            }
            return thumbsUp;
        }

        /*更新点赞实现*/
        public static bool EditThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            string sql = "update ThumbsUp set postInfoObj=@postInfoObj,userObj=@userObj,thumbsUpTime=@thumbsUpTime where thumbsUpId=@thumbsUpId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@thumbsUpTime",SqlDbType.DateTime),
             new SqlParameter("@thumbsUpId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = thumbsUp.postInfoObj;
            parm[1].Value = thumbsUp.userObj;
            parm[2].Value = thumbsUp.thumbsUpTime;
            parm[3].Value = thumbsUp.thumbsUpId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除点赞*/
        public static bool DelThumbsUp(string p)
        {
            string sql = "delete from ThumbsUp where thumbsUpId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询点赞*/
        public static DataSet GetThumbsUp(string strWhere)
        {
            try
            {
                string strSql = "select * from ThumbsUp" + strWhere + " order by thumbsUpId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询点赞*/
        public static System.Data.DataTable GetThumbsUp(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ThumbsUp";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "thumbsUpId", strShow, strSql, strWhere, " thumbsUpId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllThumbsUp()
        {
            try
            {
                string strSql = "select * from ThumbsUp";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
