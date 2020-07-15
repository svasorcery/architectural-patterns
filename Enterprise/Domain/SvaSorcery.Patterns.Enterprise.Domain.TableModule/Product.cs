using System;
using System.Data;

namespace SvaSorcery.Patterns.Enterprise.Domain.TableModule
{
    public enum ProductType { W, D, S }

    public class Product : TableModule
    {
        public Product(DataSet dataSet) : base(dataSet, "Products")
        {
        }

        public DataRow this[long key] => Table.Select($"Id = {key}")[0];

        public ProductType GetProductType(long productId)
            => (ProductType)Enum.Parse(typeof(ProductType), (string)this[productId]["type"]);
    }
}
