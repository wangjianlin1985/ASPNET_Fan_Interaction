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
    public class dalPostInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�������ʵ��*/
        public static bool AddPostInfo(ENTITY.PostInfo postInfo)
        {
            string sql = "insert into PostInfo(title,upPhoto,content,viewNum,userObj,addTime) values(@title,@upPhoto,@content,@viewNum,@userObj,@addTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@upPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*��������ֵ*/
            parm[0].Value = postInfo.title; //���ӱ���
            parm[1].Value = postInfo.upPhoto; //����ͼƬ
            parm[2].Value = postInfo.content; //��������
            parm[3].Value = postInfo.viewNum; //�����
            parm[4].Value = postInfo.userObj; //������
            parm[5].Value = postInfo.addTime; //����ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����postInfoId��ȡĳ�����Ӽ�¼*/
        public static ENTITY.PostInfo getSomePostInfo(int postInfoId)
        {
            /*������ѯsql*/
            string sql = "select * from PostInfo where postInfoId=" + postInfoId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.PostInfo postInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
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

        /*��������ʵ��*/
        public static bool EditPostInfo(ENTITY.PostInfo postInfo)
        {
            string sql = "update PostInfo set title=@title,upPhoto=@upPhoto,content=@content,viewNum=@viewNum,userObj=@userObj,addTime=@addTime where postInfoId=@postInfoId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@title",SqlDbType.VarChar),
             new SqlParameter("@upPhoto",SqlDbType.VarChar),
             new SqlParameter("@content",SqlDbType.VarChar),
             new SqlParameter("@viewNum",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@postInfoId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = postInfo.title;
            parm[1].Value = postInfo.upPhoto;
            parm[2].Value = postInfo.content;
            parm[3].Value = postInfo.viewNum;
            parm[4].Value = postInfo.userObj;
            parm[5].Value = postInfo.addTime;
            parm[6].Value = postInfo.postInfoId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelPostInfo(string p)
        {
            string sql = "delete from PostInfo where postInfoId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
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

        /*��ѯ����*/
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
