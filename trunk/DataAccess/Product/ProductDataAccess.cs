using System;
using System.Collections;
using System.Collections.Generic;
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
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (Product), orderList).List();
        }

        public virtual Product GetProducts(int productID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", productID));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return (Product) SelectObjects(typeof (Product), criterionList, orderList).UniqueResult();
        }

        public virtual IList GetProducts(IList searchCriteria)
        {
            var criterionList = new List<ICriterion>();
            if (searchCriteria != null)
            {
                foreach (string strCriteria in searchCriteria)
                {
                    int delimiterIndex = strCriteria.IndexOf("|");
                    if (delimiterIndex >= 0)
                        criterionList.Add(Expression.Eq(
                                              StringHelper.Left(strCriteria, delimiterIndex),
                                              StringHelper.Right(strCriteria, strCriteria.Length - delimiterIndex - 1)));
                    else
                        criterionList.Add(Expression.Sql(strCriteria));
                }
            }

            var orderList = new List<Order> {Order.Desc(Product.CONST_PRODUCT_NAME)};

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual IList GetAvailableProducts()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(
                Expression.Sql("(QtyInStock > 0) OR (ProductID IN (SELECT DISTINCT ProductID FROM TSaleItems))"));

            //criterionList.Add(Expression.Gt("QtyInStock", 0));
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Product.CONST_PRODUCT_NAME));

            return SelectObjects(typeof (Product), criterionList, orderList).List();
        }

        public virtual IList GetAvailableProductsDetail()
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(
                Expression.Sql(
                    "ProductID IN (SELECT ProductID FROM TProducts WHERE ((QtyInStock > 0) OR (ProductID IN (SELECT DISTINCT ProductID FROM TSaleItems))))"));
            //criterionList.Add(Expression.Sql("ProductID IN (SELECT ProductID FROM TProducts WHERE QtyInStock > 0)"));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseItem.CONST_PRODUCT_ID));

            return SelectObjects(
                typeof (PurchaseItem), criterionList, orderList).List();
        }

        public virtual IList GetProductsFromPurchaseHistory(string barCodeStr)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("BarCodeValue", barCodeStr));

            var orderList = new List<Order>();
            orderList.Add(Order.Desc(PurchaseItem.CONST_PRODUCT_ID));
            orderList.Add(Order.Desc(PurchaseItem.CONST_PURCHASE_ORDER_ID));
            orderList.Add(Order.Desc(PurchaseItem.CONST_PURCHASE_ITEM_ID));

            return SelectObjects(
                typeof (PurchaseItem), criterionList, orderList).List();
        }

        public virtual IList GetProductsFromPurchaseHistory(int productID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", productID));

            var orderList = new List<Order>();
            orderList.Add(Order.Desc(PurchaseItem.CONST_PRODUCT_ID));
            orderList.Add(Order.Desc(PurchaseItem.CONST_PURCHASE_ORDER_ID));
            orderList.Add(Order.Desc(PurchaseItem.CONST_PURCHASE_ITEM_ID));

            return SelectObjects(
                typeof (PurchaseItem), criterionList, orderList).List();
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

        /////////////////Category
        public virtual IList GetCategories()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(ProductCategory.CONST_CATEGORY_NAME));

            return SelectObjects(typeof (ProductCategory), orderList).List();
        }

        public virtual void InsertProductCategory(ProductCategory productCategory)
        {
            InsertObject(productCategory);
        }

        public virtual void DeleteProductCategory(ProductCategory productCategory)
        {
            DeleteObject(productCategory);
        }

        public virtual void UpdateProductCategory(ProductCategory productCategory)
        {
            UpdateObject(productCategory);
        }

        //////////////////////////////PurchaseItem
        public virtual PurchaseItem GetAPurchaseItem(int productID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", productID));

            return (PurchaseItem) SelectObjects(
                                      typeof (PurchaseItem),
                                      criterionList).UniqueResult();
        }

        public virtual IList GetPurchaseItems()
        {
            return SelectObjects(typeof (PurchaseItem)).List();
        }

        public virtual IList GetPurchaseItemsByPurchaseOrder(int PurchaseOrderID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PurchaseOrderID", PurchaseOrderID));

            return SelectObjects(
                typeof (PurchaseItem),
                criterionList).List();
        }

        public virtual IList GetPurchaseItemsByProduct(int ProductID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", ProductID));

            return SelectObjects(
                typeof (PurchaseItem),
                criterionList).List();
        }

        public virtual void InsertPurchaseItem(PurchaseItem purchaseItem)
        {
            InsertObject(purchaseItem);
        }

        public virtual void UpdatePurchaseItem(PurchaseItem purchaseItem)
        {
            UpdateObject(purchaseItem);
        }

        public virtual void DeletePurchaseItem(PurchaseItem purchaseItem)
        {
            DeleteObject(purchaseItem);
        }

        ///////////////////// Product Unit
        public virtual IList GetProductUnits()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(ProductUnit.CONST_UNIT_NAME));

            return SelectObjects(typeof (ProductUnit), orderList).List();
        }

        public virtual void InsertProductUnit(ProductUnit productUnit)
        {
            InsertObject(productUnit);
        }

        public virtual void UpdateProductUnit(ProductUnit productUnit)
        {
            UpdateObject(productUnit);
        }

        public virtual void DeleteProductUnit(ProductUnit productUnit)
        {
            DeleteObject(productUnit);
        }

        //////////////////////////// SaleItem
        public virtual SaleItem GetASaleItem(int productID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", productID));

            return (SaleItem) SelectObjects(
                                  typeof (SaleItem),
                                  criterionList).UniqueResult();
        }

        /////////////////////////PuchaseOrder
        public virtual IList GetPurchaseOrders()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrder.CONST_PURCHASE_ORDER_ID));

            return SelectObjects(typeof (PurchaseOrder), orderList).List();
        }

        public virtual IList GetPurchaseOrders(String poNumber)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("PurchaseOrderNumber", poNumber));

            var orderList = new List<Order>();
            orderList.Add(Order.Asc(PurchaseOrder.CONST_PURCHASE_ORDER_NUMBER));

            return SelectObjects(
                typeof (PurchaseOrder),
                criterionList,
                orderList).List();
        }

        public virtual void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            UpdateObject(purchaseOrder);
        }

        public virtual void InsertPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            InsertObject(purchaseOrder);
        }

        //ProductLocation
        public virtual IList GetLocations()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(ProductLocation.CONST_CELL_NAME));

            return SelectObjects(
                typeof (ProductLocation),
                orderList).List();
        }

        public virtual void InsertLocation(ProductLocation productLocation)
        {
            InsertObject(productLocation);
        }

        public virtual void UpdateLocation(ProductLocation productLocation)
        {
            UpdateObject(productLocation);
        }

        public virtual void DeleteLocation(ProductLocation productLocation)
        {
            DeleteObject(productLocation);
        }

        //Cabinet
        public virtual IList GetCabinets()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Cabinet.CONST_CABINET_NAME));

            return SelectObjects(
                typeof (Cabinet),
                orderList).List();
        }

        public virtual void InsertCabinet(Cabinet cabinet)
        {
            InsertObject(cabinet);
        }

        //Laboratory
        public virtual IList GetLaboratories()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Laboratory.CONST_LABORATORY_NAME));

            return SelectObjects(
                typeof (Laboratory),
                orderList).List();
        }

        public virtual void InsertLaboratory(Laboratory laboratory)
        {
            InsertObject(laboratory);
        }

        public virtual void UpdateLaboratory(Laboratory laboratory)
        {
            UpdateObject(laboratory);
        }

        public virtual void DeleteLaboratory(Laboratory laboratory)
        {
            DeleteObject(laboratory);
        }

        //Country
        public virtual IList GetCountries()
        {
            var orderList = new List<Order>();
            orderList.Add(Order.Asc(Country.CONST_COUNTRY_NAME));

            return SelectObjects(typeof (Country), orderList).List();
        }

        public virtual void InsertCountry(Country country)
        {
            InsertObject(country);
        }

        public virtual void UpdateCountry(Country country)
        {
            UpdateObject(country);
        }

        public virtual void DeleteCountry(Country country)
        {
            DeleteObject(country);
        }

        ///////////////        
        public virtual IList GetSaleItemsByProduct(int ProductID)
        {
            var criterionList = new List<ICriterion>();
            criterionList.Add(Expression.Eq("ProductID", ProductID));

            return SelectObjects(
                typeof (SaleItem),
                criterionList).List();
        }
    }
}