using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*����ҵ���߼���*/
    public class bllPostInfo{
        /*�������*/
        public static bool AddPostInfo(ENTITY.PostInfo postInfo)
        {
            return DAL.dalPostInfo.AddPostInfo(postInfo);
        }

        /*����postInfoId��ȡĳ�����Ӽ�¼*/
        public static ENTITY.PostInfo getSomePostInfo(int postInfoId)
        {
            return DAL.dalPostInfo.getSomePostInfo(postInfoId);
        }

        /*��������*/
        public static bool EditPostInfo(ENTITY.PostInfo postInfo)
        {
            return DAL.dalPostInfo.EditPostInfo(postInfo);
        }

        /*ɾ������*/
        public static bool DelPostInfo(string p)
        {
            return DAL.dalPostInfo.DelPostInfo(p);
        }

        /*��ѯ����*/
        public static System.Data.DataSet GetPostInfo(string strWhere)
        {
            return DAL.dalPostInfo.GetPostInfo(strWhere);
        }

        /*����������ҳ��ѯ����*/
        public static System.Data.DataTable GetPostInfo(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalPostInfo.GetPostInfo(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*��ѯ���е�����*/
        public static System.Data.DataSet getAllPostInfo()
        {
            return DAL.dalPostInfo.getAllPostInfo();
        }
    }
}
