using NeSever.Common.Models.Sayfa;
using System.Collections.Generic;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class BlogDetaySayfaVM
    {
        public BlogIcerikVM BlogIcerik { get; set; }
        public IPagedList<BlogIcerikVM> OneCikanBlogIcerikList { get; set; }
    }
}
