using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using Castle.Services.Transaction;
using EzPos.DataAccess.Product;
using EzPos.Model;
using EzPos.Properties;
using EzPos.Utility;

namespace EzPos.Service.Product
{
    /// <summary>
    /// Summary description for ProductService.
    /// </summary>
    [Transactional]
    public class ProductService
    {
        private readonly ProductDataAccess _productDataAccess;

        public ProductService(ProductDataAccess productDataAccess)
        {
            _productDataAccess = productDataAccess;
        }

        public IList GetObjects()
        {
            return _productDataAccess.GetProducts();
        }

        public IList GetObjects(IList searchCriteria)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            return searchCriteria.Count == 0 ? GetObjects() : _productDataAccess.GetProducts(searchCriteria);
        }

        public IList GetObjectsById(int productId)
        {
            return _productDataAccess.GetProductById(productId);
        }

        public IList GetAvailableProducts()
        {
            return _productDataAccess.GetAvailableProducts();
        }

        public void ManageProduct(Model.Product product, string requestStr)
        {
            if (requestStr == null)
                throw new ArgumentNullException("requestStr", Resources.MsgInvalidRequest);

            if (product == null)
                throw new ArgumentNullException("product", Resources.MsgInvalidProduct);

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

        private void InsertProduct(Model.Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", Resources.MsgInvalidProduct);

            product.LastUpdate = DateTime.Now;
            var existingProduct = _productDataAccess.GetProductByCode(product.ProductCode);
            if (existingProduct != null)
            {
                product.ProductID = existingProduct.ProductID;
                product.QtySold = existingProduct.QtySold;
                product.QtyInStock += existingProduct.QtyInStock;
            }

            _productDataAccess.InsertProduct(product);
            if (!string.IsNullOrEmpty(product.ProductCode)) 
                return;

            product.ProductCode = StringHelper.Right("000000000" + product.ProductID, 9);
            if (string.IsNullOrEmpty(product.ForeignCode))
                product.ForeignCode = product.ProductCode;
            _productDataAccess.UpdateProduct(product);
        }

        private void UpdateProduct(Model.Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", Resources.MsgInvalidProduct);

            _productDataAccess.UpdateProduct(product);
        }

        public virtual void UpdateProduct(SaleItem saleItem)
        {
            var productList = _productDataAccess.GetProductById(saleItem.ProductID);
            if (productList == null)
                return;

            if (productList.Count == 0)
                return;

            var product = productList[0] as Model.Product;
            if (product == null)
                return;

            product.QtyInStock -= saleItem.QtySold;
            product.QtySold += saleItem.QtySold;
            _productDataAccess.UpdateProduct(product);
        }

        private void DeleteProduct(Model.Product product)
        {
            if (product == null)
                throw new ArgumentNullException("product", Resources.MsgInvalidProduct);

            _productDataAccess.DeleteProduct(product);
        }

        public IList GetCatalogs(bool instockOnly)
        {
            var productList = 
                instockOnly ? 
                _productDataAccess.GetAvailableProducts() : 
                _productDataAccess.GetUnavailableProducts();

            //foreach (Model.Product product in productList)
            //{
            //    product.DisplayName = product.ProductName + "\r" +
            //                          "Size: " + product.SizeStr + "\r" +
            //                          "Code: " + product.ProductCode;
            //    if (!string.IsNullOrEmpty(product.ForeignCode))
            //        product.DisplayName += " (" + product.ForeignCode + ")";
            //}
            return productList;
        }

        public IList GetCatalogs(IList searchCriteria, bool instockOnly)
        {
            if (searchCriteria == null)
                throw new ArgumentNullException("searchCriteria", Resources.MsgInvalidSearchCriteria);

            IList productList;
            if (searchCriteria.Count == 0)
            {
                productList = instockOnly ? _productDataAccess.GetAvailableProducts() : _productDataAccess.GetUnavailableProducts();
            }
            else
            {
                if (instockOnly)
                {
                    searchCriteria.Add("QtyInStock > 0");
                    productList = _productDataAccess.GetProducts(searchCriteria);
                }
                else
                {
                    searchCriteria.Add("QtyInStock <= 0");
                    productList = _productDataAccess.GetProducts(searchCriteria);
                }
            }

            //foreach (Model.Product product in productList)
            //{
            //    product.DisplayName +=
            //        product.ProductName + "\r" +
            //        "Size: " + product.SizeStr + "\r" +
            //        "Code: " + product.ProductCode;

            //    if (!string.IsNullOrEmpty(product.ForeignCode))
            //        product.DisplayName += " (" + product.ForeignCode + ")";
            //}
            return productList;
        }

        public void ImportGroupCatalog(
            string folderPath,
            int categoryId, string categoryStr,
            int markId, string markStr,
            int colorId, string colorStr,
            int sizeId, string sizeStr)
        {
            if (String.IsNullOrEmpty(folderPath))
                throw new ArgumentNullException("folderPath", Resources.MsgInvalidFolderPath);

            var directoryInfo = new DirectoryInfo(folderPath);
            if (!directoryInfo.Exists) 
                return;

            foreach (var subDirectoryInfo in directoryInfo.GetDirectories())
                ImportGroupCatalog(
                    subDirectoryInfo.FullName,
                    categoryId,
                    categoryStr,
                    markId,
                    markStr,
                    colorId,
                    colorStr,
                    sizeId,
                    sizeStr);

            foreach (var fileInfo in directoryInfo.GetFiles())
            {
                var fileExtension = fileInfo.Extension;
                if (string.IsNullOrEmpty(fileExtension))
                    continue;

                fileExtension = fileExtension.ToUpper();
                if ((fileExtension != ".BMP" && fileExtension != ".GIF") && fileExtension != ".JPG") 
                    continue;

                var productList = _productDataAccess.GetProductByPhoto(
                    fileInfo.FullName);

                if (productList.Count != 0) 
                    continue;

                var product = 
                    new Model.Product
                    {
                        ProductName = (categoryStr + " \\ " + markStr + " \\ " + colorStr),
                        CategoryID = categoryId,
                        CategoryStr = categoryStr,
                        MarkID = markId,
                        MarkStr = markStr,
                        ColorID = colorId,
                        ColorStr = colorStr,
                        SizeID = sizeId,
                        SizeStr = sizeStr,
                        PhotoPath = fileInfo.FullName,
                        QtyInStock = 1
                    };

                ManageProduct(
                    product,
                    Resources.OperationRequestInsert);
            }
        }

        public void ImportGroupCatalog(
            string[] fileNames,
            int categoryId, string categoryStr,
            int markId, string markStr,
            int colorId, string colorStr,
            int sizeId, string sizeStr)
        {
            if (fileNames.Length == 0)
                return;

            if (String.IsNullOrEmpty(fileNames[0]))
                return;

            foreach (var fileName in fileNames)
            {
                var directoryInfo = new DirectoryInfo(fileName);
                if (directoryInfo.Exists)
                {
                    ImportGroupCatalog(
                        fileName,
                        categoryId, categoryStr,
                        markId, markStr,
                        colorId, colorStr,
                        sizeId, sizeStr);
                    continue;
                }

                var fileInfo = new FileInfo(fileName);
                if (!fileInfo.Exists)
                    continue;

                var fileExtension = fileInfo.Extension;
                if(string.IsNullOrEmpty(fileExtension))
                    continue;

                fileExtension = fileExtension.ToUpper();
                if (fileExtension != ".BMP" &&
                    fileExtension != ".GIF" &&
                    fileExtension != ".JPG")
                    continue;

                var productList = _productDataAccess.GetProductByPhoto(
                    fileInfo.FullName);

                if (productList.Count != 0) 
                    continue;

                var product = 
                    new Model.Product
                    {
                        ProductName = (categoryStr + " \\ " + markStr + " \\ " + colorStr),
                        CategoryID = categoryId,
                        CategoryStr = categoryStr,
                        MarkID = markId,
                        MarkStr = markStr,
                        ColorID = colorId,
                        ColorStr = colorStr,
                        SizeID = sizeId,
                        SizeStr = sizeStr,
                        PhotoPath = fileInfo.FullName,
                        QtyInStock = 1
                    };

                ManageProduct(
                    product,
                    Resources.OperationRequestInsert);
            }
        }

        public virtual void ProductAdjustmentManagement(string requestStr, ProductAdjustment productAdjustment)
        {
            if (string.IsNullOrEmpty(requestStr))
                throw new ArgumentNullException("requestStr", Resources.ConstRequestOperation);

            if (productAdjustment == null)
                throw new ArgumentNullException("productAdjustment", Resources.ConstProductAdjustment);

            if (requestStr.Equals(Resources.OperationRequestInsert))
                InsertProductAdjustment(productAdjustment);

            productAdjustment.FKProduct.QtyInStock = productAdjustment.QtyAdjusted;
            ManageProduct(productAdjustment.FKProduct, requestStr);
        }

        public virtual void ProductAdjustmentManagement(string requestStr, IList productAdjustmentList)
        {
            if (string.IsNullOrEmpty(requestStr))
                throw new ArgumentNullException("requestStr", Resources.ConstRequestOperation);

            if (productAdjustmentList == null)
                throw new ArgumentNullException("productAdjustmentList", Resources.ConstProductAdjustment);

            if (productAdjustmentList.Count == 0)
                throw new ArgumentNullException("productAdjustmentList", Resources.ConstProductAdjustment);

            foreach (
                var productAdjustment 
                in from SaleItem saleItem 
                    in productAdjustmentList
                    where saleItem != null
                    select new ProductAdjustment
                    {
                        ProductID = saleItem.ProductID, 
                        QtyInStock = saleItem.FKProduct.QtyInStock, 
                        QtyAdjusted = ((-1)*saleItem.QtySold), 
                        FKProduct = saleItem.FKProduct
                    })
            {
                ProductAdjustmentManagement(
                    requestStr, productAdjustment);
            }
        }

        private void InsertProductAdjustment(ProductAdjustment productAdjustment)
        {
            if (productAdjustment == null)
                throw new ArgumentNullException("productAdjustment", Resources.ConstProductAdjustment);

            _productDataAccess.InsertProductAdjustment(productAdjustment);
        }

        public void ExportProductToXml(IList productList, string folderName, string fileName)
        {
            if (productList == null)
                throw new ArgumentNullException("productList", Resources.ConstProductList);

            if (productList.Count == 0)
                throw new ArgumentNullException("productList", Resources.ConstProductList);

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("fileName", Resources.ConstFileName);

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("folderName", Resources.ConstFolderName);

            //Export data to XML file
            var dtProduct = new DataTable("Product");
            var propertyInfos = typeof (Model.Product).GetProperties();
            foreach (var dataColumn in
                propertyInfos.Select(propertyInfo => new DataColumn(propertyInfo.Name, propertyInfo.PropertyType)))
            {
                dtProduct.Columns.Add(dataColumn);
            }

            var dsProduct = new DataSet("Products");
            dsProduct.Tables.Add(dtProduct);
            foreach (var objInstance in productList)
            {
                var dataRow = dtProduct.NewRow();
                foreach (var propertyInfo in
                    propertyInfos.Where(propertyInfo => !propertyInfo.Name.Equals("ProductID")).Where(propertyInfo => !propertyInfo.Name.Equals("ProductPic")))
                {
                    if (propertyInfo.Name.Equals("PhotoPath"))
                    {
                        if (string.IsNullOrEmpty(((Model.Product)objInstance).PhotoPath))
                            continue;

                        dataRow[propertyInfo.Name] =
                            StringHelper.Right(
                                ((Model.Product) objInstance).PhotoPath,
                                ((Model.Product) objInstance).PhotoPath.Length -
                                AppContext.Counter.ProductPhotoLocalPath.Length);
                        continue;
                    }
                    dataRow[propertyInfo.Name] = propertyInfo.GetValue(objInstance, null);
                }
                dtProduct.Rows.Add(dataRow);
            }
            dsProduct.WriteXml(folderName + @"\" + fileName);

            //Export picture to destination
            foreach (Model.Product product in productList)
            {
                if(string.IsNullOrEmpty(product.PhotoPath))
                    continue;

                //Fetch source file
                var sourceFileInfo = new FileInfo(product.PhotoPath);
                if (!sourceFileInfo.Exists)
                    continue;

                //Destination path
                var destinationPath =
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
                throw new ArgumentNullException("fileName", Resources.ConstFileName);

            if (string.IsNullOrEmpty(fileName))
                throw new ArgumentNullException("folderName", Resources.ConstFolderName);

            var fileInfo = new FileInfo(folderName + @"\" + fileName);
            if (!fileInfo.Exists)
                return;

            //Import data from xml file
            IList productList = new List<Model.Product>();
            var dtProduct = new DataTable("Product");
            var propertyInfos = typeof (Model.Product).GetProperties();
            foreach (var dataColumn in
                propertyInfos.Select(propertyInfo => new DataColumn(propertyInfo.Name, propertyInfo.PropertyType)))
            {
                dtProduct.Columns.Add(dataColumn);
            }

            var dsProduct = new DataSet("Products");
            dsProduct.Tables.Add(dtProduct);
            dsProduct.ReadXml(folderName + @"\" + fileName);

            foreach (DataRow dataRow in dtProduct.Rows)
            {
                if (dataRow == null)
                    continue;

                var product = new Model.Product();
                foreach (var propertyInfo in
                    propertyInfos.Where(propertyInfo => !propertyInfo.Name.Equals("ProductID")).Where(propertyInfo => !propertyInfo.Name.Equals("SkinStr")))
                {
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
            foreach (Model.Product product in productList)
            {
                var sourcePath =
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

        public bool IsValidatedProductCode(int productId, string productCode, out string errorMsg)
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