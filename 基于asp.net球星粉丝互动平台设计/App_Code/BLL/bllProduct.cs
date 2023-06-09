using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*商品业务逻辑层*/
    public class bllProduct{
        /*添加商品*/
        public static bool AddProduct(ENTITY.Product product)
        {
            return DAL.dalProduct.AddProduct(product);
        }

        /*根据productId获取某条商品记录*/
        public static ENTITY.Product getSomeProduct(int productId)
        {
            return DAL.dalProduct.getSomeProduct(productId);
        }

        /*更新商品*/
        public static bool EditProduct(ENTITY.Product product)
        {
            return DAL.dalProduct.EditProduct(product);
        }

        /*删除商品*/
        public static bool DelProduct(string p)
        {
            return DAL.dalProduct.DelProduct(p);
        }

        /*查询商品*/
        public static System.Data.DataSet GetProduct(string strWhere)
        {
            return DAL.dalProduct.GetProduct(strWhere);
        }

        /*根据条件分页查询商品*/
        public static System.Data.DataTable GetProduct(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProduct.GetProduct(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的商品*/
        public static System.Data.DataSet getAllProduct()
        {
            return DAL.dalProduct.getAllProduct();
        }
    }
}
