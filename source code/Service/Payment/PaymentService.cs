using System;
using System.Collections;
using EzPos.DataAccess.Payments;
using EzPos.Properties;

namespace EzPos.Service.Payment
{
    public class PaymentService
    {
        private readonly PaymentDataAccess _paymentDataAccess;

        public PaymentService(PaymentDataAccess paymentDataAccess)
        {
            _paymentDataAccess = paymentDataAccess;
        }

        public virtual IList GetPayments()
        {
            return _paymentDataAccess.GetPayments();
        }

        public virtual IList GetPayments(IList searchCriteria)
        {
            return _paymentDataAccess.GetPayments(searchCriteria);
        }

        public void ManagePayment(string requestCode, Model.Payments.Payment payment)
        {
            if(string.IsNullOrEmpty(requestCode))
                throw new ArgumentNullException(string.Empty, string.Empty);

            if(payment == null)
                throw new ArgumentNullException(string.Empty, string.Empty);

            if(requestCode.Equals(Resources.OperationRequestInsert))
            {
                InsertPayment(payment);
            }
            else if(requestCode.Equals(Resources.OperationRequestUpdate))
            {
                UpdatePayment(payment);
            }
            else
            {
                DeletePayment(payment);
            }
        }

        public virtual void InsertPayment(Model.Payments.Payment payment)
        {
            _paymentDataAccess.InsertPayment(payment);
        }

        public virtual void UpdatePayment(Model.Payments.Payment payment)
        {
            _paymentDataAccess.UpdatePayment(payment);
        }

        public virtual void DeletePayment(Model.Payments.Payment payment)
        {
            _paymentDataAccess.DeletePayment(payment);
        }
    }
}