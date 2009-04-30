using System;
using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for BarCodeDataAccess.
    /// </summary>
    public class BarCodeDataAccess : BaseDataAccess
    {
        public virtual IList GetBarCodes()
        {
            try
            {
                var orderList = new List<Order>();
                orderList.Add(Order.Asc(BarCode.CONST_BARCODE_ID));

                return SelectObjects(typeof (BarCode), orderList).List();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertBarCode(BarCode barCode)
        {
            try
            {
                InsertObject(barCode);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}