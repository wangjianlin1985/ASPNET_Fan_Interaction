using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /*订单状态业务逻辑层*/
    public class bllOrderState{
        /*添加订单状态*/
        public static bool AddOrderState(ENTITY.OrderState orderState)
        {
            return DAL.dalOrderState.AddOrderState(orderState);
        }

        /*根据stateId获取某条订单状态记录*/
        public static ENTITY.OrderState getSomeOrderState(int stateId)
        {
            return DAL.dalOrderState.getSomeOrderState(stateId);
        }

        /*更新订单状态*/
        public static bool EditOrderState(ENTITY.OrderState orderState)
        {
            return DAL.dalOrderState.EditOrderState(orderState);
        }

        /*删除订单状态*/
        public static bool DelOrderState(string p)
        {
            return DAL.dalOrderState.DelOrderState(p);
        }

        /*查询订单状态*/
        public static System.Data.DataSet GetOrderState(string strWhere)
        {
            return DAL.dalOrderState.GetOrderState(strWhere);
        }

        /*根据条件分页查询订单状态*/
        public static System.Data.DataTable GetOrderState(int NowPage, int PageSize, out int AllPage, out int DataCount, string p)
        {
            return DAL.dalOrderState.GetOrderState(NowPage, PageSize, out AllPage, out DataCount, p);
        }
        /*查询所有的订单状态*/
        public static System.Data.DataSet getAllOrderState()
        {
            return DAL.dalOrderState.getAllOrderState();
        }
    }
}
