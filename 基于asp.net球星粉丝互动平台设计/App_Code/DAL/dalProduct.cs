using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

using ENTITY;

namespace DAL
{
    /*商品业务逻辑层实现*/
    public class dalProduct
    {
        /*待执行的sql语句*/
        public static string sql = "";

        /*添加商品实现*/
        public static bool AddProduct(ENTITY.Product product)
        {
            string sql = "insert into Product(productClassObj,productName,productPhoto,productDesc,price,productState,userObj,addTime) values(@productClassObj,@productName,@productPhoto,@productDesc,@price,@productState,@userObj,@addTime)";
            /*构建sql参数*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@productDesc",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@productState",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime)
            };
            /*给参数赋值*/
            parm[0].Value = product.productClassObj; //商品类别
            parm[1].Value = product.productName; //宝贝名称
            parm[2].Value = product.productPhoto; //商品图片
            parm[3].Value = product.productDesc; //宝贝描述
            parm[4].Value = product.price; //售价
            parm[5].Value = product.productState; //商品状态
            parm[6].Value = product.userObj; //发布用户
            parm[7].Value = product.addTime; //发布时间

            /*执行sql进行添加*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }

        /*根据productId获取某条商品记录*/
        public static ENTITY.Product getSomeProduct(int productId)
        {
            /*构建查询sql*/
            string sql = "select * from Product where productId=" + productId;
            SqlDataReader DataRead = DBHelp.ExecuteReader(sql, null);
            ENTITY.Product product = null;
            /*如果查询存在记录，就包装到对象中返回*/
            if (DataRead.Read())
            {
                product = new ENTITY.Product();
                product.productId = Convert.ToInt32(DataRead["productId"]);
                product.productClassObj = Convert.ToInt32(DataRead["productClassObj"]);
                product.productName = DataRead["productName"].ToString();
                product.productPhoto = DataRead["productPhoto"].ToString();
                product.productDesc = DataRead["productDesc"].ToString();
                product.price = float.Parse(DataRead["price"].ToString());
                product.productState = DataRead["productState"].ToString();
                product.userObj = DataRead["userObj"].ToString();
                product.addTime = Convert.ToDateTime(DataRead["addTime"].ToString());
            }
            return product;
        }

        /*更新商品实现*/
        public static bool EditProduct(ENTITY.Product product)
        {
            string sql = "update Product set productClassObj=@productClassObj,productName=@productName,productPhoto=@productPhoto,productDesc=@productDesc,price=@price,productState=@productState,userObj=@userObj,addTime=@addTime where productId=@productId";
            /*构建sql参数信息*/
            SqlParameter[] parm = new SqlParameter[] {
             new SqlParameter("@productClassObj",SqlDbType.Int),
             new SqlParameter("@productName",SqlDbType.VarChar),
             new SqlParameter("@productPhoto",SqlDbType.VarChar),
             new SqlParameter("@productDesc",SqlDbType.VarChar),
             new SqlParameter("@price",SqlDbType.Float),
             new SqlParameter("@productState",SqlDbType.VarChar),
             new SqlParameter("@userObj",SqlDbType.VarChar),
             new SqlParameter("@addTime",SqlDbType.DateTime),
             new SqlParameter("@productId",SqlDbType.Int)
            };
            /*为参数赋值*/
            parm[0].Value = product.productClassObj;
            parm[1].Value = product.productName;
            parm[2].Value = product.productPhoto;
            parm[3].Value = product.productDesc;
            parm[4].Value = product.price;
            parm[5].Value = product.productState;
            parm[6].Value = product.userObj;
            parm[7].Value = product.addTime;
            parm[8].Value = product.productId;
            /*执行更新*/
            return (DBHelp.ExecuteNonQuery(sql, parm) > 0) ? true : false;
        }


        /*删除商品*/
        public static bool DelProduct(string p)
        {
            string sql = "delete from Product where productId in (" + p + ") ";
            return ((DBHelp.ExecuteNonQuery(sql, null)) > 0) ? true : false;
        }


        /*查询商品*/
        public static DataSet GetProduct(string strWhere)
        {
            try
            {
                string strSql = "select * from Product" + strWhere + " order by productId asc";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /*查询商品*/
        public static System.Data.DataTable GetProduct(int PageIndex, int PageSize, out int PageCount, out int RecordCount, string strWhere)
        {
            try
            {
                string strSql = " select * from Product";
                string strShow = "*";
                return DAL.DBHelp.ExecutePager(PageIndex, PageSize, "productId", strShow, strSql, strWhere, " productId asc ", out PageCount, out RecordCount);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public static DataSet getAllProduct()
        {
            try
            {
                string strSql = "select * from Product";
                return DBHelp.ExecuteDataSet(strSql, null);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


    }
}
