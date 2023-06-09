using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ǹ�עҵ���߼���*/
    public class bllStarFollow{
        /*������ǹ�ע*/
        public static bool AddStarFollow(ENTITY.StarFollow starFollow)
        {
            return DAL.dalStarFollow.AddStarFollow(starFollow);
        }

        /*����followId��ȡĳ�����ǹ�ע��¼*/
        public static ENTITY.StarFollow getSomeStarFollow(int followId)
        {
            return DAL.dalStarFollow.getSomeStarFollow(followId);
        }

        /*�������ǹ�ע*/
        public static bool EditStarFollow(ENTITY.StarFollow starFollow)
        {
            return DAL.dalStarFollow.EditStarFollow(starFollow);
        }

        /*ɾ�����ǹ�ע*/
        public static bool DelStarFollow(string p)
        {
            return DAL.dalStarFollow.DelStarFollow(p);
        }

        /*��ѯ���ǹ�ע*/
        public static System.Data.DataSet GetStarFollow(string strWhere)
        {
            return DAL.dalStarFollow.GetStarFollow(strWhere);
        }

        /*����������ҳ��ѯ���ǹ�ע*/
        public static System.Data.DataTable GetStarFollow(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStarFollow.GetStarFollow(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ǹ�ע*/
        public static System.Data.DataSet getAllStarFollow()
        {
            return DAL.dalStarFollow.getAllStarFollow();
        }
    }
}
