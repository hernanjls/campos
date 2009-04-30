using System.Collections;
using System.Collections.Generic;
using EzPos.Model;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for SupplierContactDataAccess.
    /// </summary>
    public class SupplierContactDataAccess : BaseDataAccess
    {
        public virtual IList GetSupplierContacts()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(SupplierContact.CONST_CONTACT_NAME));

            return SelectObjects(typeof (SupplierContact), orderList).List();
        }
    }
}