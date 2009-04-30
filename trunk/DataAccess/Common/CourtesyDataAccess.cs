using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    public class CourtesyDataAccess : BaseDataAccess
    {
        public virtual IList GetCourtesies()
        {
            try
            {
                var orderList = new List<Order>();
                orderList.Add(Order.Asc("CourtesyName"));

                return SelectObjects(typeof (Courtesy),
                                     orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertCourtesy(Courtesy Courtesy)
        {
            try
            {
                InsertObject(Courtesy);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}