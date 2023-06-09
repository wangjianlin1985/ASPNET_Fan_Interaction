using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*�û�ҵ���߼���ʵ��*/
    public class dalUserInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*����û�ʵ��*/
        public static bool AddUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "insert into UserInfo(user_name,password,name,sex,userPhoto,birthday,telephone,address,ballStar,regTime) values(@user_name,@password,@name,@sex,@userPhoto,@birthday,@telephone,@address,@ballStar,@regTime)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@user_name",SqlDbType.VarChar),
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@birthday",SqlDbType.DateTime),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@ballStar",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = userInfo.user_name; //�û���
            parm[1].Value = userInfo.password; //��¼����
            parm[2].Value = userInfo.name; //����
            parm[3].Value = userInfo.sex; //�Ա�
            parm[4].Value = userInfo.userPhoto; //�û���Ƭ
            parm[5].Value = userInfo.birthday; //��������
            parm[6].Value = userInfo.telephone; //��ϵ�绰
            parm[7].Value = userInfo.address; //��ͥ��ַ
            parm[8].Value = userInfo.ballStar; //���Ǳ�־
            parm[9].Value = userInfo.regTime; //ע��ʱ��

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����user_name��ȡĳ���û���¼*/
        public static ENTITY.UserInfo getSomeUserInfo(string user_name)
        {
            /*������ѯsql*/
            string sql = "select * from UserInfo where user_name='" + user_name + "'"; 
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.UserInfo userInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                userInfo = new ENTITY.UserInfo();
                userInfo.user_name = DataRead["user_name"].ToString();
                userInfo.password = DataRead["password"].ToString();
                userInfo.name = DataRead["name"].ToString();
                userInfo.sex = DataRead["sex"].ToString();
                userInfo.userPhoto = DataRead["userPhoto"].ToString();
                userInfo.birthday = Convert.ToDateTime(DataRead["birthday"].ToString());
                userInfo.telephone = DataRead["telephone"].ToString();
                userInfo.address = DataRead["address"].ToString();
                userInfo.ballStar = DataRead["ballStar"].ToString();
                userInfo.regTime = DataRead["regTime"].ToString();
            }
            return userInfo;
        }

        /*�����û�ʵ��*/
        public static bool EditUserInfo(ENTITY.UserInfo userInfo)
        {
            string sql = "update UserInfo set password=@password,name=@name,sex=@sex,userPhoto=@userPhoto,birthday=@birthday,telephone=@telephone,address=@address,ballStar=@ballStar,regTime=@regTime where user_name=@user_name";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@password",SqlDbType.VarChar),
             new SqlParameter("@name",SqlDbType.VarChar),
             new SqlParameter("@sex",SqlDbType.VarChar),
             new SqlParameter("@userPhoto",SqlDbType.VarChar),
             new SqlParameter("@birthday",SqlDbType.DateTime),
             new SqlParameter("@telephone",SqlDbType.VarChar),
             new SqlParameter("@address",SqlDbType.VarChar),
             new SqlParameter("@ballStar",SqlDbType.VarChar),
             new SqlParameter("@regTime",SqlDbType.VarChar),
             new SqlParameter("@user_name",SqlDbType.VarChar)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = userInfo.password;
            parm[1].Value = userInfo.name;
            parm[2].Value = userInfo.sex;
            parm[3].Value = userInfo.userPhoto;
            parm[4].Value = userInfo.birthday;
            parm[5].Value = userInfo.telephone;
            parm[6].Value = userInfo.address;
            parm[7].Value = userInfo.ballStar;
            parm[8].Value = userInfo.regTime;
            parm[9].Value = userInfo.user_name;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ���û�*/
        public static bool DelUserInfo(string p)
        {
            string sql = "";
            string[] ids = p.Split(',');
            for(int i=0;i<ids.Length;i++)
            {
                if(i != ids.Length-1)
                  sql += "'" + ids[i] + "',";
                else
                  sql += "'" + ids[i] + "'";
            }
            sql = "delete from UserInfo where user_name in (" + sql + ")";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ�û�*/
        public static DataSet GetUserInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from UserInfo" + strWhere + " order by user_name asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ�û�*/
        public static System.Data.DataTable GetUserInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from UserInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePagerWhenPrimaryIsString(PageIndex, PageSize, "user_name", strShow, strSql, strWhere, " user_name asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllUserInfo()
        {
            try
            {
                string strSql = "select * from UserInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
