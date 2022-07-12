using NeSever.Common.Models.Sayfa;
using System.Collections.Generic;
using X.PagedList;

namespace NeSever.Common.Models.FrontEnd
{
    public class BlogAramaSayfaSonucVM
    {
        public string BlogKategoriAttribute { get; set; }
        public string BlogSiralama { get; set; }
        public string BlogArama { get; set; }
        public List<BlogKategoriIcerikVM> BlogKategoriIcerikList { get; set; }
        public IPagedList<BlogIcerikVM> BlogIcerikList { get; set; }
        public IPagedList<BlogIcerikVM> OneCikanBlogIcerikList { get; set; }
    }
}
