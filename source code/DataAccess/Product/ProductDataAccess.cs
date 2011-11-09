using System.Collections;
using System.Collections.ObjectModel;
using EzPos.Model.Product;
using EzPos.Utility;
using NHibernate.Expression;

namespace EzPos.DataAccess.Product
{
    /// <summary>
    /// Summary description for ProductDataAccess.
    /// </summary>
    public class ProductDataAccess : BaseDataAccess
    {
        public virtual IList GetProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Model.Product.Product.ConstProductCode)};

            return SelectObjects(typeof (Model.Product.Product), orderList).List();
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

            var orderList = new Collection<Order> {Order.Desc(Model.Product.Product.ConstProductCode)};

            return SelectObjects(typeof (Model.Product.Product), criterionList, orderList).List();
        }

        public virtual IList GetProductById(int productId)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ProductId", productId)};

            return SelectObjects(typeof (Model.Product.Product), criterionList).List();
        }

        public virtual Model.Product.Product GetProductByCode(string productCode)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("ProductCode", productCode)};

            return (Model.Product.Product) SelectObjects(typeof (Model.Product.Product), criterionList).UniqueResult();
        }

        public virtual IList GetAvailableProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Model.Product.Product.ConstProductCode)};

            var criterionList = new Collection<ICriterion> {Expression.Gt("QtyInStock", 0)};

            return SelectObjects(typeof (Model.Product.Product), criterionList, orderList).List();
        }

        public virtual IList GetUnavailableProducts()
        {
            var orderList = new Collection<Order> {Order.Desc(Model.Product.Product.ConstProductCode)};

            var criterionList = new Collection<ICriterion> {Expression.Le("QtyInStock", 0)};

            return SelectObjects(typeof (Model.Product.Product), criterionList, orderList).List();
        }

        public virtual void UpdateProduct(Model.Product.Product product)
        {
            UpdateObject(product);
        }

        public virtual void InsertProduct(Model.Product.Product product)
        {
            InsertObject(product);
        }

        public virtual void DeleteProduct(Model.Product.Product product)
        {
            DeleteObject(product);
        }

        public virtual IList GetProductByPhoto(string photoPath)
        {
            var criterionList = new Collection<ICriterion> {Expression.Eq("PhotoPath", photoPath)};

            var orderList = new Collection<Order> {Order.Desc(Model.Product.Product.ConstProductCode)};

            return SelectObjects(typeof (Model.Product.Product), criterionList, orderList).List();
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