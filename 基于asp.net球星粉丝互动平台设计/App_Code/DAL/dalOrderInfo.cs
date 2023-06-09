using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*订单业务逻辑层实现*/
    public class dalOrderInfo
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加订单实现*/
        public static bool AddOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "insert into OrderInfo(productObj,userObj,orderTime,orderStateObj) values(@productObj,@userObj,@orderTime,@orderStateObj)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderStateObj",SqlDbType.Int)
            };
            /*给参数赋值*/
            parm[0].Value = orderInfo.productObj; //购买商品
            parm[1].Value = orderInfo.userObj; //购买用户
            parm[2].Value = orderInfo.orderTime; //下单时间
            parm[3].Value = orderInfo.orderStateObj; //订单状态

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据orderId获取某条订单记录*/
        public static ENTITY.OrderInfo getSomeOrderInfo(int orderId)
        {
            /*构建查询sql*/
            string sql = "select * from OrderInfo where orderId=" + orderId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.OrderInfo orderInfo = null;
            /*如果查询存在记录，就包装到对象中返回*/
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

        /*更新订单实现*/
        public static bool EditOrderInfo(ENTITY.OrderInfo orderInfo)
        {
            string sql = "update OrderInfo set productObj=@productObj,userObj=@userObj,orderTime=@orderTime,orderStateObj=@orderStateObj where orderId=@orderId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productObj",SqlDbType.Int),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@orderTime",SqlDbType.DateTime),
             new SqlParameter("@orderStateObj",SqlDbType.Int),
             new SqlParameter("@orderId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = orderInfo.productObj;
            parm[1].Value = orderInfo.userObj;
            parm[2].Value = orderInfo.orderTime;
            parm[3].Value = orderInfo.orderStateObj;
            parm[4].Value = orderInfo.orderId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除订单*/
        public static bool DelOrderInfo(string p)
        {
            string sql = "delete from OrderInfo where orderId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询订单*/
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

  

        /*查询订单*/
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



        /*销售方查询订单*/
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
