using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataPickerProject.Classes
{
    public class _Product
    {
        public string ProductId { get; set; }

        public string ProductName { get; set; }

        public string ProductSku { get; set; }

        public string ProductBrand { get; set; }

        public decimal ProductOldPrice { get; set; }

        public decimal ProductPrice { get; set; }

        public string ProductCategories { get; set; }

        public string ProductUrlKey { get; set; }

        public string ProductUrl { get; set; }

        public string ProductDescription { get; set; }

        public string ProductBreadCrumb { get; set; }


        public int ProductBrandId { get; set; }

        public List<_ProductImage> ProductImages { get; set; }

        public List<_ProductImage> ProductThumbnailImages { get; set; }
    }
}
