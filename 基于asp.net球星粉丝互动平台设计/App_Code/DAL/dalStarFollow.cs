using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ǹ�עҵ���߼���ʵ��*/
    public class dalStarFollow
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ǹ�עʵ��*/
        public static bool AddStarFollow(ENTITY.StarFollow starFollow)
        {
            string sql = "insert into StarFollow(starObj,userObj,followTime) values(@starObj,@userObj,@followTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@starObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@followTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = starFollow.starObj; //����ע����
            parm[1].Value = starFollow.userObj; //��ע���û�
            parm[2].Value = starFollow.followTime; //��עʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����followId��ȡĳ�����ǹ�ע��¼*/
        public static ENTITY.StarFollow getSomeStarFollow(int followId)
        {
            /*������ѯsql*/
            string sql = "select * from StarFollow where followId=" + followId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.StarFollow starFollow = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�������ǹ�עʵ��*/
        public static bool EditStarFollow(ENTITY.StarFollow starFollow)
        {
            string sql = "update StarFollow set starObj=@starObj,userObj=@userObj,followTime=@followTime where followId=@followId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@starObj",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@followTime",SqlDbType.DateTime),
             new SqlParameter("@followId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = starFollow.starObj;
            parm[1].Value = starFollow.userObj;
            parm[2].Value = starFollow.followTime;
            parm[3].Value = starFollow.followId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ǹ�ע*/
        public static bool DelStarFollow(string p)
        {
            string sql = "delete from StarFollow where followId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ǹ�ע*/
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

        /*��ѯ���ǹ�ע*/
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
