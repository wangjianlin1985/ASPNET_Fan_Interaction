using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllThumbsUp{
        /*��ӵ���*/
        public static bool AddThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            return DAL.dalThumbsUp.AddThumbsUp(thumbsUp);
        }

        /*����thumbsUpId��ȡĳ�����޼�¼*/
        public static ENTITY.ThumbsUp getSomeThumbsUp(int thumbsUpId)
        {
            return DAL.dalThumbsUp.getSomeThumbsUp(thumbsUpId);
        }

        /*���µ���*/
        public static bool EditThumbsUp(ENTITY.ThumbsUp thumbsUp)
        {
            return DAL.dalThumbsUp.EditThumbsUp(thumbsUp);
        }

        /*ɾ������*/
        public static bool DelThumbsUp(string p)
        {
            return DAL.dalThumbsUp.DelThumbsUp(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetThumbsUp(string strWhere)
        {
            return DAL.dalThumbsUp.GetThumbsUp(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetThumbsUp(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalThumbsUp.GetThumbsUp(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���еĵ���*/
        public static System.Data.DataSet getAllThumbsUp()
        {
            return DAL.dalThumbsUp.getAllThumbsUp();
        }
    }
}
