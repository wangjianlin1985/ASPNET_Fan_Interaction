using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*球星关注业务逻辑层实现*/
    public class dalStarFollow
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加球星关注实现*/
        public static bool AddStarFollow(ENTITY.StarFollow starFollow)
        {
            string sql = "insert into StarFollow(starObj,userObj,followTime) values(@starObj,@userObj,@followTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@starObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@followTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = starFollow.starObj; //被关注球星
            parm[1].Value = starFollow.userObj; //关注的用户
            parm[2].Value = starFollow.followTime; //关注时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据followId获取某条球星关注记录*/
        public static ENTITY.StarFollow getSomeStarFollow(int followId)
        {
            /*构建查询sql*/
            string sql = "select * from StarFollow where followId=" + followId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.StarFollow starFollow = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                starFollow = new ENTITY.StarFollow();
                starFollow.followId = Convert.ToInt32(DataRead["followId"]);
                starFollow.starObj = DataRead["starObj"].ToString();
                starFollow.userObj = DataRead["userObj"].ToString();
                starFollow.followTime = Convert.ToDateTime(DataRead["followTime"].ToString());
            }
            return starFollow;
        }

        /*更新球星关注实现*/
        public static bool EditStarFollow(ENTITY.StarFollow starFollow)
        {
            string sql = "update StarFollow set starObj=@starObj,userObj=@userObj,followTime=@followTime where followId=@followId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@starObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@followTime",SqlDbType.DateTime),
             new SqlParameter("@followId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = starFollow.starObj;
            parm[1].Value = starFollow.userObj;
            parm[2].Value = starFollow.followTime;
            parm[3].Value = starFollow.followId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除球星关注*/
        public static bool DelStarFollow(string p)
        {
            string sql = "delete from StarFollow where followId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询球星关注*/
        public static DataSet GetStarFollow(string strWhere)
        {
            try
            {
                string strSql = "select * from StarFollow" + strWhere + " order by followId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询球星关注*/
        public static System.Data.DataTable GetStarFollow(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from StarFollow";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "followId", strShow, strSql, strWhere, " followId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllStarFollow()
        {
            try
            {
                string strSql = "select * from StarFollow";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
