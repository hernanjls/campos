using System.ComponentModel;

namespace EzPos.Model
{
    public class SaleItemBindingList<T> : BindingList<T>, ITypedList
    {
        #region ITypedList Members

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] propertyDescriptor)
        {
            PropertyDescriptorCollection typePropertiesCollection = TypeDescriptor.GetProperties(typeof (T));
            return typePropertiesCollection.Sort(new[]
                                                     {
                                                         "SaleItemID",
                                                         "SaleOrderId",
                                                         "ProductID",
                                                         "ProdPicture",
                                                         "ProductName",
                                                         "ProductDisplayName",
                                                         "UnitPriceIn",
                                                         "UnitPriceOut",
                                                         "PublicUPOut",
                                                         "QtySold",
                                                         "Discount",
                                                         "SubTotal"
                                                     });
        }

        public string GetListName(PropertyDescriptor[] listAccessors)
        {
            return string.Format("A list with Properties for {0}", typeof (T).Name);
        }

        #endregion
    }
}