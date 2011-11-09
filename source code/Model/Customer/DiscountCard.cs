using System;

namespace EzPos.Model.Customer
{
    /// <summary>
    /// Summary description for DiscountCard.
    /// </summary>
    public class DiscountCard
    {
        public const string ConstCustomerId = "CustomerId";
        public const string ConstDiscountCardId = "DiscountCardId";
        public const string ConstDiscountCardNumber = "CardNumber";

        public int DiscountCardId { get; set; }

        public string CardNumber { get; set; }

        public float DiscountPercentage { get; set; }

        public int DiscountCardTypeId { get; set; }

        public string DiscountCardTypeStr { get; set; }

        public int CustomerId { get; set; }

        public string CustomerStr { get; set; }

        public DateTime ExpireDate { get; set; }

        public int AllowDiscount { get; set; }
    }
}