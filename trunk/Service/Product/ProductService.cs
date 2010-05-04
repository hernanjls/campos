using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Reflection;
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

        public IList GetObjects()
        {
            return _ProductDataAccess.GetProducts();
        }

        public IList GetObjects(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            return searchCriteria.Count == 0 ? GetObjects() : _ProductDataAccess.GetProducts(searchCriteria);
        }

        public IList GetObjectsByID(int productID)
        {
            return _ProductDataAccess.GetProductByID(productID);
        }

        public IList GetAvailableProducts()
        {
            return _ProductDataAccess.GetAvailableProducts();
        }

        public void ManageProduct(Product product, string requestStr)
        {
            if (requestStr == null)
                throw new ArgumentNullException("requestStr", "RequestStr");

            if (product == null)
                throw new ArgumentNullException("product", "Product");

            if (requestStr == Resources.OperationRequestInsert)
                InsertProduct(product);
            else if (requestStr == Resources.OperationRequestDuplicate)
            {
                product.ProductID = 0;
                InsertProduct(product);
            }
            else if (requestStr == Resources.OperationRequestUpdate)
                UpdateProduct(product);
            else
                DeleteProduct(product);
        }

        private void InsertProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", "Product");

            product.LastUpdate = DateTime.Now;
            var existingProduct = _ProductDataAccess.GetProductByCode(product.ProductCode);
            if (existingProduct != null)
            {
                product.ProductID = existingProduct.ProductID;
                product.QtySold = existingProduct.QtySold;
                product.QtyInStock += existingProduct.QtyInStock;
            }

            _ProductDataAccess.InsertProduct(product);
            if (!string.IsNullOrEmpty(product.ProductCode)) 
                return;

            product.ProductCode = StringHelper.Right("000000000" + product.ProductID, 9);
            _ProductDataAccess.UpdateProduct(product);
        }

        private void UpdateProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", "Product");

            _ProductDataAccess.UpdateProduct(product);
        }

        public virtual void UpdateProduct(SaleItem saleItem)
        {
            IList productList = _ProductDataAccess.GetProductByID(saleItem.ProductID);
            if (productList == null)
                return;

            if (productList.Count == 0)
                return;

            var product = productList[0] as Product;
            if (product == null)
                return;

            product.QtyInStock -= saleItem.QtySold;
            product.QtySold += saleItem.QtySold;
            _ProductDataAccess.UpdateProduct(product);
        }

        private void DeleteProduct(Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", "Product");

            _ProductDataAccess.DeleteProduct(product);
        }

        public IList GetCatalogs(bool instockOnly)
        {
            var productList = 
                instockOnly ? 
                _ProductDataAccess.GetAvailableProducts() : 
                _ProductDataAccess.GetUnavailableProducts();

            foreach (Product product in productList)
            {
                product.DisplayName = product.ProductName + "\r" +
                                      "Size: " + product.SizeStr + "\r" +
                                      "Code: " + product.ProductCode;
                if (!string.IsNullOrEmpty(product.ForeignCode))
                    product.DisplayName += " (" + product.ForeignCode + ")";
            }
            return productList;
        }

        public IList GetCatalogs(IList searchCriteria, bool instockOnly)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", "Search Criteria");

            IList productList;
            if (searchCriteria.Count == 0)
            {
                productList = instockOnly ? _ProductDataAccess.GetAvailableProducts() : _ProductDataAccess.GetUnavailableProducts();
            }
            else
            {
                if (instockOnly)
                {
                    searchCriteria.Add("QtyInStock > 0");
                    productList = _ProductDataAccess.GetProducts(searchCriteria);
                }
                else
                {
                    searchCriteria.Add("QtyInStock <= 0");
                    productList = _ProductDataAccess.GetProducts(searchCriteria);
                }
            }

            foreach (Product product in productList)
            {
                product.DisplayName +=
                    product.ProductName + "\r" +
                    "Size: " + product.SizeStr + "\r" +
                    "Code: " + product.ProductCode;

                if (!string.IsNullOrEmpty(product.ForeignCode))
                    product.DisplayName += " (" + product.ForeignCode + ")";
            }
            return productList;
        }

        public void ImportGroupCatalog(string folderPath,
                                       int categoryID, string categoryStr,
                                       int markID, string markStr,
                                       int colorID, string colorStr,
                                       int sizeID, string sizeStr)
        {
            if (String.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException("folderPath", "Folder path");

            var directoryInfo = new DirectoryInfo(folderPath);
            if (directoryInfo.Exists)
            {
                foreach (DirectoryInfo subDirectoryInfo in directoryInfo.GetDirectories())
                    ImportGroupCatalog(
                        subDirectoryInfo.FullName,
                        categoryID,
                        categoryStr,
                        markID,
                        markStr,
                        colorID,
                        colorStr,
                        sizeID,
                        sizeStr);

                foreach (var fileInfo in directoryInfo.GetFiles())
                {
                    if (fileInfo.Extension == ".bmp" ||
                        fileInfo.Extension == ".gif" ||
                        fileInfo.Extension == ".jpg")
                    {
                        var productList = _ProductDataAccess.GetProductByPhoto(
                            fileInfo.FullName);

                        if (productList.Count == 0)
                        {
                            var product = new Product
                                              {
                                                  ProductName = (categoryStr + " \\ " + markStr + " \\ " + colorStr),
                                                  CategoryID = categoryID,
                                                  CategoryStr = categoryStr,
                                                  MarkID = markID,
                                                  MarkStr = markStr,
                                                  ColorID = colorID,
                                                  ColorStr = colorStr,
                                                  SizeID = sizeID,
                                                  SizeStr = sizeStr,
                                                  PhotoPath = fileInfo.FullName,
                                                  QtyInStock = 1
                                              };

                            ManageProduct(
                                product,
                                Resources.OperationRequestInsert);
                        }
                    }
                }
            }
        }

        public void ImportGroupCatalog(string[] fileNames,
                                       int categoryID, string categoryStr,
                                       int markID, string markStr,
                                       int colorID, string colorStr,
                                       int sizeID, string sizeStr)
        {
            if (fileNames.Length == 0)
                return;

            if (String.IsNullOrEmpty(fileNames[0]))
                return;

            foreach (string fileName in fileNames)
            {
                var directoryInfo = new DirectoryInfo(fileName);
                if (directoryInfo.Exists)
                {
                    ImportGroupCatalog(fileName,
                                       categoryID, categoryStr,
                                       markID, markStr,
                                       colorID, colorStr,
                                       sizeID, sizeStr);
                    continue;
                }

                var fileInfo = new FileInfo(fileName);
                if (!fileInfo.Exists)
                    continue;

                if (fileInfo.Extension != ".bmp" &&
                    fileInfo.Extension != ".gif" &&
                    fileInfo.Extension != ".jpg")
                    continue;

                IList productList = _ProductDataAccess.GetProductByPhoto(
                    fileInfo.FullName);

                if (productList.Count == 0)
                {
                    var product = new Product
                                      {
                                          ProductName = (categoryStr + " \\ " + markStr + " \\ " + colorStr),
                                          CategoryID = categoryID,
                                          CategoryStr = categoryStr,
                                          MarkID = markID,
                                          MarkStr = markStr,
                                          ColorID = colorID,
                                          ColorStr = colorStr,
                                          SizeID = sizeID,
                                          SizeStr = sizeStr,
                                          PhotoPath = fileInfo.FullName,
                                          QtyInStock = 1
                                      };

                    ManageProduct(
                        product,
                        Resources.OperationRequestInsert);
                }
            }
        }

        public virtual void ProductAdjustmentManagement(string requestStr, ProductAdjustment productAdjustment)
        {
            if (string.IsNullOrEmpty(requestStr))
                throw new ArgumentNullException("requestStr", "Request operation");

            if (productAdjustment == null)
                throw new ArgumentNullException("productAdjustment", "Product Adjustment");

            if (requestStr.Equals(Resources.OperationRequestInsert))
                InsertProductAdjustment(productAdjustment);

            productAdjustment.FKProduct.QtyInStock = productAdjustment.QtyAdjusted;
            ManageProduct(productAdjustment.FKProduct, requestStr);
        }

        public virtual void ProductAdjustmentManagement(string requestStr, IList productAdjustmentList)
        {
            if (string.IsNullOrEmpty(requestStr))
                throw new ArgumentNullException("requestStr", "Request operation");

            if (productAdjustmentList == null)
                throw new ArgumentNullException("productAdjustmentList", "Product Adjustment");

            if (productAdjustmentList.Count == 0)
                throw new ArgumentNullException("productAdjustmentList", "Product Adjustment");

            foreach (SaleItem saleItem in productAdjustmentList)
            {
                if (saleItem == null)
                    continue;

                var productAdjustment = new ProductAdjustment
                                            {
                                                ProductID = saleItem.ProductID,
                                                QtyInStock = saleItem.FKProduct.QtyInStock,
                                                QtyAdjusted = ((-1)*saleItem.QtySold),
                                                FKProduct = saleItem.FKProduct
                                            };

                ProductAdjustmentManagement(
                    requestStr, productAdjustment);
            }
        }

        private void InsertProductAdjustment(ProductAdjustment productAdjustment)
        {
            if (productAdjustment == null)
                throw new ArgumentNullException("productAdjustment", "Product adjustment");

            _ProductDataAccess.InsertProductAdjustment(productAdjustment);
        }

        public void ExportProductToXml(IList productList, string folderName, string fileName)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", "Product list");

            if (productList.Count == 0)
                throw new ArgumentNullException("productList", "Product list");

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", "File name");

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("folderName", "Folder name");

            //Export data to XML file
            var dtProduct = new DataTable("Product");
            PropertyInfo[] PropertyInfos = typeof (Product).GetProperties();
            foreach (PropertyInfo propertyInfo in PropertyInfos)
            {
                var dataColumn = new DataColumn(propertyInfo.Name, propertyInfo.PropertyType);
                dtProduct.Columns.Add(dataColumn);
            }

            var dsProduct = new DataSet("Products");
            dsProduct.Tables.Add(dtProduct);
            foreach (object objInstance in productList)
            {
                DataRow dataRow = dtProduct.NewRow();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                {
                    if (propertyInfo.Name.Equals("ProductID"))
                        continue;
                    if (propertyInfo.Name.Equals("ProductPic"))
                        continue;
                    if (propertyInfo.Name.Equals("PhotoPath"))
                    {
                        dataRow[propertyInfo.Name] =
                            StringHelper.Right(
                                ((Product) objInstance).PhotoPath,
                                ((Product) objInstance).PhotoPath.Length -
                                AppContext.Counter.ProductPhotoLocalPath.Length);
                        continue;
                    }
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                }
                dtProduct.Rows.Add(dataRow);
            }
            dsProduct.WriteXml(folderName + @"\" + fileName);

            //Export picture to destination
            foreach (Product product in productList)
            {
                //Fetch source file
                var sourceFileInfo = new FileInfo(product.PhotoPath);
                if (!sourceFileInfo.Exists)
                    continue;

                //Destination path
                string destinationPath =
                    folderName +
                    StringHelper.Right(
                        product.PhotoPath,
                        product.PhotoPath.Length - AppContext.Counter.ProductPhotoLocalPath.Length);

                //Create destination path
                var directoryInfo =
                    new DirectoryInfo(
                        StringHelper.Left(
                            destinationPath, destinationPath.Length - sourceFileInfo.Name.Length));
                if (!directoryInfo.Exists)
                    directoryInfo.Create();

                //Copy file
                var destinationFileInfo = new FileInfo(destinationPath);
                if (!destinationFileInfo.Exists)
                    sourceFileInfo.CopyTo(destinationPath);
            }
        }

        public void ImportProductFromXml(string folderName, string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", "File name");

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("folderName", "Folder name");

            var fileInfo = new FileInfo(folderName + @"\" + fileName);
            if (!fileInfo.Exists)
                return;

            //Import data from xml file
            IList productList = new List<Product>();
            var dtProduct = new DataTable("Product");
            PropertyInfo[] PropertyInfos = typeof (Product).GetProperties();
            foreach (PropertyInfo propertyInfo in PropertyInfos)
            {
                var dataColumn = new DataColumn(propertyInfo.Name, propertyInfo.PropertyType);
                dtProduct.Columns.Add(dataColumn);
            }

            var dsProduct = new DataSet("Products");
            dsProduct.Tables.Add(dtProduct);
            dsProduct.ReadXml(folderName + @"\" + fileName);

            foreach (DataRow dataRow in dtProduct.Rows)
            {
                if (dataRow == null)
                    continue;

                var product = new Product();
                foreach (PropertyInfo propertyInfo in PropertyInfos)
                {
                    if (propertyInfo.Name.Equals("ProductID"))
                        continue;
                    if (propertyInfo.Name.Equals("SkinStr"))
                        continue;

                    if (dataRow[propertyInfo.Name] is DBNull)
                        propertyInfo.SetValue(
                            product,
                            string.Empty,
                            null);
                    else
                        propertyInfo.SetValue(
                            product,
                            dataRow[propertyInfo.Name],
                            null);
                }

                product.PhotoPath = AppContext.Counter.ProductPhotoLocalPath + product.PhotoPath;
                ManageProduct(product, Resources.OperationRequestInsert);
                productList.Add(product);
            }

            //Import picture from source
            foreach (Product product in productList)
            {
                string sourcePath =
                    folderName +
                    StringHelper.Right(
                        product.PhotoPath,
                        product.PhotoPath.Length - AppContext.Counter.ProductPhotoLocalPath.Length);
                var sourceFileInfo = new FileInfo(sourcePath);
                if (!sourceFileInfo.Exists)
                    continue;

                var directoryInfo =
                    new DirectoryInfo(
                        StringHelper.Left(
                            product.PhotoPath,
                            product.PhotoPath.Length - sourceFileInfo.Name.Length));
                if (!directoryInfo.Exists)
                    directoryInfo.Create();

                fileInfo = new FileInfo(product.PhotoPath);
                if (!fileInfo.Exists)
                    sourceFileInfo.CopyTo(fileInfo.FullName);
            }
        }

        public bool IsValidatedProductCode(string productCode, out string errorMsg)
        {
            errorMsg = string.Empty;
            if (string.IsNullOrEmpty(productCode))
                return true;

            var isValidated = true;
            var searchCriteria =
                new List<string>
                {
                    "ParameterTypeID|" + Resources.AppParamProductCodeLength
                };
            var commonService = ServiceFactory.GenerateServiceInstance().GenerateCommonService();
            var productCodeLengthList = commonService.GetAppParameters(searchCriteria);
            if (productCodeLengthList.Count != 0)
            {
                var productCodeLength = productCodeLengthList[0] as AppParameter;
                if (productCodeLength != null)
                {
                    int codeLength;
                    isValidated =
                        Int32.TryParse(
                            (string.IsNullOrEmpty(productCodeLength.ParameterLabel) ?
                            string.Empty :
                            productCodeLength.ParameterLabel),
                            out codeLength);

                    if (isValidated)
                        isValidated = (productCode.Length <= codeLength);
                }
            }

            if (!isValidated)
                errorMsg = Resources.MsgExceedProductCodeLength;

            return isValidated;
        }
    }
}