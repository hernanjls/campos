using System;
using System.Collections;
using System.Collections.Generic;
using Castle.Services.Transaction;
using EzPos.DataAccess;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service
{
    /// <summary>
    /// Summary description for ProductService.
    /// </summary>
    [Transactional]
    public class ProductService
    {
        private readonly ProductDataAccess _ProductDataAccess;

        public ProductService(ProductDataAccess productDataAccess)
        {
            _ProductDataAccess = productDataAccess;
        }

        public virtual IList GetProducts()
        {
            try
            {
                return _ProductDataAccess.GetProducts();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual Product GetProducts(int productID)
        {
            return _ProductDataAccess.GetProducts(productID);
        }

        public virtual IList GetProducts(IList searchCriteria)
        {
            return _ProductDataAccess.GetProducts(searchCriteria);
        }

        public virtual IList GetAvailableProducts()
        {
            try
            {
                return _ProductDataAccess.GetAvailableProducts();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetAvailableProductsDetail()
        {
            try
            {
                return _ProductDataAccess.GetAvailableProductsDetail();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetProductsFromPurchaseHistory(string barCodeValue)
        {
            try
            {
                return _ProductDataAccess.GetProductsFromPurchaseHistory(barCodeValue);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetProductsFromPurchaseHistory(int productID)
        {
            try
            {
                return _ProductDataAccess.GetProductsFromPurchaseHistory(productID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object ProductManagement(Product product, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (product == null)
                throw new ArgumentNullException("Product", "Product");

            if (requestCode == Resources.OperationRequestInsert)
            {
                product.LastExpire = DateTime.Now.AddMonths(3);
                _ProductDataAccess.InsertProduct(product);

                BarCodeService barCodeService = ServiceFactory.GenerateServiceInstance().GenerateBarCodeService();
                BarCode barCode = barCodeService.AddBarCode();

                PurchaseOrderService purchaseOrderService =
                    ServiceFactory.GenerateServiceInstance().GeneratePurchaseOrderService();

                var purchaseItem = new PurchaseItem();
                purchaseItem.ProductID = product.ProductID;
                purchaseItem.BarCodeValue = barCode.BarCodeValue;
                purchaseItem.CellID = 1;
                purchaseItem.DateExpire = DateTime.Now;
                purchaseItem.DateIn = DateTime.Now;
                purchaseItem.ProductUnitID = 1;
                purchaseItem.PurchaseOrderID = 0;
                purchaseItem.QtyOut = 0;
                purchaseItem.Quantity = 0;
                purchaseItem.SupplierID = 1;

                var purchaseItemList = new List<PurchaseItem>();
                purchaseItemList.Add(purchaseItem);
                purchaseOrderService.PurchaseItemManagement(0, purchaseItemList);
                return null;
            }
            else if (requestCode == Resources.OperationRequestDuplicate)
            {
                product.LastExpire = DateTime.Now.AddMonths(3);
                product.ProductID = 0;
                _ProductDataAccess.InsertProduct(product);
                return null;
            }
            else if (requestCode == Resources.OperationRequestUpdate)
            {
                _ProductDataAccess.UpdateProduct(product);
                return null;
            }
            else
            {
                return DeleteProduct(product);
            }
        }

        private object DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product", "Product");

            if (!IsDeletable(product))
                return "Product can not be deleted";

            _ProductDataAccess.DeleteProduct(product);
            return null;
        }

        private bool IsDeletable(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("Product", "Product");

            PurchaseItem purchaseItem = _ProductDataAccess.GetAPurchaseItem(product.ProductID);
            if (purchaseItem == null)
            {
                SaleItem saleItem = _ProductDataAccess.GetASaleItem(product.ProductID);
                if (saleItem == null)
                    return true;
                else
                    return false;
            }
            else
                return false;
        }

        public virtual Product UpdateProduct(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("PurchaseItem", "PurchaseItem");

            try
            {
                Product product = GetProducts(purchaseItem.ProductID);
                product.QtyInStock += purchaseItem.Quantity;
                product.UnitPriceIn = purchaseItem.UnitPrice;
                if ((product.ExtraPercentage != 0) || (product.UnitPriceOut == 0))
                    product.UnitPriceOut =
                        product.UnitPriceIn +
                        (product.UnitPriceIn*(product.ExtraPercentage/100));
                product.UnitPriceOut = float.Parse(Math.Round(product.UnitPriceOut, 1).ToString());

                product.LastUpdate = DateTime.Today;
                product.LatestUnitID = purchaseItem.ProductUnitID;
                product.LatestLocationID = purchaseItem.CellID;
                product.LastExpire = (DateTime) purchaseItem.DateExpire;
                product.StoreID = purchaseItem.CellID;

                _ProductDataAccess.UpdateProduct(product);

                return product;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void UpdateProduct(SaleItem saleItem)
        {
            if (saleItem == null)
                throw new ArgumentNullException("SaleItem", "SaleItem");

            try
            {
                Product product = GetProducts(saleItem.ProductID);

                //Update product
                product.QtyInStock -= saleItem.QtyOut;
                product.QtySold += saleItem.QtyOut;
                product.LastUpdate = DateTime.Today;

                _ProductDataAccess.UpdateProduct(product);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /////Category
        public virtual IList GetCategories()
        {
            try
            {
                return _ProductDataAccess.GetCategories();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object ProductCategoryManagement(ProductCategory productCategory, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (productCategory == null)
                throw new ArgumentNullException("Product Unit", "Product Unit");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _ProductDataAccess.InsertProductCategory(productCategory);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    productCategory.CategoryID = 0;
                    _ProductDataAccess.InsertProductCategory(productCategory);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _ProductDataAccess.UpdateProductCategory(productCategory);
                    return null;
                }
                else
                {
                    return DeleteProductCategory(productCategory);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteProductCategory(ProductCategory productCategory)
        {
            if (productCategory == null)
                throw new ArgumentNullException("Product Category", "Product Category");

            _ProductDataAccess.DeleteProductCategory(productCategory);
            return null;
        }

        /////////////////////PurchaseOrder
        public virtual IList GetPurchaseOrders()
        {
            try
            {
                return _ProductDataAccess.GetPurchaseOrders();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual IList GetPurchaseOrders(string poNumber)
        {
            try
            {
                return _ProductDataAccess.GetPurchaseOrders(poNumber);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object PurchaseOrderManagement(PurchaseOrder purchaseOrder, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (purchaseOrder == null)
                throw new ArgumentNullException("PurchaseOrder", "PurchaseOrder");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    //InsertPurchaseItem(purchaseItem);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    //purchaseItem.PurchaseItemID = 0;
                    //InsertPurchaseItem(purchaseItem);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    //UpdatePurchaseItem(purchaseItem);
                    return null;
                }
                else
                {
                    return null;
                    ////////////////////////////////////return DeleteProduct(purchaseItem);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void UpdatePurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                _ProductDataAccess.UpdatePurchaseOrder(purchaseOrder);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual void InsertPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            try
            {
                IList poList = _ProductDataAccess.GetPurchaseOrders();
                string poNumber;
                if (poList.Count == 0)
                {
                    poNumber = "PO-" +
                               StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                               StringHelper.Right("00" + DateTime.Today.Month, 2) + "-1";
                }
                else
                {
                    poNumber = ((PurchaseOrder) poList[poList.Count - 1]).PurchaseOrderNumber;
                    poNumber = StringHelper.Increment(poNumber.Split('-')[3], 1);
                    poNumber = "PO-" +
                               StringHelper.Right(DateTime.Today.Year.ToString(), 2) + "-" +
                               StringHelper.Right("00" + DateTime.Today.Month, 2) + "-" + poNumber;
                }
                purchaseOrder.PurchaseOrderNumber = poNumber;
                _ProductDataAccess.InsertPurchaseOrder(purchaseOrder);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        ///////////////PurchaseItem
        public virtual object PurchaseItemManagement(PurchaseItem purchaseItem, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (purchaseItem == null)
                throw new ArgumentNullException("PurchaseItem", "PurchaseItem");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                    return InsertPurchaseItem(purchaseItem);
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    purchaseItem.PurchaseItemID = 0;
                    return InsertPurchaseItem(purchaseItem);
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                    return UpdatePurchaseItem(purchaseItem);
                else
                {
                    DeletePurchaseItem(purchaseItem);
                    return null;
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList GetPurchaseItems()
        {
            try
            {
                return _ProductDataAccess.GetPurchaseItems();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList GetPurchaseItemsByPurchaseOrder(int PurchaseOrderID)
        {
            try
            {
                return _ProductDataAccess.GetPurchaseItemsByPurchaseOrder(PurchaseOrderID);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public IList GetPurchaseItemsByProduct(int ProductID)
        {
            try
            {
                IList purchaseItemList = _ProductDataAccess.GetPurchaseItemsByProduct(ProductID);
                if (purchaseItemList != null)
                {
                    foreach (PurchaseItem purchaseItem in purchaseItemList)
                    {
                        purchaseItem.SubTotal =
                            float.Parse(Math.Round(purchaseItem.Quantity*purchaseItem.UnitPrice, 2).ToString());
                        if (purchaseItem.FKPurchaseOrder != null)
                            purchaseItem.SupplierID = purchaseItem.FKPurchaseOrder.SupplierID;
                    }
                }

                return purchaseItemList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private Product InsertPurchaseItem(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("PurchaseItem", "PurchaseItem");

            try
            {
                //Update product
                Product product = UpdateProduct(purchaseItem);

                //Purchase Order
                var purchaseOrder = new PurchaseOrder();
                InsertPurchaseOrder(purchaseOrder);

                //Insert purchase item
                purchaseItem.PurchaseOrderID = purchaseOrder.PurchaseOrderID;
                _ProductDataAccess.InsertPurchaseItem(purchaseItem);

                return product;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private Product UpdatePurchaseItem(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("PurchaseItem", "PurchaseItem");

            try
            {
                Product product = UpdateProduct(purchaseItem);
                _ProductDataAccess.UpdatePurchaseItem(purchaseItem);

                return product;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private void DeletePurchaseItem(PurchaseItem purchaseItem)
        {
            if (purchaseItem == null)
                throw new ArgumentNullException("PurchaseItem", "PurchaseItem");

            try
            {
                UpdateProduct(purchaseItem);
                _ProductDataAccess.DeletePurchaseItem(purchaseItem);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        /////////////////////////////////////////// Product unit
        public IList GetProductUnits()
        {
            try
            {
                return _ProductDataAccess.GetProductUnits();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object ProductUnitManagement(ProductUnit productUnit, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (productUnit == null)
                throw new ArgumentNullException("Product Unit", "Product Unit");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _ProductDataAccess.InsertProductUnit(productUnit);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    productUnit.UnitID = 0;
                    _ProductDataAccess.InsertProductUnit(productUnit);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _ProductDataAccess.UpdateProductUnit(productUnit);
                    return null;
                }
                else
                {
                    return DeleteProductUnit(productUnit);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public object DeleteProductUnit(ProductUnit productUnit)
        {
            if (productUnit == null)
                throw new ArgumentNullException("Product Unit", "Product Unit");

            try
            {
                _ProductDataAccess.DeleteProductUnit(productUnit);
                return null;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //ProductLocation
        public IList GetLocations()
        {
            try
            {
                return _ProductDataAccess.GetLocations();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object LocationManagement(ProductLocation productLocation, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (productLocation == null)
                throw new ArgumentNullException("ProductLocation", "ProductLocation");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _ProductDataAccess.InsertLocation(productLocation);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    productLocation.CellID = 0;
                    _ProductDataAccess.InsertLocation(productLocation);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _ProductDataAccess.UpdateLocation(productLocation);
                    return null;
                }
                else
                {
                    return DeleteLocation(productLocation);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteLocation(ProductLocation productLocation)
        {
            if (productLocation == null)
                throw new ArgumentNullException("ProductLocation", "ProductLocation");

            _ProductDataAccess.DeleteLocation(productLocation);
            return null;
        }

        //Cabinet
        public IList GetCabinets()
        {
            try
            {
                return _ProductDataAccess.GetCabinets();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public void AddCabinet(Cabinet cabinet)
        {
            if (cabinet == null)
                throw new ArgumentNullException("Cabinet", "Cabinet");

            try
            {
                _ProductDataAccess.InsertCabinet(cabinet);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        //Laboratory
        public virtual IList GetLaboratories()
        {
            try
            {
                return _ProductDataAccess.GetLaboratories();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object LaboratoryManagement(Laboratory laboratory, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (laboratory == null)
                throw new ArgumentNullException("Laboratory", "Laboratory");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _ProductDataAccess.InsertLaboratory(laboratory);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    laboratory.LaboratoryID = 0;
                    _ProductDataAccess.InsertLaboratory(laboratory);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _ProductDataAccess.UpdateLaboratory(laboratory);
                    return null;
                }
                else
                {
                    return DeleteLaboratory(laboratory);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteLaboratory(Laboratory laboratory)
        {
            if (laboratory == null)
                throw new ArgumentNullException("Laboratory", "Laboratory");

            _ProductDataAccess.DeleteLaboratory(laboratory);
            return null;
        }

        //Country
        public virtual IList GetCountries()
        {
            try
            {
                return _ProductDataAccess.GetCountries();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public virtual object CountryManagement(Country country, string requestCode)
        {
            if (requestCode == null)
                throw new ArgumentException("Request code", "Request code");

            if (country == null)
                throw new ArgumentNullException("Country", "Country");

            try
            {
                if (requestCode == Resources.OperationRequestInsert)
                {
                    _ProductDataAccess.InsertCountry(country);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestDuplicate)
                {
                    country.CountryID = 0;
                    _ProductDataAccess.InsertCountry(country);
                    return null;
                }
                else if (requestCode == Resources.OperationRequestUpdate)
                {
                    _ProductDataAccess.UpdateCountry(country);
                    return null;
                }
                else
                {
                    return DeleteCountry(country);
                }
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        private object DeleteCountry(Country country)
        {
            if (country == null)
                throw new ArgumentNullException("Country", "Country");

            _ProductDataAccess.DeleteCountry(country);
            return null;
        }

        ////////////SaleItem
        public IList GetSaleItemsByProduct(int ProductID)
        {
            try
            {
                IList saleItemList = _ProductDataAccess.GetSaleItemsByProduct(ProductID);
                if (saleItemList != null)
                {
                    foreach (SaleItem saleItem in saleItemList)
                    {
                        saleItem.SaleOrderNumber = saleItem.FKSaleOrder.SaleOrderNumber;
                        saleItem.DateOut = (DateTime) saleItem.FKSaleOrder.DateOut;
                        saleItem.SubTotal = float.Parse(Math.Round(saleItem.QtyOut*saleItem.UnitPriceOut, 2).ToString());
                    }
                }

                return saleItemList;
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}