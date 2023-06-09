using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*��Ʒ���ҵ���߼���ʵ��*/
    public class dalProductClass
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*�����Ʒ���ʵ��*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "insert into ProductClass(productClassName) values(@productClassName)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar)
            };
            /*��������ֵ*/
            parm[0].Value = productClass.productClassName; //��Ʒ�������

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����producClassId��ȡĳ����Ʒ����¼*/
        public static ENTITY.ProductClass getSomeProductClass(int producClassId)
        {
            /*������ѯsql*/
            string sql = "select * from ProductClass where producClassId=" + producClassId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.ProductClass productClass = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                productClass = new ENTITY.ProductClass();
                productClass.producClassId = Convert.ToInt32(DataRead["producClassId"]);
                productClass.productClassName = DataRead["productClassName"].ToString();
            }
            return productClass;
        }

        /*������Ʒ���ʵ��*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            string sql = "update ProductClass set productClassName=@productClassName where producClassId=@producClassId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassName",SqlDbType.VarChar),
             new SqlParameter("@producClassId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = productClass.productClassName;
            parm[1].Value = productClass.producClassId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ����Ʒ���*/
        public static bool DelProductClass(string p)
        {
            string sql = "delete from ProductClass where producClassId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ��Ʒ���*/
        public static DataSet GetProductClass(string strWhere)
        {
            try
            {
                string strSql = "select * from ProductClass" + strWhere + " order by producClassId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*��ѯ��Ʒ���*/
        public static System.Data.DataTable GetProductClass(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from ProductClass";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "producClassId", strShow, strSql, strWhere, " producClassId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProductClass()
        {
            try
            {
                string strSql = "select * from ProductClass";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
