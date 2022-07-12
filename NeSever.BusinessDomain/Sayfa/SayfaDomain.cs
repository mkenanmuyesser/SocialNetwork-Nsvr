using NeSever.Common.Models.Sayfa;
using NeSever.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NeSever.BusinessDomain.Sayfa
{
    public class SayfaDomain
    {
        public static Blog BlogKayit(BlogKayitVM blogKayitVM)
        {
            try
            {
                Blog blog = new Blog()
                {
                    BlogKategoriId = blogKayitVM.BlogKategoriId,
                    Baslik = blogKayitVM.Baslik,
                    KisaIcerik = blogKayitVM.KisaIcerik,
                    Icerik = blogKayitVM.Icerik,
                    Etiketler = blogKayitVM.Etiketler,
                    YayinTarihi = Convert.ToDateTime(blogKayitVM.YayinTarihi),
                    BaslangicTarihi = !string.IsNullOrEmpty(blogKayitVM.BaslangicTarihi) ?  Convert.ToDateTime(blogKayitVM.BaslangicTarihi) : (DateTime?)null,
                    BitisTarihi = !string.IsNullOrEmpty(blogKayitVM.BitisTarihi) ? Convert.ToDateTime(blogKayitVM.BitisTarihi) : (DateTime?)null,
                    OneCikanGonderi = blogKayitVM.OneCikanGonderi,
                    OkunmaSayisi = blogKayitVM.OkunmaSayisi,
                    MetaKeywords = blogKayitVM.MetaKeywords,
                    MetaDescription = blogKayitVM.MetaDescription,
                    MetaTitle = blogKayitVM.MetaTitle,
                    AktifMi = blogKayitVM.AktifMi,
                };
                List<BlogUrun> blogUrunLst = new List<BlogUrun>();
                if (blogKayitVM.SecilenUrunListesi != null)
                {
                    foreach (UrunVM item in blogKayitVM.SecilenUrunListesi)
                    {
                        BlogUrun blogUrun = new BlogUrun()
                        {
                            BlogId = blogKayitVM.BlogId,
                            UrunId = item.UrunId,
                            AktifMi = true,
                            Sira = item.Sira

                        };
                        blogUrunLst.Add(blogUrun);
                    }

                    blog.BlogUrun = blogUrunLst;
                }
                List<BlogResim> blogResimLst = new List<BlogResim>();
                if (blogKayitVM.BlogResimListesi != null)
                {
                    foreach (BlogResimVM item in blogKayitVM.BlogResimListesi)
                    {
                        BlogResim blogResim = new BlogResim()
                        {
                            BlogId = blogKayitVM.BlogId,
                            Resim = item.Resim,
                            ResimUrl=item.ResimUrl,
                            AltAttribute=item.AltAttribute,
                            TitleAttribute=item.TitleAttribute,
                            Aciklama=item.Aciklama,
                            AktifMi=item.AktifMi



                        };
                        blogResimLst.Add(blogResim);
                    }

                    blog.BlogUrun = blogUrunLst;
                    blog.BlogResim = blogResimLst;
                }

                return blog;
            }
            catch (Exception ex)
            {

                throw;
            }
      
          
        }

     



        public static List<BlogKategoriVM> BlogKategoriTipleriniGetir()
        {
            var lst = new List<BlogKategoriVM>();
         
            return lst;
        }
    }
}
