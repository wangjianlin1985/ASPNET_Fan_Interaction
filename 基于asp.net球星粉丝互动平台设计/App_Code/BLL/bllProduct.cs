using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*��Ʒҵ���߼���*/
    public class bllProduct{
        /*�����Ʒ*/
        public static bool AddProduct(ENTITY.Product product)
        {
            return DAL.dalProduct.AddProduct(product);
        }

        /*����productId��ȡĳ����Ʒ��¼*/
        public static ENTITY.Product getSomeProduct(int productId)
        {
            return DAL.dalProduct.getSomeProduct(productId);
        }

        /*������Ʒ*/
        public static bool EditProduct(ENTITY.Product product)
        {
            return DAL.dalProduct.EditProduct(product);
        }

        /*ɾ����Ʒ*/
        public static bool DelProduct(string p)
        {
            return DAL.dalProduct.DelProduct(p);
        }

        /*��ѯ��Ʒ*/
        public static System.Data.DataSet GetProduct(string strWhere)
        {
            return DAL.dalProduct.GetProduct(strWhere);
        }

        /*����������ҳ��ѯ��Ʒ*/
        public static System.Data.DataTable GetProduct(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalProduct.GetProduct(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е���Ʒ*/
        public static System.Data.DataSet getAllProduct()
        {
            return DAL.dalProduct.getAllProduct();
        }
    }
}
