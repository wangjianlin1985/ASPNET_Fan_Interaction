using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*球星关注业务逻辑层*/
    public class bllStarFollow{
        /*添加球星关注*/
        public static bool AddStarFollow(ENTITY.StarFollow starFollow)
        {
            return DAL.dalStarFollow.AddStarFollow(starFollow);
        }

        /*根据followId获取某条球星关注记录*/
        public static ENTITY.StarFollow getSomeStarFollow(int followId)
        {
            return DAL.dalStarFollow.getSomeStarFollow(followId);
        }

        /*更新球星关注*/
        public static bool EditStarFollow(ENTITY.StarFollow starFollow)
        {
            return DAL.dalStarFollow.EditStarFollow(starFollow);
        }

        /*删除球星关注*/
        public static bool DelStarFollow(string p)
        {
            return DAL.dalStarFollow.DelStarFollow(p);
        }

        /*查询球星关注*/
        public static System.Data.DataSet GetStarFollow(string strWhere)
        {
            return DAL.dalStarFollow.GetStarFollow(strWhere);
        }

        /*根据条件分页查询球星关注*/
        public static System.Data.DataTable GetStarFollow(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalStarFollow.GetStarFollow(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的球星关注*/
        public static System.Data.DataSet getAllStarFollow()
        {
            return DAL.dalStarFollow.getAllStarFollow();
        }
    }
}
