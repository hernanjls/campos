using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model.Payments;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess.Payments
{
    public class PaymentDataAccess : BaseDataAccess
    {
        public virtual IList GetPayments()
        {
            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Payment.ConstSaleOrderId),
                                    Order.Asc(Payment.ConstPaymentDate)
                                };

            return SelectObjects(typeof (Payment), orderList).List();
        }

        public virtual IList GetPayments(IList searchCriteria)
        {
            var criterionList = new Collection<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    var delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(Expression.Eq(
                                              StringHelper.Left(strCriteria, delimiterIndex),
                                              StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = new Collection<Order>
                                {
                                    Order.Asc(Payment.ConstSaleOrderId),
                                    Order.Asc(Payment.ConstPaymentDate)
                                };

            return SelectObjects(typeof(Payment), criterionList, orderList).List();
        }

        public virtual void InsertPayment(Payment payment)
        {
            InsertObject(payment);
        }

        public virtual void UpdatePayment(Payment payment)
        {
            UpdateObject(payment);
        }

        public virtual void DeletePayment(Payment payment)
        {
            DeleteObject(payment);
        }
    }
}