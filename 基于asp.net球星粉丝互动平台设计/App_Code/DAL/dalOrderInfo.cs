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
    public class dalOrderInfo
    {
        /*��ִ�е�sql���*/
        public static string sql = "";

        /*��Ӷ���ʵ��*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "insert into OrderInfo(productObj,userObj,orderTime,orderStateObj) values(@productObj,@userObj,@orderTime,@orderStateObj)";
            /*����sql����*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderStateObj",SqlDbType.Int)
            };
            /*��������ֵ*/
            parm[0].Value = orderInfo.productObj; //������Ʒ
            parm[1].Value = orderInfo.userObj; //�����û�
            parm[2].Value = orderInfo.orderTime; //�µ�ʱ��
            parm[3].Value = orderInfo.orderStateObj; //����״̬

            /*ִ��sql�������*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*����orderId��ȡĳ��������¼*/
        public static ENTITY.OrderInfo getSomeOrderInfo(int orderId)
        {
            /*������ѯsql*/
            string sql = "select * from OrderInfo where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = null;
            /*�����ѯ���ڼ�¼���Ͱ�װ�������з���*/
            if (DataRead.Read())
            {
                orderInfo = new ENTITY.OrderInfo();
                orderInfo.orderId = Convert.ToInt32(DataRead["orderId"]);
                orderInfo.productObj = Convert.ToInt32(DataRead["productObj"]);
                orderInfo.userObj = DataRead["userObj"].ToString();
                orderInfo.orderTime = Convert.ToDateTime(DataRead["orderTime"].ToString());
                orderInfo.orderStateObj = Convert.ToInt32(DataRead["orderStateObj"]);
            }
            return orderInfo;
        }

        /*���¶���ʵ��*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set productObj=@productObj,userObj=@userObj,orderTime=@orderTime,orderStateObj=@orderStateObj where orderId=@orderId";
            /*����sql������Ϣ*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderStateObj",SqlDbType.Int),
             new SqlParameter("@orderId",SqlDbType.Int)
            };
            /*Ϊ������ֵ*/
            parm[0].Value = orderInfo.productObj;
            parm[1].Value = orderInfo.userObj;
            parm[2].Value = orderInfo.orderTime;
            parm[3].Value = orderInfo.orderStateObj;
            parm[4].Value = orderInfo.orderId;
            /*ִ�и���*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*ɾ������*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "delete from OrderInfo where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*��ѯ����*/
        public static DataSet GetOrderInfo(string strWhere)
        {
            try
            {
                string strSql = "select * from OrderInfo" + strWhere + " order by orderId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

  

        /*��ѯ����*/
        public static System.Data.DataTable GetOrderInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderInfo";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "orderId", strShow, strSql, strWhere, " orderId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /*���۷���ѯ����*/
        public static System.Data.DataTable sellerGetOrderInfo(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from OrderInfoView";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "orderId", strShow, strSql, strWhere, " orderId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllOrderInfo()
        {
            try
            {
                string strSql = "select * from OrderInfo";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
