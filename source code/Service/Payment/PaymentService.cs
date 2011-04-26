using System;
using System.Collections;
using EzPos.DataAccess.Payments;
using EzPos.Properties;

namespace EzPos.Service.Payment
{
    public class PaymentService
    {
        private readonly PaymentDataAccess _PaymentDataAccess;

        public PaymentService(PaymentDataAccess paymentDataAccess)
        {
            _PaymentDataAccess = paymentDataAccess;
        }

        public virtual IList GetPayments()
        {
            return _PaymentDataAccess.GetPayments();
        }

        public virtual IList GetPayments(IList searchCriteria)
        {
            return _PaymentDataAccess.GetPayments(searchCriteria);
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
            _PaymentDataAccess.InsertPayment(payment);
        }

        public virtual void UpdatePayment(Model.Payments.Payment payment)
        {
            _PaymentDataAccess.UpdatePayment(payment);
        }

        public virtual void DeletePayment(Model.Payments.Payment payment)
        {
            _PaymentDataAccess.DeletePayment(payment);
        }
    }
}