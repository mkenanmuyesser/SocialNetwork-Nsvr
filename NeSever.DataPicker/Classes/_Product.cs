using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Important note : Being a running and alive project, some codes were removed by me. If you want some detail, please just inform me

namespace DataPickerProject.Classes
{
    public class _Product
    {

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
