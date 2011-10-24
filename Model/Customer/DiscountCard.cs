using System;

namespace EzPos.Model
{
    /// <summary>
    /// Summary description for DiscountCard.
    /// </summary>
    public class DiscountCard
    {
        public const string CONST_CUSTOMER_ID = "CustomerID";
        public const string CONST_DISCOUNT_CARD_ID = "DiscountCardID";
        public const string CONST_DISCOUNT_CARD_NUMBER = "CardNumber";

        public int DiscountCardID { get; set; }

        public string CardNumber { get; set; }

        public float DiscountPercentage { get; set; }

        public int DiscountCardTypeID { get; set; }

        public string DiscountCardTypeStr { get; set; }

        public int CustomerID { get; set; }

        public string CustomerStr { get; set; }

        public DateTime ExpireDate { get; set; }

        public int AllowDiscount { get; set; }
    }
}