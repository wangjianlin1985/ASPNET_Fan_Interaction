using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品类别业务逻辑层*/
    public class bllProductClass{
        /*添加商品类别*/
        public static bool AddProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.AddProductClass(productClass);
        }

        /*根据producClassId获取某条商品类别记录*/
        public static ENTITY.ProductClass getSomeProductClass(int producClassId)
        {
            return DAL.dalProductClass.getSomeProductClass(producClassId);
        }

        /*更新商品类别*/
        public static bool EditProductClass(ENTITY.ProductClass productClass)
        {
            return DAL.dalProductClass.EditProductClass(productClass);
        }

        /*删除商品类别*/
        public static bool DelProductClass(string p)
        {
            return DAL.dalProductClass.DelProductClass(p);
        }

        /*查询商品类别*/
        public static System.Data.DataSet GetProductClass(string strWhere)
        {
            return DAL.dalProductClass.GetProductClass(strWhere);
        }

        /*根据条件分页查询商品类别*/
        public static System.Data.DataTable GetProductClass(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProductClass.GetProductClass(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品类别*/
        public static System.Data.DataSet getAllProductClass()
        {
            return DAL.dalProductClass.getAllProductClass();
        }
    }
}
