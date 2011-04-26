using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess
{
    /// <summary>
    /// Summary description for ProductDataAccess.
    /// </summary>
    public class ProductDataAccess : BaseDataAccess
    {
        public virtual IList GetProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Product.CONST_PRODUCT_CODE)};

            return SelectObjects(typeof (Product), orderList).List();
        }

        public virtual IList GetProducts(IList searchCriteria)
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

            var orderList = new Collection<Order> {Order.Desc(Product.CONST_PRODUCT_CODE)};

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual IList GetProductByID(int productId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ProductID", productId)};

            return SelectObjects(typeof (Product), criterionList).List();
        }

        public virtual Product GetProductByCode(string productCode)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ProductCode", productCode)};

            return (Product) SelectObjects(typeof (Product), criterionList).UniqueResult();
        }

        public virtual IList GetAvailableProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Product.CONST_PRODUCT_CODE)};

            var criterionList = new Collection<ICriterion> {Expression.Gt("QtyInStock", 0)};

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual IList GetUnavailableProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Product.CONST_PRODUCT_CODE)};

            var criterionList = new Collection<ICriterion> {Expression.Le("QtyInStock", 0)};

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual void UpdateProduct(Product product)
        {
            UpdateObject(product);
        }

        public virtual void InsertProduct(Product product)
        {
            InsertObject(product);
        }

        public virtual void DeleteProduct(Product product)
        {
            DeleteObject(product);
        }

        public virtual IList GetProductByPhoto(string photoPath)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("PhotoPath", photoPath)};

            var orderList = new Collection<Order> {Order.Desc(Product.CONST_PRODUCT_CODE)};

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual void InsertProductAdjustment(ProductAdjustment productAdjustment)
        {
            InsertObject(productAdjustment);
        }

        public virtual void UpdateProductAdjustment(ProductAdjustment productAdjustment)
        {
            UpdateObject(productAdjustment);
        }

        public virtual void DeleteProductAdjustment(ProductAdjustment productAdjustment)
        {
            DeleteObject(productAdjustment);
        }
    }
}