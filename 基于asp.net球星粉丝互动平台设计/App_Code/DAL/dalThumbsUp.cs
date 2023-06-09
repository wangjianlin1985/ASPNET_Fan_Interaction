using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*����ҵ���߼���ʵ��*/
    public class dalThumbsUp
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��ӵ���ʵ��*/
        public static bool AddThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            string sql = "insert into ThumbsUp(postInfoObj,userObj,thumbsUpTime) values(@postInfoObj,@userObj,@thumbsUpTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@thumbsUpTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = thumbsUp.postInfoObj; //��������
            parm[1].Value = thumbsUp.userObj; //�����û�
            parm[2].Value = thumbsUp.thumbsUpTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����thumbsUpId��ȡĳ�����޼�¼*/
        public static ENTITY.ThumbsUp getSomeThumbsUp(int thumbsUpId)
        {
            /*������ѯsql*/
            string sql = "select * from ThumbsUp where thumbsUpId=" + thumbsUpId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ThumbsUp thumbsUp = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*���µ���ʵ��*/
        public static bool EditThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            string sql = "update ThumbsUp set postInfoObj=@postInfoObj,userObj=@userObj,thumbsUpTime=@thumbsUpTime where thumbsUpId=@thumbsUpId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@thumbsUpTime",SqlDbType.DateTime),
             new SqlParameter("@thumbsUpId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = thumbsUp.postInfoObj;
            parm[1].Value = thumbsUp.userObj;
            parm[2].Value = thumbsUp.thumbsUpTime;
            parm[3].Value = thumbsUp.thumbsUpId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelThumbsUp(string p)
        {
            string sql = "delete from ThumbsUp where thumbsUpId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
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

        /*��ѯ����*/
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
