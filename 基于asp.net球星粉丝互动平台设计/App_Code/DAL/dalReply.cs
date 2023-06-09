using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*���ӻظ�ҵ���߼���ʵ��*/
    public class dalReply
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*������ӻظ�ʵ��*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            string sql = "insert into Reply(postInfoObj,content,userObj,replyTime) values(@postInfoObj,@content,@userObj,@replyTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = reply.postInfoObj; //��������
            parm[1].Value = reply.content; //�ظ�����
            parm[2].Value = reply.userObj; //�ظ���
            parm[3].Value = reply.replyTime; //�ظ�ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����replyId��ȡĳ�����ӻظ���¼*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            /*������ѯsql*/
            string sql = "select * from Reply where replyId=" + replyId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Reply reply = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*�������ӻظ�ʵ��*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            string sql = "update Reply set postInfoObj=@postInfoObj,content=@content,userObj=@userObj,replyTime=@replyTime where replyId=@replyId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@postInfoObj",SqlDbType.Int),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@replyTime",SqlDbType.DateTime),
             new SqlParameter("@replyId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = reply.postInfoObj;
            parm[1].Value = reply.content;
            parm[2].Value = reply.userObj;
            parm[3].Value = reply.replyTime;
            parm[4].Value = reply.replyId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ�����ӻظ�*/
        public static bool DelReply(string p)
        {
            string sql = "delete from Reply where replyId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ���ӻظ�*/
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

        /*��ѯ���ӻظ�*/
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
