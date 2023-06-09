using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*帖子业务逻辑层实现*/
    public class dalPostInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加帖子实现*/
        public static bool AddPostInfo(ENTITY.PostInfo postInfo)
        {
            string sql = "insert into PostInfo(title,upPhoto,content,viewNum,userObj,addTime) values(@title,@upPhoto,@content,@viewNum,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@upPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = postInfo.title; //帖子标题
            parm[1].Value = postInfo.upPhoto; //帖子图片
            parm[2].Value = postInfo.content; //帖子内容
            parm[3].Value = postInfo.viewNum; //浏览量
            parm[4].Value = postInfo.userObj; //发帖人
            parm[5].Value = postInfo.addTime; //发帖时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据postInfoId获取某条帖子记录*/
        public static ENTITY.PostInfo getSomePostInfo(int postInfoId)
        {
            /*构建查询sql*/
            string sql = "select * from PostInfo where postInfoId=" + postInfoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PostInfo postInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                postInfo = new ENTITY.PostInfo();
                postInfo.postInfoId = Convert.ToInt32(DataRead["postInfoId"]);
                postInfo.title = DataRead["title"].ToString();
                postInfo.upPhoto = DataRead["upPhoto"].ToString();
                postInfo.content = DataRead["content"].ToString();
                postInfo.viewNum = Convert.ToInt32(DataRead["viewNum"]);
                postInfo.userObj = DataRead["userObj"].ToString();
                postInfo.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return postInfo;
        }

        /*更新帖子实现*/
        public static bool EditPostInfo(ENTITY.PostInfo postInfo)
        {
            string sql = "update PostInfo set title=@title,upPhoto=@upPhoto,content=@content,viewNum=@viewNum,userObj=@userObj,addTime=@addTime where postInfoId=@postInfoId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@upPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@postInfoId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = postInfo.title;
            parm[1].Value = postInfo.upPhoto;
            parm[2].Value = postInfo.content;
            parm[3].Value = postInfo.viewNum;
            parm[4].Value = postInfo.userObj;
            parm[5].Value = postInfo.addTime;
            parm[6].Value = postInfo.postInfoId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除帖子*/
        public static bool DelPostInfo(string p)
        {
            string sql = "delete from PostInfo where postInfoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询帖子*/
        public static DataSet GetPostInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from PostInfo" + strWhere + " order by postInfoId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询帖子*/
        public static System.Data.DataTable GetPostInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from PostInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "postInfoId", strShow, strSql, strWhere, " postInfoId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllPostInfo()
        {
            try
            {
                string strSql = "select * from PostInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
