using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*���ӻظ�ҵ���߼���*/
    public class bllReply{
        /*������ӻظ�*/
        public static bool AddReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.AddReply(reply);
        }

        /*����replyId��ȡĳ�����ӻظ���¼*/
        public static ENTITY.Reply getSomeReply(int replyId)
        {
            return DAL.dalReply.getSomeReply(replyId);
        }

        /*�������ӻظ�*/
        public static bool EditReply(ENTITY.Reply reply)
        {
            return DAL.dalReply.EditReply(reply);
        }

        /*ɾ�����ӻظ�*/
        public static bool DelReply(string p)
        {
            return DAL.dalReply.DelReply(p);
        }

        /*��ѯ���ӻظ�*/
        public static System.Data.DataSet GetReply(string strWhere)
        {
            return DAL.dalReply.GetReply(strWhere);
        }

        /*����������ҳ��ѯ���ӻظ�*/
        public static System.Data.DataTable GetReply(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalReply.GetReply(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е����ӻظ�*/
        public static System.Data.DataSet getAllReply()
        {
            return DAL.dalReply.getAllReply();
        }
    }
}
