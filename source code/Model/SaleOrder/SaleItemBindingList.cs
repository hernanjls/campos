using System.ComponentModel;

namespace EzPos.Model.SaleOrder
{
    public class SaleItemBindingList<T> : BindingList<T>, ITypedList
    {
        #region ITypedList Members

        public PropertyDescriptorCollection GetItemProperties(PropertyDescriptor[] propertyDescriptor)
        {
            var typePropertiesCollection = TypeDescriptor.GetProperties(typeof (T));
            return typePropertiesCollection.Sort(new[]
                                                     {
                                                         "SaleItemId",
                                                         "SaleOrderId",
                                                         "ProductId",
                                                         "ProdPicture",
                                                         "ProductName",
                                                         "ProductDisplayName",
                                                         "UnitPriceIn",
                                                         "UnitPriceOut",
                                                         "PublicUPOut",
                                                         "QtySold",
                                                         "QtyBonus",
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