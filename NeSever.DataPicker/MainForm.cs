using CsQuery;
using DataPickerProject.Classes;
using DataPickerProject.DBTarget;
using EntityFramework.Utilities;
using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace DataPickerProject
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //CheckForIllegalCrossThreadCalls = false;

            InitializeComponent();
        }

        #region Properties

        private List<string> links;

        private List<_Product> products = new List<_Product>();

        private List<string> productSearchLinks;

        private string diskImagePath = @"G:\Data";

        private string connectionString = "data source=.; initial catalog=NeSeverCoreProjectDB_Prod; integrated security=true";
        #endregion

        #region Events

        private void btnGetProductLinkHistory_Click(object sender, EventArgs e)
        {
            links = new List<string>();
            products = new List<_Product>();

            var btn = sender as Button;
            switch (btn.Name)
            {
                default:
                    break;
                case "btnGetProductLinkHistory_SaatVeSaat":
                    productSearchLinks = new List<string>() { "https://www.saatvesaat.com.tr/saat?p1",
                                                              "https://www.saatvesaat.com.tr/taki?p1" };

                    MakeProductLinkHistoryPassive(1);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_SaatVeSaat(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Morhipo":
                    productSearchLinks = new List<string>() { "https://www.morhipo.com/kadin?ft=1064:32776",
                                                              "https://www.morhipo.com/kadin?ft=1064:31944",
                                                              "https://www.morhipo.com/kadin?ft=1064:32147",
                                                              "https://www.morhipo.com/kadin-kazak",
                                                              "https://www.morhipo.com/kadin-sweatshirt",
                                                              "https://www.morhipo.com/kadin-bot",
                                                              "https://www.morhipo.com/kadin-manto-palto",
                                                              "https://www.morhipo.com/erkek-gomlek",
                                                              "https://www.morhipo.com/erkek-ceket",
                                                              "https://www.morhipo.com/erkek-kazak",
                                                              "https://www.morhipo.com/erkek-trenckot-pardesu",
                                                              "https://www.morhipo.com/ev-yasam",
                                                              "https://www.morhipo.com/kadin-canta",
                                                              "https://www.morhipo.com/erkek-canta",
                                                              "https://www.morhipo.com/ev-dekorasyon",
                                                              "https://www.morhipo.com/tum-urunler?pg=0&ft=1064:32651,32841,32835,32845,32819,32817,32820,32843,32823,32818,32831,32832,36385,32833,32815,33182,32839,33241,33286,33257"
                    };

                    MakeProductLinkHistoryPassive(2);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Morhipo(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_CicekSepeti":
                    productSearchLinks = new List<string>() { "https://www.ciceksepeti.com/kisiye-ozel-hediyelik?page=1" ,
                                                              "https://www.ciceksepeti.com/hediye-oyun-oyuncak?page=1",
                                                              "https://www.ciceksepeti.com/parfumler?page=1",
                                                              "https://www.ciceksepeti.com/organizasyon-hobi?page=1"};

                    MakeProductLinkHistoryPassive(3);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_CicekSepeti(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Kitapsec":
                    productSearchLinks = new List<string>() { "https://www.kitapsec.com/Products/Edebiyat/1-1-0a0-0-0-0-0-0.xhtml" };

                    MakeProductLinkHistoryPassive(4);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Kitapsec(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Vatan":
                    productSearchLinks = new List<string>() { "https://www.vatanbilgisayar.com/televizyon/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/projeksiyon-cihazlari/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/dvd-ev-sinema-sistemleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/aksesuar-urunleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/tuketici-elektronigi/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/elektrikli-ev-aletleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/kisisel-bakim-urunleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/spor-aletleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/cep-telefonu-modelleri/?page=1&stk=true" ,
                                                              "https://www.vatanbilgisayar.com/bilgisayar/?page=1&stk=true" ,
                                                              "https://www.vatanbilgisayar.com/fotograf-makinesi/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/video-kamera-modelleri/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/cantalar-kiliflar/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/oyun-konsollari/?page=1&stk=true",
                                                              "https://www.vatanbilgisayar.com/oyunlar/?page=1&stk=true"};

                    MakeProductLinkHistoryPassive(5);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Vatan(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Sevil":
                    productSearchLinks = new List<string>() { "https://www.sevil.com.tr/parfumler?p=1" ,
                                                              "https://www.sevil.com.tr/makyaj?p=1" ,
                                                              "https://www.sevil.com.tr/cilt-vucut-sac-bakimi?p=1"};

                    MakeProductLinkHistoryPassive(6);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Sevil(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Teknosa":
                    productSearchLinks = new List<string>() { "https://www.teknosa.com/beyaz-esya-ankastre-c-103?q=%3Arelevance&page=0" ,
                                                              "https://www.teknosa.com/elektrikli-ev-aletleri-yasam-c-104?q=%3Arelevance&page=0" ,
                                                              "https://www.teknosa.com/kisisel-bakim-saglik-c-105?q=%3Arelevance&page=0",
                                                              "https://www.teknosa.com/tv-ses-goruntu-sistemleri-c-101?q=%3Arelevance&page=0"};

                    MakeProductLinkHistoryPassive(7);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Teknosa(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_DR":
                    productSearchLinks = new List<string>() { "https://www.dr.com.tr/kategori/Elektronik/Ev-Elektronigi/Pikaplar/grupno=01016#/page=1" ,
                                                              "https://www.dr.com.tr/kategori/Hobi-Oyuncak/Puzzlelar/grupno=00302#/page=1"};

                    MakeProductLinkHistoryPassive(8);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_DR(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_DoRe":
                    productSearchLinks = new List<string>() { "https://www.do-re.com.tr/markalar" };

                    MakeProductLinkHistoryPassive(9);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_DoRe(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Amazon":
                    productSearchLinks = new List<string>() { "https://www.amazon.com.tr/s?i=electronics&rh=n%3A12466496031%2Cn%3A12466497031%2Cn%3A13709880031&page=2&qid=1604083666",
                    "https://www.amazon.com.tr/s?i=kitchen&rh=n%3A12466781031%2Cn%3A12466786031%2Cn%3A12466788031%2Cn%3A14630942031&page=2&qid=1604083701",
                    "https://www.amazon.com.tr/s?i=sports&rh=n%3A12467068031&page=2&qid=1604083728"};

                    MakeProductLinkHistoryPassive(10);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Amazon(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Ebebek":
                    productSearchLinks = new List<string>() { "https://www.e-bebek.com/giyim-tekstil-c3741/?page=0",
                                                              "https://www.e-bebek.com/bebek-odasi-c3771/?page=0",
                                                              "https://www.e-bebek.com/oyuncak-kitap-c3729/?page=0",
                                                              "https://www.e-bebek.com/arac-gerec-c3733/?page=0",
                                                              "https://www.e-bebek.com/beslenme-gerecleri-c4107/?page=0",
                                                              "https://www.e-bebek.com/guvenlik-c10100/?page=0"};

                    MakeProductLinkHistoryPassive(17);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Ebebek(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Zara":
                    productSearchLinks = new List<string>() { "https://www.zara.com/tr/tr/kadin-dish-giyim-l1184.html?v1=1718076&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-ceketler-l1114.html?v1=1718095&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-blazerlar-l1055.html?v1=1718115&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-dish-giyim-yelekler-l1204.html?v1=1718088&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-elbiseler-l1066.html?v1=1718163&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-gemlekler-l1217.html?v1=1718183&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-erge-giyim-l1152.html?v1=1718198&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-tishertler-l1362.html?v1=1718817&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-sweatshirtler-l1320.html?v1=1718862&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-kot-pantolonlar-l1119.html?v1=1718780&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-pantolonlar-l1335.html?v1=1718736&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-etekler-l1299.html?v1=1718788&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-takim-l1437.html?v1=1719408&page=0",
                                                              "https://www.zara.com/tr/tr/woman-loungewear-l3519.html?v1=1719457&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-ayakkabilar-l1251.html?v1=1718981&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-chantalar-l1024.html?v1=1719123&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-aksesuarlar-l1003.html?v1=1719379&page=0",
                                                              "https://www.zara.com/tr/tr/woman-lingerie-l4021.html?v1=1719404&page=0",
                                                              "https://www.zara.com/tr/tr/kadin-guzellik-parfumler-l1415.html?v1=1719415&page=0",
                                                              "https://www.zara.com/tr/tr/join-life-woman-new-in-l2975.html?v1=1719793&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-dish-giyim-l715.html?v1=1717618&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-ceketler-l640.html?v1=1717633&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-dish-giyim-dolgulu-l722.html?v1=1717629&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-dish-giyim-yelekler-l730.html?v1=1717658&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-blazerlar-l608.html?v1=1717677&page=0",
                                                              "https://www.zara.com/tr/tr/man-overshirts-l3174.html?v1=1717679&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-gemlekler-l737.html?v1=1720315&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-erge-giyim-l681.html?v1=1717712&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-pantolonlar-l838.html?v1=1720241&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-kot-pantolonlar-l659.html?v1=1720270&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-tishertler-l855.html?v1=1720359&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-sweatshirtler-l821.html?v1=1720409&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-ayakkabilar-l769.html?v1=1720413&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-chantalar-l563.html?v1=1720458&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-aksesuarlar-l537.html?v1=1720486&page=0",
                                                              "https://www.zara.com/tr/tr/erkek-aksesuarlar-parfemler-l551.html?v1=1720519&page=0",
                                                              "https://www.zara.com/tr/tr/chocuklar-kiz-chocuk-yeni-gelenler-l391.html?v1=1675250&page=0",
                                                              "https://www.zara.com/tr/tr/chocuklar-erkek-chocuk-yeni-gelenler-l228.html?v1=1677005&page=0",
                                                              "https://www.zara.com/tr/tr/chocuklar-kiz-bebek-yeni-gelenler-l127.html?v1=1678172&page=0",
                                                              "https://www.zara.com/tr/tr/chocuklar-erkek-bebek-yeni-gelenler-l43.html?v1=1678775&page=0",
                                                              "https://www.zara.com/tr/tr/chocuklar-yenidoan-yeni-gelenler-l504.html?v1=1679079&page=0",

                    };

                    MakeProductLinkHistoryPassive(11);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Zara(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Pandora":
                    MakeProductLinkHistoryPassive(13);

                    GetAllLinksToSql_Pandora("https://www.pandora.net/tr-tr/assets/feeds/products/json");
                    break;

                case "btnGetProductLinkHistory_Pasabahce":
                    productSearchLinks = new List<string>() { "https://www.pasabahcemagazalari.com/sofra/kk-186",
                                                              "https://www.pasabahcemagazalari.com/cay-kahve/kk-187",
                                                              "https://www.pasabahcemagazalari.com/mutfak/kk-188",
                                                              "https://www.pasabahcemagazalari.com/ev-aksesuarlari/kk-189",
                                                              "https://www.pasabahcemagazalari.com/dekorasyon/kk-190",
                                                              "https://www.pasabahcemagazalari.com/koleksiyonlar/kk-191",
                                                              "https://www.pasabahcemagazalari.com/omnia-koleksiyonu/kk-316",
                                                              "https://www.pasabahcemagazalari.com/nude/k-192"};

                    MakeProductLinkHistoryPassive(14);

                    foreach (var productSearchLink in productSearchLinks)
                    {
                        GetAllLinksToSql_Pasabahce(productSearchLink);
                    }
                    break;
                case "btnGetProductLinkHistory_Lufian":
                    //GetAllLinksToSql_Lufian();
                    break;
            }
        }

        private void btnGetProductsData_Click(object sender, EventArgs e)
        {
            products = new List<_Product>();

            var btn = sender as Button;
            switch (btn.Name)
            {
                default:
                    break;
                case "btnGetProductsData_SaatVeSaat":
                    MakeProductPassive(1);

                    foreach (var productLink in GetProductLinkHistories(1))
                    {
                        GetWebSiteProductDataToSql_SaatVeSaat(productLink);
                    }
                    break;
                case "btnGetProductsData_Morhipo":
                    MakeProductPassive(2);

                    foreach (var productLink in GetProductLinkHistories(2))
                    {
                        GetWebSiteProductDataToSql_Morhipo(productLink);
                    }
                    break;
                case "btnGetProductsData_CicekSepeti":
                    MakeProductPassive(3);

                    foreach (var productLink in GetProductLinkHistories(3))
                    {
                        GetWebSiteProductDataToSql_CicekSepeti(productLink);
                    }
                    break;
                case "btnGetProductsData_Kitapsec":
                    MakeProductPassive(4);

                    foreach (var productLink in GetProductLinkHistories(4))
                    {
                        GetWebSiteProductDataToSql_Kitapsec(productLink);
                    }
                    break;
                case "btnGetProductsData_Vatan":
                    MakeProductPassive(5);

                    foreach (var productLink in GetProductLinkHistories(5))
                    {
                        GetWebSiteProductDataToSql_Vatan(productLink);
                    }
                    break;
                case "btnGetProductsData_Sevil":
                    MakeProductPassive(6);

                    foreach (var productLink in GetProductLinkHistories(6))
                    {
                        GetWebSiteProductDataToSql_Sevil(productLink);
                    }
                    break;
                case "btnGetProductsData_Teknosa":
                    MakeProductPassive(7);

                    foreach (var productLink in GetProductLinkHistories(7))
                    {
                        GetWebSiteProductDataToSql_Teknosa(productLink);
                    }
                    break;
                case "btnGetProductsData_DR":
                    MakeProductPassive(8);

                    foreach (var productLink in GetProductLinkHistories(8))
                    {
                        GetWebSiteProductDataToSql_DR(productLink);
                    }
                    break;
                case "btnGetProductsData_DoRe":
                    MakeProductPassive(9);

                    foreach (var productLink in GetProductLinkHistories(9))
                    {
                        GetWebSiteProductDataToSql_DoRe(productLink);
                    }
                    break;
                case "btnGetProductsData_Amazon":
                    MakeProductPassive(10);

                    foreach (var productLink in GetProductLinkHistories(10))
                    {
                        GetWebSiteProductDataToSql_Amazon(productLink);
                    }
                    break;
                case "btnGetProductsData_Ebebek":
                    MakeProductPassive(17);

                    foreach (var productLink in GetProductLinkHistories(17))
                    {
                        GetWebSiteProductDataToSql_Ebebek(productLink);
                    }
                    break;
                case "btnGetProductsData_Zara":
                    MakeProductPassive(11);

                    foreach (var productLink in GetProductLinkHistories(11))
                    {
                        GetWebSiteProductDataToSql_Zara(productLink);
                    }
                    break;
                case "btnGetProductsData_Pandora":
                    MakeProductPassive(13);

                    var webClient = new WebClient() { Encoding = Encoding.UTF8 };
                    string jsonData = webClient.DownloadString("https://www.pandora.net/tr-tr/assets/feeds/products/json");

                    var productInfoJson = JsonConvert.DeserializeObject<PandoraRoot>(jsonData);

                    foreach (var productLink in GetProductLinkHistories(13))
                    {
                        var productData = productInfoJson.data.products.product.FirstOrDefault(p => p.Url == productLink);
                        if (productData != null)
                        {
                            GetWebSiteProductDataToSql_Pandora(productInfoJson, productData);
                        }
                    }
                    break;
                case "btnGetProductsData_Pasabahce":
                    MakeProductPassive(14);

                    foreach (var productLink in GetProductLinkHistories(14))
                    {
                        GetWebSiteProductDataToSql_Pasabahce(productLink);
                    }
                    break;
                case "btnGetProductsData_Lufian":
                    MakeProductPassive(18);

                    GetWebSiteProductDataToSql_Lufian();
                    break;
            }
        }

        #endregion

        #region Methods

        private void GetAllLinksToSql_SaatVeSaat(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        if (href.Contains("/PD") || href.Contains("?p="))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = "";
                        if (linkedPage.Contains(siteUrl))
                        {
                            string linkedPageData = linkedPage.Replace(siteUrl, "");
                            linkedPageData = linkedPageData.StartsWith("/") ? linkedPageData : "/" + linkedPageData;
                            pageUrl = linkedPageData.Contains(siteUrl) ? siteUrl + linkedPageData : siteUrl + linkedPageData;
                        }
                        else
                        {
                            string linkedPageData = linkedPage.StartsWith("/") ? linkedPage : "/" + linkedPage;
                            pageUrl = linkedPageData.Contains(siteUrl) ? siteUrl + linkedPageData.Replace(siteUrl, "") : siteUrl + linkedPageData;
                        }

                        if (!links.Any(p => p == pageUrl))
                        {
                            //ürünleri gir
                            if (linkedPage.Contains("/PD"))
                            {
                                CreateOrUpdateProductLinkHistory(1, pageUrl);
                            }

                            GetAllLinksToSql_SaatVeSaat(pageUrl);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(1, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_SaatVeSaat(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var productInfo = doc.DocumentNode.Descendants("script")
                                                  .SingleOrDefault(p => p.InnerHtml.Contains("catalog_product_view"));

                if (productInfo != null)
                {
                    var jsonData = productInfo.InnerHtml.Trim().Replace("dataLayer.push(", "").Replace(");", "");
                    jsonData = jsonData.Replace("GtmMobileDetect.site_type", "'GtmMobileDetect.site_type'");
                    var productInfoJson = (JObject)JsonConvert.DeserializeObject(jsonData);

                    var product = productInfoJson["product"];
                    string productId = product["pid"].Value<string>();
                    string productName = product["name"].Value<string>();
                    string productSku = product["sku"].Value<string>();
                    string productBrand = product["brand"].Value<string>();
                    string productOldPrice = product["price"].Value<string>();
                    string productPrice = product["total_price"].Value<string>();
                    string productCategories = product["category_ids"].Value<string>();
                    string productUrlKey = product["url_key"].Value<string>();

                    var page = productInfoJson["page"];
                    string productUrl = page["url"].Value<string>();
                    string productBreadCrumb = page["breadcrumb"]["path"].Value<string>() + page["breadcrumb"]["last_crumb"].Value<string>();

                    var _ProductImages = doc.DocumentNode.Descendants("a")
                                                        .Where(p => p.GetAttributeValue("class", "") == "thumb-link")
                                                        .Select(p => p.GetAttributeValue("href", ""));

                    var productThumbnailImages = doc.DocumentNode.Descendants("a")
                                                                 .Where(p => p.GetAttributeValue("class", "") == "thumb-link")
                                                                 .Select(p => p.Descendants("img")
                                                                               .Select(u => u.GetAttributeValue("src", ""))
                                                                               .FirstOrDefault());

                    var productDescription = doc.DocumentNode.Descendants("div")
                                                             .SingleOrDefault(p => p.GetAttributeValue("id", "") == "mnm-additional-tabs")
                                                             .Descendants("div")
                                                             .FirstOrDefault().InnerHtml;

                    var categories = doc.DocumentNode.Descendants("li")
                                                     .Where(p => p.GetAttributeValue("class", "").Contains("category"))
                                                     .Select(p =>
                                                                  new
                                                                  {
                                                                      categoryId = p.GetAttributeValue("class", "").Replace("category", ""),
                                                                      categoryName = p.Descendants("a").FirstOrDefault().InnerHtml.Trim(),
                                                                  }
                                                            );

                    CreateOrUpdateCategory(1, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    if (productInfoJson != null)
                    {
                        _Product productData = new _Product()
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductSku = productSku,
                            ProductBrand = productBrand,
                            ProductOldPrice = Convert.ToDecimal(productOldPrice),
                            ProductPrice = Convert.ToDecimal(productPrice),
                            ProductCategories = productCategories,
                            ProductUrlKey = productUrlKey,
                            ProductUrl = productUrl,
                            ProductDescription = productDescription.Replace(saatvesaatIgnoreText, ""),
                            ProductBreadCrumb = productBreadCrumb,
                            ProductImages = new List<_ProductImage>(),
                            ProductThumbnailImages = new List<_ProductImage>()
                        };

                        if (!products.Any(p => p.ProductId == productData.ProductId))
                        {
                            productData.ProductBrandId = CreateOrUpdateBrand(1, productData.ProductBrand);

                            products.Add(productData);

                            bool urunVarmi = CreateOrUpdateProduct(1, productData);

                            if (!urunVarmi)
                            {
                                CreateOrUpdateProductCategories(1, productData, categories);

                                int imageCounter = 1;
                                foreach (var _ProductImage in _ProductImages)
                                {
                                    //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                    var _ProductImageUri = new Uri(_ProductImage);
                                    string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                    string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                    var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                    var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                    var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                    string imageDirectory = productData.ProductSku;
                                    string staticPath = @"\Data\SaatVeSaat\";
                                    string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                    string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                    //eğer klasör yoksa oluştur
                                    if (!Directory.Exists(writeToPath))
                                    {
                                        Directory.CreateDirectory(writeToPath);
                                    }

                                    //eğer dosya yoksa indir
                                    string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                    if (!File.Exists(writeToFilePath))
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            wc.DownloadFile(_ProductImage, writeToFilePath);

                                            _ProductImage prImage = new _ProductImage()
                                            {
                                                ImagePath = staticPath + filepath,
                                                OriginalImagePath = _ProductImage
                                            };
                                            productData.ProductImages.Add(prImage);
                                        }
                                    }

                                    imageCounter++;
                                }

                                CreateOrUpdate_ProductImages(1, productData);
                            }
                        }
                    }
                    else
                    {
                        CreateLog(1, "GetWebSiteProductDataToSql", "ProductInfoJson verisi bulunamadı.");
                    }
                }
                else
                {
                    CreateLog(1, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(1, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Morhipo(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();

                    dom["li"].Each(p =>
                    {
                        string ol = p.ParentNode.GetAttribute("class");
                        if (ol.Contains("ProductList"))
                        {
                            var href = siteUrl + p.ChildNodes[1].ChildNodes[3].GetAttribute("href");

                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        //ürünleri gir
                        CreateOrUpdateProductLinkHistory(2, linkedPage);
                    }

                    if (linkedPages.Any())
                    {
                        int index = url.IndexOf("?");
                        var urlFirstPart = index == -1 ? url : url.Substring(0, index);
                        var urlSecondPart = index == -1 ? url : url.Substring(index, (url.Contains("&") ? url.IndexOf("&") : url.Length) - index);
                        var urlThirdPart = index == -1 ? "" : url.Remove(0, urlFirstPart.Length + urlSecondPart.Length);
                        int pageNumber = index == -1 ? 0 : Convert.ToInt32(urlSecondPart.Replace("?pg=", ""));
                        pageNumber++;
                        url = urlFirstPart + "?pg=" + pageNumber + urlThirdPart;
                        //bir sonraki sayfaya git
                        GetAllLinksToSql_Morhipo(url);
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz                   
                CreateLog(2, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Morhipo(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productNameHtml = doc.DocumentNode.Descendants("title").FirstOrDefault().InnerHtml.Replace(" \r\n", "");

                var productInfo = doc.DocumentNode.Descendants("script")
                                                  .SingleOrDefault(p => p.InnerHtml.Contains("viewed_product"));

                if (productInfo != null)
                {
                    var productInfoHtml = productInfo.InnerHtml.Trim();
                    productNameHtml = productNameHtml.Split('|').FirstOrDefault().Trim();

                    var jsonData = productInfoHtml.Substring(productInfoHtml.IndexOf("var viewed_product"), (productInfoHtml.Length - productInfoHtml.IndexOf("viewed_product")));
                    jsonData = jsonData.Substring(jsonData.IndexOf("[{"), (jsonData.IndexOf("}];") - jsonData.IndexOf("[{")) + 3);
                    jsonData = jsonData.Substring(0, jsonData.IndexOf("'variant'")) + "}]";
                    jsonData = jsonData.Replace("[", "").Replace("]", "");
                    var productInfoJson = (JObject)JsonConvert.DeserializeObject(jsonData);

                    var product = productInfoJson;
                    string productId = product["id"].Value<string>();
                    string productName = productNameHtml;
                    string productSku = product["listingID"].Value<string>();
                    string productBrand = product["brand"].Value<string>();
                    string productOldPrice = "0";
                    string productPrice = product["price"].Value<string>();
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url.Substring(0, url.IndexOf("?"));
                    string productBreadCrumb = "";

                    var _ProductImages = doc.DocumentNode.Descendants("a")
                                                        .Where(p => p.GetAttributeValue("class", "").Contains("thumb-img"))
                                                        .Select(p => p.GetAttributeValue("href", ""));

                    var productThumbnailImages = doc.DocumentNode.Descendants("a")
                                                                 .Where(p => p.GetAttributeValue("class", "").Contains("thumb-img"))
                                                                 .Select(p => p.Descendants("img")
                                                                               .Select(u => u.GetAttributeValue("src", ""))
                                                                               .FirstOrDefault());

                    var productDescriptionList = doc.DocumentNode.Descendants("div")
                                                             .SingleOrDefault(p => p.GetAttributeValue("id", "") == "aboutprodtab")
                                                             .Descendants("p")
                                                             .Where(p => p.GetAttributeValue("class", "") == "pd-block")
                                                             .ToList();


                    var productDescription = "";
                    productDescriptionList.ForEach(p =>
                    {
                        productDescription += p.OuterHtml;
                    });


                    var categoryList = product["category"].Value<string>().Split('/');
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in categoryList)
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(2, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    if (productInfoJson != null)
                    {
                        _Product productData = new _Product()
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductSku = productSku,
                            ProductBrand = productBrand,
                            ProductOldPrice = Convert.ToDecimal(productOldPrice.Replace('.', ',')),
                            ProductPrice = Convert.ToDecimal(productPrice.Replace('.', ',')),
                            ProductCategories = productCategories,
                            ProductUrlKey = productUrlKey,
                            ProductUrl = productUrl,
                            ProductDescription = productDescription,
                            ProductBreadCrumb = productBreadCrumb,
                            ProductImages = new List<_ProductImage>(),
                            ProductThumbnailImages = new List<_ProductImage>()
                        };

                        if (!products.Any(p => p.ProductId == productData.ProductId))
                        {
                            productData.ProductBrandId = CreateOrUpdateBrand(2, productData.ProductBrand);

                            products.Add(productData);

                            bool urunVarmi = CreateOrUpdateProduct(2, productData);

                            if (!urunVarmi)
                            {
                                CreateOrUpdateProductCategories(2, productData, categories);

                                int imageCounter = 1;
                                foreach (var _ProductImage in _ProductImages)
                                {
                                    //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                    var _ProductImageUri = new Uri(_ProductImage);
                                    string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                    string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                    var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                    var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                    var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                    string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                    string staticPath = @"\Data\Morhipo\";
                                    //string writeToPath = @"F:" + staticPath + imageDirectory;
                                    string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                    string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                    //eğer klasör yoksa oluştur
                                    if (!Directory.Exists(writeToPath))
                                    {
                                        Directory.CreateDirectory(writeToPath);
                                    }

                                    //eğer dosya yoksa indir
                                    string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                    if (!File.Exists(writeToFilePath))
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            var cleanImageAddress = _ProductImage.IndexOf('?') > 0 ? _ProductImage.Substring(0, _ProductImage.IndexOf('?')) : _ProductImage;
                                            var cleanImagePath = writeToFilePath.IndexOf('?') > 0 ? writeToFilePath.Substring(0, writeToFilePath.IndexOf('?')) : writeToFilePath;

                                            wc.DownloadFile(_ProductImage, cleanImagePath);

                                            _ProductImage prImage = new _ProductImage()
                                            {
                                                ImagePath = staticPath + filepath,
                                                OriginalImagePath = _ProductImage
                                            };
                                            productData.ProductImages.Add(prImage);
                                        }
                                    }

                                    imageCounter++;
                                }

                                CreateOrUpdate_ProductImages(2, productData);
                            }
                        }
                    }
                    else
                    {
                        CreateLog(2, "GetWebSiteProductDataToSql", "ProductInfoJson verisi bulunamadı.");
                    }
                }
                else
                {
                    CreateLog(2, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(2, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_CicekSepeti(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("products__item-link") || href.Contains("?page="))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = "";
                        if (!linkedPage.Contains("?page="))
                        {
                            pageUrl = siteUrl + linkedPage;
                        }
                        else
                        {
                            pageUrl = linkedPage;
                        }

                        if (!links.Any(p => p == pageUrl))
                        {
                            if (linkedPage.Contains("?page="))
                            {
                                GetAllLinksToSql_CicekSepeti(pageUrl);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(3, pageUrl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(3, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_CicekSepeti(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var productInfo1 = doc.DocumentNode.Descendants("script")
                                                  .SingleOrDefault(p => p.InnerHtml.Contains("@type\":\"Product"));

                var productInfo2 = doc.DocumentNode.Descendants("script")
                                                   .SingleOrDefault(p => p.InnerHtml.Contains("dataLayer = ["));

                var productInfo3 = doc.DocumentNode.Descendants("script")
                                                  .SingleOrDefault(p => p.InnerHtml.Contains("viewModel = "));

                if (productInfo1 != null)
                {
                    var productInfoHtml1 = productInfo1.InnerHtml.Trim();
                    var productInfoHtml2 = productInfo2.InnerHtml.Trim();
                    productInfoHtml2 = productInfoHtml2.Replace("dataLayer = ", "").Replace(";", "").Replace("[", "").Replace("]", "");
                    var productInfoHtml3 = productInfo3.InnerHtml.Trim();
                    productInfoHtml3 = productInfoHtml3.Replace("viewModel = {\"productThumbs\":", "");
                    productInfoHtml3 = productInfoHtml3.Substring(0, productInfoHtml3.IndexOf("]") + 1);

                    var jsonData1 = productInfoHtml1;
                    var productInfoJson1 = (JObject)JsonConvert.DeserializeObject(jsonData1);

                    var jsonData2 = productInfoHtml2;
                    var productInfoJson2 = (JObject)JsonConvert.DeserializeObject(jsonData2);

                    var jsonData3 = productInfoHtml3;
                    var productInfoJson3 = (JArray)JsonConvert.DeserializeObject(jsonData3);

                    string productId = productInfoJson1["sku"].Value<string>();
                    string productName = productInfoJson1["name"].Value<string>();
                    string productSku = productInfoJson1["sku"].Value<string>();
                    string productBrand = productInfoJson1["brand"]["name"].Value<string>();
                    string productOldPrice = "0";
                    string productPrice = productInfoJson2["productTotalPrice"].Value<string>();
                    string productCategories = productInfoJson2["pcat"].Value<string>();
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = "";
                    string productDescription = productInfoJson1["description"].Value<string>();

                    var _ProductImages = productInfoJson3.Select(p => p["ImageUrl"]).Values<string>();

                    var productThumbnailImages = productInfoJson3.Select(p => p["ThumbnailUrl"]).Values<string>();

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    categories.Add(new { categoryId = -1, categoryName = productCategories.Trim() });

                    CreateOrUpdateCategory(3, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    if (productInfoJson1 != null && productInfoJson2 != null)
                    {
                        _Product productData = new _Product()
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductSku = productSku,
                            ProductBrand = productBrand,
                            ProductOldPrice = Convert.ToDecimal(productOldPrice),
                            ProductPrice = Convert.ToDecimal(productPrice),
                            ProductCategories = productCategories,
                            ProductUrlKey = productUrlKey,
                            ProductUrl = productUrl,
                            ProductDescription = productDescription,
                            ProductBreadCrumb = productBreadCrumb,
                            ProductImages = new List<_ProductImage>(),
                            ProductThumbnailImages = new List<_ProductImage>()
                        };

                        if (!products.Any(p => p.ProductId == productData.ProductId))
                        {
                            productData.ProductBrandId = CreateOrUpdateBrand(3, productData.ProductBrand);

                            products.Add(productData);

                            bool urunVarmi = CreateOrUpdateProduct(3, productData);

                            if (!urunVarmi)
                            {
                                CreateOrUpdateProductCategories(3, productData, categories);

                                int imageCounter = 1;
                                foreach (var _ProductImage in _ProductImages)
                                {
                                    //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                    var _ProductImageUri = new Uri(_ProductImage);
                                    string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                    string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                    var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                    var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                    var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                    string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                    string staticPath = @"\Data\Ciceksepeti\";
                                    string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                    string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                    //eğer klasör yoksa oluştur
                                    if (!Directory.Exists(writeToPath))
                                    {
                                        Directory.CreateDirectory(writeToPath);
                                    }

                                    //eğer dosya yoksa indir
                                    string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                    if (!File.Exists(writeToFilePath))
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            var cleanImageAddress = _ProductImage.IndexOf('?') > 0 ? _ProductImage.Substring(0, _ProductImage.IndexOf('?')) : _ProductImage;
                                            var cleanImagePath = writeToFilePath.IndexOf('?') > 0 ? writeToFilePath.Substring(0, writeToFilePath.IndexOf('?')) : writeToFilePath;

                                            wc.DownloadFile(cleanImageAddress, cleanImagePath);

                                            _ProductImage prImage = new _ProductImage()
                                            {
                                                ImagePath = staticPath + filepath,
                                                OriginalImagePath = _ProductImage
                                            };
                                            productData.ProductImages.Add(prImage);
                                        }
                                    }

                                    imageCounter++;
                                }

                                CreateOrUpdate_ProductImages(3, productData);
                            }
                        }
                    }
                    else
                    {
                        CreateLog(3, "GetWebSiteProductDataToSql", "ProductInfoJson verisi bulunamadı.");
                    }
                }
                else
                {
                    CreateLog(3, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(3, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Kitapsec(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("sayfalama_link") || cls.Contains("img"))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        if (!links.Any(p => p == linkedPage))
                        {
                            if (linkedPage.Contains("xhtml"))
                            {
                                GetAllLinksToSql_Kitapsec(linkedPage);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(4, linkedPage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(4, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Kitapsec(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var productInfo1 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("itemprop", "") == "description").InnerHtml;

                var productInfo2 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "fiyatDiv" && p.ParentNode.GetAttributeValue("class", "") == "dty_SagBlok")
                                                   .Descendants("span")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "fiyati").InnerHtml;

                var productInfo3 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("detayBilgiDivIc"))
                                                   .Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("itemprop", "") == "publisher")
                                                   .Descendants("a")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "yayinEviText")
                                                   .Descendants("span")
                                                   .SingleOrDefault(p => p.GetAttributeValue("itemprop", "") == "name").InnerHtml;

                var productInfo4 = doc.DocumentNode.Descendants("ul")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "breadcrumbs")
                                                   .Descendants("li")
                                                   .Where(p => p.Descendants("h2").Count() > 0)
                                                   .Select(p => p.Descendants("h2")
                                                                 .SingleOrDefault(x => x.GetAttributeValue("itemprop", "") == "name").InnerHtml);

                if (!string.IsNullOrEmpty(productInfo1) && !string.IsNullOrEmpty(productInfo2) && !string.IsNullOrEmpty(productInfo3) && (productInfo4 != null && productInfo4.Count() > 0))
                {
                    var productData1 = productInfo1.Split('|');

                    string productId = productData1[1].Trim();
                    string productName = productData1[0].Trim();
                    string productSku = productData1[1].Trim();
                    string productBrand = productInfo3;
                    string productOldPrice = "0";
                    string productPrice = productInfo2.Replace("TL", "").Trim();
                    string productCategories = string.Join("|", productInfo4);
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = string.Join("/", productInfo4);

                    var _ProductImages = doc.DocumentNode.Descendants("div")
                                                        .SingleOrDefault(p => p.GetAttributeValue("id", "") == "dtyResimlerIc")
                                                        .Descendants("a")
                                                        .Select(p => "https:" + p.GetAttributeValue("href", ""));

                    var productThumbnailImages = new List<string>();

                    var productDescription = doc.DocumentNode.Descendants("div")
                                                             .SingleOrDefault(p => p.GetAttributeValue("id", "") == "tab1").InnerHtml;

                    var categoryList = productCategories.Split('|');
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in categoryList)
                    {
                        if (!(category == "Anasayfa" || category == "Ürünler" || category == "Tüm Ürünler"))
                        {
                            categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                            categoryCounter++;
                        }
                    }

                    CreateOrUpdateCategory(4, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        //burayı düzelt . ile ilgili sıkıntı var 
                        //productPrice.Replace(",", "").Replace(".", ",")
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(4, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(4, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(4, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                string staticPath = @"\Data\KitapSec\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(4, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(4, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(4, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Vatan(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("product-list__link") || href.Contains("?page="))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = siteUrl + linkedPage.Replace(siteUrl, "");

                        if (!links.Any(p => p == pageUrl))
                        {
                            if (linkedPage.Contains("?page="))
                            {
                                GetAllLinksToSql_Vatan(pageUrl);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(5, pageUrl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(5, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Vatan(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var productInfo1 = doc.DocumentNode.Descendants("h1")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("product-list__product-name")).InnerHtml.Replace("\n", "");

                var prd = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-list__cost product-list__description");

                var productInfo2 = prd == null ? "" : prd.Descendants("span")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-list__price").InnerHtml.Replace("\n", "");

                var productInfo3 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("product-list__product-code")).InnerHtml.Replace("\n", "");

                var productInfo4 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("spanTabUrunAciklama")).InnerHtml.Replace("\n", "");

                var productInfo5 = doc.DocumentNode.Descendants("ul")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "breadcrumb")
                                                   .Descendants("a")
                                                   .Select(p => p.InnerHtml.Replace("\n", "")).ToList();


                if (!string.IsNullOrEmpty(productInfo1) || !string.IsNullOrEmpty(productInfo3) || !string.IsNullOrEmpty(productInfo4) || (productInfo5 != null && productInfo5.Count() > 0))
                {
                    var productData3 = productInfo3.Split('/');

                    var brand = productInfo5[productInfo5.Count - 2];
                    productInfo5.RemoveAt(productInfo5.Count - 1);
                    productInfo5.RemoveAt(productInfo5.Count - 1);

                    string productId = productData3[1].Trim();
                    string productName = productInfo1.Trim();
                    string productSku = productData3[0].Trim();
                    string productBrand = brand;
                    string productOldPrice = "0";
                    string productPrice = productInfo2.Trim();
                    string productCategories = string.Join("|", productInfo5);
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = string.Join("/", productInfo5);

                    var _ProductImages = doc.DocumentNode.Descendants("img")
                                                                 .Where(p => p.GetAttributeValue("class", "").Contains("wrapper-main-slider__image"))
                                                                 .Select(p => p.GetAttributeValue("data-src", ""));

                    var productThumbnailImages = doc.DocumentNode.Descendants("div")
                                                        .Where(p => p.GetAttributeValue("data-thumb", "").Contains("<img src="))
                                                        .Select(p => p.GetAttributeValue("data-thumb", "").Replace("<img src=\"", "").Replace("\"/>", ""));

                    var productDescription = productInfo4;

                    var categoryList = productCategories.Split('|');
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in categoryList)
                    {
                        if (!(category == "Anasayfa" || category == "Ürünler" || category == "Tüm Ürünler"))
                        {
                            categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                            categoryCounter++;
                        }
                    }

                    CreateOrUpdateCategory(5, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(5, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(5, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(5, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = productData.ProductSku;
                                string staticPath = @"\Data\Vatan\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(5, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(5, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(5, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Sevil(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("product-image") || href.Contains("?p="))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        if (!links.Any(p => p == linkedPage))
                        {
                            if (linkedPage.Contains("?p="))
                            {
                                GetAllLinksToSql_Sevil(linkedPage);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(6, linkedPage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(6, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Sevil(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productInfo1 = doc.DocumentNode.Descendants("meta")
                                                   .SingleOrDefault(p => p.GetAttributeValue("itemprop", "") == "productID").GetAttributeValue("content", "").Replace("sku:", "");

                var productInfo2 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-name").InnerHtml.Replace("<h1 itemprop=\"name\">", "").Replace("</h1>", "").Replace("\n", "");

                var productInfo3 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("brand-name")).InnerHtml;

                var productInfo4 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("category-name")).InnerHtml.Trim();

                var productInfo5 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "std" && p.GetAttributeValue("itemprop", "") == "description").InnerHtml.Trim();

                var productInfo6 = doc.DocumentNode.Descendants("span")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "") == "price" && p.GetAttributeValue("id", "").Contains("old-price")).InnerHtml.Replace("\n", "");

                var productInfo7 = doc.DocumentNode.Descendants("span")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "") == "price" && p.GetAttributeValue("id", "").Contains("product-price")).InnerHtml.Replace("\n", "");

                var productInfo8 = doc.DocumentNode.Descendants("input")
                                                   .SingleOrDefault(p => p.GetAttributeValue("name", "") == "product").GetAttributeValue("value", "");


                if (!string.IsNullOrEmpty(productInfo1) || !string.IsNullOrEmpty(productInfo2) || !string.IsNullOrEmpty(productInfo3) || !string.IsNullOrEmpty(productInfo4) || !string.IsNullOrEmpty(productInfo5) || !string.IsNullOrEmpty(productInfo6) || !string.IsNullOrEmpty(productInfo7) || !string.IsNullOrEmpty(productInfo8))
                {

                    string productId = productInfo8.Trim();
                    string productName = productInfo2.Trim();
                    string productSku = productInfo1.Trim();
                    string productBrand = productInfo3.Trim();
                    string productOldPrice = productInfo6.Replace("TL", "").Trim();
                    string productPrice = productInfo7.Replace("TL", "").Trim();
                    string productCategories = productInfo4.Trim();
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = string.Join("/", productInfo4);


                    var gallery = doc.DocumentNode.Descendants("div")
                                                  .SingleOrDefault(p => p.GetAttributeValue("id", "") == "amasty_gallery");

                    IEnumerable<string> _ProductImages = new List<string>();
                    IEnumerable<string> productThumbnailImages = new List<string>();
                    if (gallery != null)
                    {
                        _ProductImages = gallery.Descendants("a")
                                                .Select(p => p.GetAttributeValue("data-image", "").Trim().Replace("\n", ""));

                        productThumbnailImages = gallery.Descendants("img")
                                                        .Select(p => p.GetAttributeValue("src", "").Trim().Replace("\n", ""));
                    }

                    var productDescription = productInfo5;

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    categories.Add(new { categoryId = -1, categoryName = productCategories });

                    CreateOrUpdateCategory(6, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(6, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(6, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(6, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = productData.ProductSku;
                                string staticPath = @"\Data\Sevil\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(6, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(6, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(6, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Teknosa(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.ParentNode.GetAttribute("class");
                        if (cls.Contains("product-image-item") || href.Contains("page="))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = siteUrl + linkedPage.Replace(siteUrl, "");

                        if (!links.Any(p => p == pageUrl))
                        {
                            if (linkedPage.Contains("page="))
                            {
                                GetAllLinksToSql_Teknosa(pageUrl);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(7, pageUrl);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(7, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Teknosa(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productInfo1 = doc.DocumentNode.Descendants("input")
                                                   .SingleOrDefault(p => p.GetAttributeValue("id", "") == "product-code").GetAttributeValue("value", "");

                var productInfo2 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-title").InnerHtml.Replace("<h1>", "").Replace("</h1>", "").Replace("\n", "").Replace("\t", "");

                var productInfo3 = doc.DocumentNode.Descendants("button")
                                                   .FirstOrDefault(p => p.GetAttributeValue("id", "") == "addToCartButton").GetAttributeValue("data-product-brand", "");

                var productInfo4 = doc.DocumentNode.Descendants("script")
                                                   .SingleOrDefault(p => p.GetAttributeValue("id", "").Contains("Breadcrumb")).InnerHtml.Trim();

                var productInfo5 = doc.DocumentNode.Descendants("div")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "") == "tabbody").InnerHtml.Trim();

                var productInfo6 = doc.DocumentNode.Descendants("div")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "").Contains("price-tag old-price"));

                var productInfo7 = doc.DocumentNode.Descendants("div")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "").Contains("price-tag new-price") || p.GetAttributeValue("class", "").Contains("default-price")).InnerHtml.Replace("\n", "").Replace("\t", "");


                if (!string.IsNullOrEmpty(productInfo1) || !string.IsNullOrEmpty(productInfo2) || !string.IsNullOrEmpty(productInfo3) || !string.IsNullOrEmpty(productInfo4) || !string.IsNullOrEmpty(productInfo5) || !string.IsNullOrEmpty(productInfo7))
                {

                    var jsonData = productInfo4.Substring(0, productInfo4.IndexOf("]") + 1);
                    jsonData = jsonData.Remove(0, productInfo4.IndexOf("["));
                    var productInfoJson = ((JArray)JsonConvert.DeserializeObject(jsonData)).Select(p => p["item"]["name"].ToString());

                    string productId = productInfo1.Trim();
                    string productName = productInfo2.Trim();
                    string productSku = productInfo1.Trim();
                    string productBrand = productInfo3.Trim();
                    string productOldPrice = productInfo6 == null ? "0" : productInfo6.InnerHtml.Replace("\n", "").Replace("\t", "").Replace("TL", "").Trim();
                    string productPrice = productInfo7.Replace("TL", "").Trim();
                    string productCategories = productInfo4.Trim();
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = string.Join("/", productInfoJson);



                    var productImages = doc.DocumentNode.Descendants("a")
                                                        .Where(p => p.ParentNode.GetAttributeValue("class", "") == "slider-item")
                                                        .Select(p => p.GetAttributeValue("href", ""));

                    var productThumbnailImages = doc.DocumentNode.Descendants("img")
                                                        .Where(p => p.ParentNode.GetAttributeValue("class", "") == "thumbnail-item")
                                                        .Select(p => p.GetAttributeValue("src", ""));

                    var productDescription = productInfo5;

                    int categoryCounter = 1;
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    foreach (var category in productInfoJson)
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(7, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(7, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(7, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(7, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in productImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = productData.ProductSku;
                                string staticPath = @"\Data\Teknosa\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(7, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(7, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(7, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_DR(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.ParentNode.GetAttribute("class");
                        if (cls.Contains("content"))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    bool sameProduct = false;
                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = siteUrl + linkedPage.Replace(siteUrl, "");

                        if (!links.Any(p => p == pageUrl))
                        {
                            links.Add(pageUrl);
                            CreateOrUpdateProductLinkHistory(8, pageUrl);
                        }
                        else
                        {
                            sameProduct = true;
                        }
                    }

                    if (!sameProduct)
                    {
                        int index = url.IndexOf("#/page=");
                        var urlFirstPart = url.Substring(0, index);
                        var urlSecondPart = urlFirstPart + "#/page=";
                        int pageNumber = Convert.ToInt32(url.Replace(urlSecondPart, ""));
                        pageNumber++;
                        url = urlSecondPart + pageNumber;
                        //bir sonraki sayfaya git
                        GetAllLinksToSql_DR(url);
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(8, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_DR(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var productInfo = doc.DocumentNode.Descendants("script")
                                                  .SingleOrDefault(p => p.InnerHtml.Contains("viewed_product"));

                if (productInfo != null)
                {
                    var productInfoHtml = productInfo.InnerHtml.Trim();

                    var jsonData = productInfoHtml.Substring(productInfoHtml.IndexOf("var viewed_product"), (productInfoHtml.Length - productInfoHtml.IndexOf("viewed_product")));
                    jsonData = jsonData.Substring(jsonData.IndexOf("[{"), (jsonData.IndexOf("}];") - jsonData.IndexOf("[{")) + 3);
                    jsonData = jsonData.Substring(0, jsonData.IndexOf("'variant'")) + "}]";
                    jsonData = jsonData.Replace("[", "").Replace("]", "");
                    var productInfoJson = (JObject)JsonConvert.DeserializeObject(jsonData);

                    var product = productInfoJson;
                    string productId = product["id"].Value<string>();
                    string productName = product["name"].Value<string>().Replace(("|" + productId), "");
                    string productSku = product["listingID"].Value<string>();
                    string productBrand = product["brand"].Value<string>();
                    string productOldPrice = "0";
                    string productPrice = product["price"].Value<string>();
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url.Substring(0, url.IndexOf("?"));
                    string productBreadCrumb = "";

                    var _ProductImages = doc.DocumentNode.Descendants("a")
                                                        .Where(p => p.GetAttributeValue("class", "").Contains("thumb-img"))
                                                        .Select(p => p.GetAttributeValue("href", ""));

                    var productThumbnailImages = doc.DocumentNode.Descendants("a")
                                                                 .Where(p => p.GetAttributeValue("class", "").Contains("thumb-img"))
                                                                 .Select(p => p.Descendants("img")
                                                                               .Select(u => u.GetAttributeValue("src", ""))
                                                                               .FirstOrDefault());

                    var productDescriptionList = doc.DocumentNode.Descendants("div")
                                                             .SingleOrDefault(p => p.GetAttributeValue("id", "") == "aboutprodtab")
                                                             .Descendants("p")
                                                             .Where(p => p.GetAttributeValue("class", "") == "pd-block")
                                                             .ToList();


                    var productDescription = "";
                    productDescriptionList.ForEach(p =>
                    {
                        productDescription += p.OuterHtml;
                    });


                    var categoryList = product["category"].Value<string>().Split('/');
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in categoryList)
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(8, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    if (productInfoJson != null)
                    {
                        _Product productData = new _Product()
                        {
                            ProductId = productId,
                            ProductName = productName,
                            ProductSku = productSku,
                            ProductBrand = productBrand,
                            ProductOldPrice = Convert.ToDecimal(productOldPrice),
                            ProductPrice = Convert.ToDecimal(productPrice),
                            ProductCategories = productCategories,
                            ProductUrlKey = productUrlKey,
                            ProductUrl = productUrl,
                            ProductDescription = productDescription,
                            ProductBreadCrumb = productBreadCrumb,
                            ProductImages = new List<_ProductImage>(),
                            ProductThumbnailImages = new List<_ProductImage>()
                        };

                        if (!products.Any(p => p.ProductId == productData.ProductId))
                        {
                            productData.ProductBrandId = CreateOrUpdateBrand(8, productData.ProductBrand);

                            products.Add(productData);

                            bool urunVarmi = CreateOrUpdateProduct(8, productData);

                            if (!urunVarmi)
                            {
                                CreateOrUpdateProductCategories(8, productData, categories);

                                int imageCounter = 1;
                                foreach (var _ProductImage in _ProductImages)
                                {
                                    //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                    var _ProductImageUri = new Uri(_ProductImage);
                                    string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                    string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                    var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                    var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                    var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                    string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                    string staticPath = @"\Data\Morhipo\";
                                    string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                    string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                    //eğer klasör yoksa oluştur
                                    if (!Directory.Exists(writeToPath))
                                    {
                                        Directory.CreateDirectory(writeToPath);
                                    }

                                    //eğer dosya yoksa indir
                                    string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                    if (!File.Exists(writeToFilePath))
                                    {
                                        using (WebClient wc = new WebClient())
                                        {
                                            var cleanImageAddress = _ProductImage.IndexOf('?') > 0 ? _ProductImage.Substring(0, _ProductImage.IndexOf('?')) : _ProductImage;
                                            var cleanImagePath = writeToFilePath.IndexOf('?') > 0 ? writeToFilePath.Substring(0, writeToFilePath.IndexOf('?')) : writeToFilePath;

                                            wc.DownloadFile(_ProductImage, cleanImagePath);

                                            _ProductImage prImage = new _ProductImage()
                                            {
                                                ImagePath = staticPath + filepath,
                                                OriginalImagePath = _ProductImage
                                            };
                                            productData.ProductImages.Add(prImage);
                                        }
                                    }

                                    imageCounter++;
                                }

                                CreateOrUpdate_ProductImages(8, productData);
                            }
                        }
                    }
                    else
                    {
                        CreateLog(8, "GetWebSiteProductDataToSql", "ProductInfoJson verisi bulunamadı.");
                    }
                }
                else
                {
                    CreateLog(8, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(8, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_DoRe(string url, bool isProduct = false)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = uri.GetLeftPart(UriPartial.Authority);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        string clsParent = p.ParentNode.GetAttribute("class");
                        if (clsParent.Contains("brands-list") || cls.Contains("product-item"))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        string pageUrl = siteUrl + linkedPage.Replace(siteUrl, "");

                        if (!links.Any(p => p == pageUrl))
                        {
                            //ürünleri gir
                            if (isProduct)
                            {
                                CreateOrUpdateProductLinkHistory(9, pageUrl);
                            }
                            else
                            {
                                GetAllLinksToSql_DoRe(pageUrl, true);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(9, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_DoRe(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var productInfo = doc.DocumentNode.Descendants("div")
                                     .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("product-detail__info"));

                var productInfo1 = productInfo.Descendants("div")
                                              .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("info-value") && p.InnerHtml.Contains("Ürün Kodu"))
                                              .Descendants("span")
                                              .LastOrDefault().InnerHtml;

                var productInfo2 = productInfo.Descendants("h1")
                                              .SingleOrDefault().InnerHtml;

                var productInfo3 = productInfo.Descendants("div")
                                              .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("info-value") && p.InnerHtml.Contains("Marka"))
                                              .Descendants("a")
                                              .LastOrDefault().InnerHtml;

                var productInfo4 = doc.DocumentNode.Descendants("ul")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "breadcrumbs")
                                                   .Descendants("span")
                                                   .Select(p => p.InnerHtml);

                var productInfo5 = doc.DocumentNode.Descendants("div")
                                                   .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-detail-description");

                var productInfo6 = productInfo.Descendants("span")
                                              .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("price") && p.GetAttributeValue("class", "").Contains("old"));

                var productInfo7 = productInfo.Descendants("span")
                                              .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("price") && p.GetAttributeValue("class", "").Contains("current")).InnerHtml;


                if (!string.IsNullOrEmpty(productInfo1) || !string.IsNullOrEmpty(productInfo2) || !string.IsNullOrEmpty(productInfo3) || productInfo4.Any() || !string.IsNullOrEmpty(productInfo7))
                {
                    string productId = productInfo1.Trim();
                    string productName = productInfo2.Trim();
                    string productSku = productInfo1.Trim();
                    string productBrand = productInfo3.Trim();
                    string productOldPrice = productInfo6 == null ? "0" : productInfo6.InnerHtml.Contains("(") ? productInfo6.InnerHtml.Substring(0, productInfo6.InnerHtml.IndexOf("(")).Replace("TL", "").Trim() : productInfo6.InnerHtml.Replace("TL", "").Trim();
                    string productPrice = productInfo7.Replace("TL", "").Trim();
                    string productCategories = string.Join("|", productInfo4);
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = string.Join("/", productInfo4);

                    var productImages = doc.DocumentNode.Descendants("div")
                                                        .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("product-photos__showcase"))
                                                        .Descendants("img")
                                                        .Select(p => p.GetAttributeValue("data-src", ""));

                    var thumbnailDiv = doc.DocumentNode.Descendants("div")
                                                       .SingleOrDefault(p => p.GetAttributeValue("class", "").Contains("product-photos__listing"));

                    IEnumerable<string> productThumbnailImages = new List<string>();
                    if (thumbnailDiv != null)
                    {
                        productThumbnailImages = thumbnailDiv.Descendants("img")
                                                             .Select(p => p.GetAttributeValue("data-src", ""));
                    }


                    var productDescription = productInfo5 == null ? "" : productInfo5.InnerHtml.Trim();

                    var categoryList = productCategories.Split('|');
                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in categoryList)
                    {
                        if (!(category == "Anasayfa"))
                        {
                            categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                            categoryCounter++;
                        }
                    }

                    CreateOrUpdateCategory(9, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice.Replace(",", "").Replace(".", ",")),
                        ProductPrice = Convert.ToDecimal(productPrice.Replace(",", "").Replace(".", ",")),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(9, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(9, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(9, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in productImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath;
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = productData.ProductSku;
                                string staticPath = @"\Data\DoRe\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(9, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(9, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(9, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Amazon(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = "https://www.amazon.com.tr";

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();

                    //if (dom["ul"].Any(p => p.Classes.Any(o=>o=="a-pagination")))
                    if (dom.Find("ul").Any(p => p.ClassName.Contains("pagination")))
                    {
                        dom["a[href]"].Each(p =>
                        {
                            string href = p.GetAttribute("href");
                            string cls = p.GetAttribute("class");
                            if (cls.Contains("a-link-normal s-no-outline") && href.Contains("/ref") && href != "javascript:void(0)")
                            {
                                linkedPages.Add(href);
                            }
                        });

                        dom = null;
                        GC.Collect();

                        bool sameProduct = false;
                        foreach (var linkedPage in linkedPages)
                        {
                            string pageUrl = siteUrl + linkedPage.Substring(0, linkedPage.IndexOf("/ref="));

                            if (!links.Any(p => p == pageUrl))
                            {
                                links.Add(pageUrl);
                                CreateOrUpdateProductLinkHistory(10, pageUrl);
                            }
                            else
                            {
                                sameProduct = true;
                            }
                        }

                        int index = url.IndexOf("page=");
                        var urlFirstPart = url.Substring(0, index);
                        var urlSecondPart = urlFirstPart + "page=";
                        var urlThirdPart = url.Substring(index + 5, url.IndexOf("&qid") - index - 5);
                        var urlForthPart = url.Substring(url.IndexOf("&qid"), url.Length - url.IndexOf("&qid"));
                        int pageNumber = Convert.ToInt32(urlThirdPart);
                        pageNumber++;
                        url = urlSecondPart + pageNumber + urlForthPart;
                        //bir sonraki sayfaya git
                        GetAllLinksToSql_Amazon(url);
                    }
                    else
                    {

                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(10, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Amazon(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);
                var name = doc.DocumentNode.Descendants("span")
                                           .SingleOrDefault(p => p.Id == "productTitle").InnerHtml.Trim().HtmlDecode();
                var brand = doc.DocumentNode.Descendants("a")
                                            .SingleOrDefault(p => p.Id == "bylineInfo").InnerHtml.Trim().HtmlDecode();

                var sku = doc.DocumentNode.Descendants("input")
                                          .SingleOrDefault(p => p.Id == "ASIN").GetAttributeValue("value", "").Trim().HtmlDecode();

                var price = doc.DocumentNode.Descendants("span")
                                            .SingleOrDefault(p => p.Id == "price_inside_buybox")?.InnerHtml.Replace("₺", "").Trim().HtmlDecode();

                var description1 = doc.DocumentNode.Descendants("h2")
                                                   .FirstOrDefault(p => p.InnerHtml.Contains("Ürün Bilgileri"));

                var description2 = doc.DocumentNode.Descendants("ul")
                                                   .FirstOrDefault(p => p.GetAttributeValue("class", "").Contains("a-unordered-list a-vertical a-spacing-mini"));

                var description = description1 == null ? description2?.OuterHtml : description1?.ParentNode.InnerHtml;

                var imageData = doc.DocumentNode.Descendants("script")
                                                .SingleOrDefault(p => p.InnerText.Contains("ImageBlockATF")).InnerHtml;

                var breadcrumb = doc.DocumentNode.Descendants("div")
                                                 .SingleOrDefault(p => p.Id == "wayfinding-breadcrumbs_feature_div")
                                                 .Descendants("a")
                                                 .Select(p => p.InnerHtml.HtmlDecode().Trim());


                if (name != null && brand != null && sku != null)
                {
                    var jsonData = imageData.Substring(imageData.IndexOf("var data =") + 10, (imageData.Length - imageData.IndexOf("var data =") - 10));
                    jsonData = jsonData.Substring(0, jsonData.IndexOf("'airyConfig'")) + "}";
                    var productInfoJson = (JObject)JsonConvert.DeserializeObject(jsonData);

                    string productId = sku;
                    string productName = name;
                    string productSku = sku;
                    string productBrand = brand;
                    string productOldPrice = "0";
                    string productPrice = price;
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = "";
                    var productDescription = description;

                    var _ProductImages = productInfoJson["colorImages"]["initial"].ToList().Select(p => p["large"].ToString());

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in breadcrumb)
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(10, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(10, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(10, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(10, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                string staticPath = @"\Data\Amazon\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(10, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(10, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(10, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Ebebek(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = "https://www.e-bebek.com";

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("product-btn") || href.Contains("?page="))
                        {
                            href = siteUrl + href;
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var linkedPage in linkedPages)
                    {
                        if (!links.Any(p => p == linkedPage))
                        {
                            if (linkedPage.Contains("?page="))
                            {
                                GetAllLinksToSql_Ebebek(linkedPage);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(17, linkedPage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(17, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Ebebek(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var name = doc.DocumentNode.Descendants("input")
                                           .FirstOrDefault(p => p.OuterHtml.Contains("hidden") && p.OuterHtml.Contains("productNamePost"))
                                           .GetAttributeValue("value", "").Trim().HtmlDecode();

                var brand = doc.DocumentNode.Descendants("input")
                                           .FirstOrDefault(p => p.OuterHtml.Contains("hidden") && p.OuterHtml.Contains("productBrandForGTM"))
                                           .GetAttributeValue("value", "").Trim().HtmlDecode();

                var sku = doc.DocumentNode.Descendants("input")
                                           .FirstOrDefault(p => p.OuterHtml.Contains("hidden") && p.OuterHtml.Contains("productCodePostBase"))
                                           .GetAttributeValue("value", "").Trim().HtmlDecode();

                var priceWithDiscount = doc.DocumentNode.Descendants("input")
                                           .FirstOrDefault(p => p.OuterHtml.Contains("hidden") && p.OuterHtml.Contains("priceWithDiscount"))
                                           .GetAttributeValue("value", "").Trim().HtmlDecode();

                var price = doc.DocumentNode.Descendants("input")
                                          .FirstOrDefault(p => p.OuterHtml.Contains("hidden") && p.OuterHtml.Contains("productPrice"))
                                          .GetAttributeValue("value", "").Trim().HtmlDecode();

                var breadcrumb = doc.DocumentNode.Descendants("input")
                                           .FirstOrDefault(p => p.OuterHtml.Contains("breadcrumbEvent"))
                                           .GetAttributeValue("value", "").Trim().HtmlDecode();

                if (name != null && brand != null && sku != null)
                {
                    string productId = sku;
                    string productName = name;
                    string productSku = sku;
                    string productBrand = brand;
                    string productOldPrice = "0";
                    string productPrice = string.IsNullOrEmpty(priceWithDiscount) ? price : priceWithDiscount;
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = "";
                    var productDescription = "";

                    var _ProductImages = new List<string>();


                    var divImages = doc.DocumentNode.Descendants("div")
                                                      .SingleOrDefault(p => p.GetAttributeValue("class", "") == "product-glide");

                    if (divImages != null)
                    {
                        _ProductImages = divImages.Descendants("ul")
                                 .SingleOrDefault(p => p.GetAttributeValue("class", "") == "glide__slides")
                                 .Descendants("li")
                                 .Where(p => p.GetAttributeValue("class", "") == "glide__slide")
                                 .Select(p => p.Descendants("img").Select(u => u.GetAttributeValue("src", "")).FirstOrDefault()).ToList();
                    }

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in breadcrumb.Split('>'))
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.HtmlDecode().Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(17, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = string.IsNullOrEmpty(productPrice) ? 0 : Convert.ToDecimal(productPrice.Replace('.', ',')),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(17, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(17, productData);

                        if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(17, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                string staticPath = @"\Data\Ebebek\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(17, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(17, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(17, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Zara(string url)
        {
            try
            {
                var uri = new Uri(url);

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        string href = p.GetAttribute("href");
                        string cls = p.GetAttribute("class");
                        if (cls.Contains("product-grid-product__link"))
                        {
                            linkedPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    if (linkedPages.Any())
                    {
                        foreach (var linkedPage in linkedPages)
                        {
                            if (!links.Any(p => p == linkedPage))
                            {
                                CreateOrUpdateProductLinkHistory(11, linkedPage);
                            }
                        }

                        string pageQuery = url.Remove(0, url.IndexOf("page="));
                        int sayac = Convert.ToInt32(pageQuery.Substring(5, pageQuery.Length - 5));
                        sayac++;
                        string newUrl = url.Substring(0, url.IndexOf("page=")) + "page=" + sayac.ToString();

                        GetAllLinksToSql_Zara(newUrl);
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(11, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Zara(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var name = doc.DocumentNode.Descendants("h1")
                                           .FirstOrDefault(p => p.GetAttributeValue("class", "") == "product-detail-info__name").InnerHtml.Trim().HtmlDecode();

                var price = doc.DocumentNode.Descendants("span")
                                            .FirstOrDefault(p => p.GetAttributeValue("class", "").Contains("price__amount")).InnerHtml.Trim().HtmlDecode();


                var sku = url.Split('-').LastOrDefault().Replace(".html", "");

                var breadcrumb = doc.DocumentNode.Descendants("a")
                                                 .Where(p => p.GetAttributeValue("class", "") == "layout-footer-breadcrumbs__link link")
                                                 .Select(p => p.Descendants("span").LastOrDefault().InnerHtml.Trim().HtmlDecode());

                if (name != null && sku != null)
                {
                    string productId = sku;
                    string productName = name;
                    string productSku = sku;
                    string productBrand = "Zara";
                    string productOldPrice = "0";
                    string productPrice = price.Replace("TL", "").Trim();
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = "";
                    var productDescription = "";

                    var _ProductImages = new List<string>();

                    string htmlContent = doc.Text;
                    htmlContent = htmlContent.Remove(0, htmlContent.IndexOf("\"image\":") + 9);
                    htmlContent = htmlContent.Substring(0, htmlContent.IndexOf("]"));


                    _ProductImages = htmlContent.Split(',').Select(p => p.Replace("\\", "").Replace("\"", "")).ToList();

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in breadcrumb)
                    {
                        if (category != "ZARA")
                        {
                            categories.Add(new { categoryId = categoryCounter, categoryName = category.HtmlDecode().Trim() });
                            categoryCounter++;
                        }
                    }

                    CreateOrUpdateCategory(11, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = 0,
                        ProductPrice = Convert.ToDecimal(productPrice),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(11, productData.ProductBrand);

                        products.Add(productData);

                        bool urunVarmi = CreateOrUpdateProduct(11, productData);

                        //if (!urunVarmi)
                        {
                            CreateOrUpdateProductCategories(11, productData, categories);

                            int imageCounter = 1;
                            foreach (var _ProductImage in _ProductImages)
                            {
                                //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                var _ProductImageUri = new Uri(_ProductImage);
                                string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                                var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                                var _ProductImageFullName = _ProductImageName;

                                string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                string staticPath = @"\Data\Zara\";
                                string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                //eğer klasör yoksa oluştur
                                if (!Directory.Exists(writeToPath))
                                {
                                    Directory.CreateDirectory(writeToPath);
                                }

                                //eğer dosya yoksa indir
                                string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                if (!File.Exists(writeToFilePath))
                                {
                                    using (WebClient wc = new WebClient())
                                    {
                                        wc.DownloadFile(_ProductImage, writeToFilePath);

                                        _ProductImage prImage = new _ProductImage()
                                        {
                                            ImagePath = staticPath + filepath,
                                            OriginalImagePath = _ProductImage
                                        };
                                        productData.ProductImages.Add(prImage);
                                    }
                                }

                                imageCounter++;
                            }

                            CreateOrUpdate_ProductImages(11, productData);
                        }
                    }
                }
                else
                {
                    CreateLog(11, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(11, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Pandora(string url)
        {
            try
            {
                string jsonData = new WebClient().DownloadString(url);

                var productInfoJson = JsonConvert.DeserializeObject<PandoraRoot>(jsonData);

                foreach (var product in productInfoJson.data.products.product)
                {
                    if (product.State == "released")
                    {
                        CreateOrUpdateProductLinkHistory(13, product.Url);
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(13, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Pandora(PandoraRoot productInfoJson, Product product)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(product.Url);

                var name = product.Name.Trim().HtmlDecode();

                var brand = "Pandora";

                var sku = product.Id.Trim().HtmlDecode();

                var price = product.Price.Trim().HtmlDecode();

                var cat = product.Cat.Trim();

                if (name != null && brand != null && sku != null)
                {
                    string productId = sku;
                    string productName = name;
                    string productSku = sku;
                    string productBrand = brand;
                    string productOldPrice = "0";
                    string productPrice = price;
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = product.Url;
                    string productBreadCrumb = "";
                    var productDescription = "";

                    var _ProductImages = new List<string>();
                    var divImages = doc.DocumentNode.Descendants("meta")
                                                    .SingleOrDefault(p => p.GetAttributeValue("property", "") == "og:image").GetAttributeValue("content", "");

                    if (divImages != null)
                    {
                        _ProductImages = new List<string>() { divImages };
                    }

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;

                    var category = productInfoJson.data.groups.group.SingleOrDefault(p => p.Key == "Category").item.SingleOrDefault(p => p.Key == cat)?.Value;

                    categories.Add(new { categoryId = categoryCounter, categoryName = category.HtmlDecode().Trim() });
                    categoryCounter++;


                    CreateOrUpdateCategory(13, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = string.IsNullOrEmpty(productPrice) ? 0 : Convert.ToDecimal(productPrice.Replace('.', ',')),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(13, productData.ProductBrand);

                        products.Add(productData);

                        CreateOrUpdateProduct(13, productData);

                        CreateOrUpdateProductCategories(13, productData, categories);

                        int imageCounter = 1;
                        foreach (var _ProductImage in _ProductImages)
                        {
                            //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                            var _ProductImageUri = new Uri(_ProductImage);
                            string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                            string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                            var _ProductImageExtension = Path.GetExtension(_ProductImage);
                            var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                            var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                            string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                            string staticPath = @"\Data\Pandora\";
                            string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                            string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                            //eğer klasör yoksa oluştur
                            if (!Directory.Exists(writeToPath))
                            {
                                Directory.CreateDirectory(writeToPath);
                            }

                            //eğer dosya yoksa indir
                            string filepath = imageDirectory + "\\" + _ProductImageFullName;
                            if (!File.Exists(writeToFilePath))
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile(_ProductImage, writeToFilePath);

                                    _ProductImage prImage = new _ProductImage()
                                    {
                                        ImagePath = staticPath + filepath,
                                        OriginalImagePath = _ProductImage
                                    };
                                    productData.ProductImages.Add(prImage);
                                }
                            }

                            imageCounter++;
                        }

                        CreateOrUpdate_ProductImages(13, productData);
                    }
                }
                else
                {
                    CreateLog(13, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(13, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetAllLinksToSql_Pasabahce(string url)
        {
            try
            {
                var uri = new Uri(url);
                var siteUrl = "https://www.pasabahcemagazalari.com";

                if (!links.Any(p => p == url))
                {
                    links.Add(url);

                    var dom = CQ.CreateFromUrl(url);
                    List<string> linkedPages = new List<string>();
                    List<string> subPages = new List<string>();
                    dom["a[href]"].Each(p =>
                    {
                        if (p.ParentNode.HasClass("product-item-inner"))
                        {
                            string href = p.GetAttribute("href");
                            href = siteUrl + href;
                            linkedPages.Add(href);
                        }

                        if (p.ParentNode.HasClass("sub-category-banner-item-inner"))
                        {
                            string href = p.GetAttribute("href");
                            href = siteUrl + href;
                            subPages.Add(href);
                        }
                    });

                    dom = null;
                    GC.Collect();

                    foreach (var subpage in subPages)
                    {
                        GetAllLinksToSql_Pasabahce(subpage);
                    }

                    foreach (var linkedPage in linkedPages)
                    {
                        if (!links.Any(p => p == linkedPage))
                        {
                            if (linkedPage.Contains("?p="))
                            {
                                GetAllLinksToSql_Pasabahce(linkedPage);
                            }
                            //ürünleri gir
                            else
                            {
                                CreateOrUpdateProductLinkHistory(14, linkedPage);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //log kaydına yaz 
                CreateLog(14, "GetAllLinksToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Pasabahce(string url)
        {
            try
            {
                var web = new HtmlWeb();
                var doc = web.Load(url);

                var pData = doc.DocumentNode.Descendants("a")
                                                  .FirstOrDefault(p => p.GetAttributeValue("class", "").Contains("add-to-cart-btn"));

                var name = pData.GetAttributeValue("data-dlname", "").Trim().HtmlDecode();

                var brand = "Paşabahçe";

                var sku = pData.GetAttributeValue("data-dlid", "").Trim().HtmlDecode();

                var price = pData.GetAttributeValue("data-dlprice", "").Trim().HtmlDecode();

                var breadcrumb = pData.GetAttributeValue("data-dlcategory", "").Trim().HtmlDecode();

                if (name != null && brand != null && sku != null)
                {
                    string productId = sku;
                    string productName = name;
                    string productSku = sku;
                    string productBrand = brand;
                    string productOldPrice = "0";
                    string productPrice = price;
                    string productCategories = "";
                    string productUrlKey = "";
                    string productUrl = url;
                    string productBreadCrumb = "";
                    var productDescription = "";

                    var _ProductImages = new List<string>();
                    //var divImages = doc.DocumentNode.Descendants("div")
                    //                                  .SingleOrDefault(p => p.GetAttributeValue("id", "") == "divUrunResim");

                    //if (divImages != null)
                    //{
                    //    _ProductImages = divImages.Descendants("img")
                    //                     .Select(u => u.GetAttributeValue("src", "")).ToList();
                    //}

                    _ProductImages.Add("https://www.pasabahcemagazalari.com/ca/images/large/" + sku + ".jpg");

                    var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                    int categoryCounter = 1;
                    foreach (var category in breadcrumb.Split('/'))
                    {
                        categories.Add(new { categoryId = categoryCounter, categoryName = category.HtmlDecode().Trim() });
                        categoryCounter++;
                    }

                    CreateOrUpdateCategory(14, categories);

                    doc = null;
                    web = null;
                    GC.Collect();

                    _Product productData = new _Product()
                    {
                        ProductId = productId,
                        ProductName = productName,
                        ProductSku = productSku,
                        ProductBrand = productBrand,
                        ProductOldPrice = Convert.ToDecimal(productOldPrice),
                        ProductPrice = string.IsNullOrEmpty(productPrice) ? 0 : Convert.ToDecimal(productPrice.Replace('.', ',')),
                        ProductCategories = productCategories,
                        ProductUrlKey = productUrlKey,
                        ProductUrl = productUrl,
                        ProductDescription = productDescription,
                        ProductBreadCrumb = productBreadCrumb,
                        ProductImages = new List<_ProductImage>(),
                        ProductThumbnailImages = new List<_ProductImage>()
                    };

                    if (!products.Any(p => p.ProductId == productData.ProductId))
                    {
                        productData.ProductBrandId = CreateOrUpdateBrand(14, productData.ProductBrand);

                        products.Add(productData);

                        CreateOrUpdateProduct(14, productData);

                        CreateOrUpdateProductCategories(14, productData, categories);

                        int imageCounter = 1;
                        foreach (var _ProductImage in _ProductImages)
                        {
                            //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                            var _ProductImageUri = new Uri(_ProductImage);
                            string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                            string _ProductImageDirectory = _ProductImageUri.AbsolutePath.Substring(0, _ProductImageUri.AbsolutePath.LastIndexOf('/'));
                            var _ProductImageExtension = Path.GetExtension(_ProductImage);
                            var _ProductImageName = _ProductImageUri.AbsolutePath.Replace(_ProductImageDirectory, "").Replace("/", "").Replace(_ProductImageExtension, "");
                            var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                            string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                            string staticPath = @"\Data\Pasabahce\";
                            string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                            string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                            //eğer klasör yoksa oluştur
                            if (!Directory.Exists(writeToPath))
                            {
                                Directory.CreateDirectory(writeToPath);
                            }

                            //eğer dosya yoksa indir
                            string filepath = imageDirectory + "\\" + _ProductImageFullName;
                            if (!File.Exists(writeToFilePath))
                            {
                                using (WebClient wc = new WebClient())
                                {
                                    wc.DownloadFile(_ProductImage, writeToFilePath);

                                    _ProductImage prImage = new _ProductImage()
                                    {
                                        ImagePath = staticPath + filepath,
                                        OriginalImagePath = _ProductImage
                                    };
                                    productData.ProductImages.Add(prImage);
                                }
                            }

                            imageCounter++;
                        }

                        CreateOrUpdate_ProductImages(14, productData);
                    }
                }
                else
                {
                    CreateLog(14, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                }
            }
            catch (Exception ex)
            {
                CreateLog(14, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        private void GetWebSiteProductDataToSql_Lufian()
        {
            try
            {
                string filePath = Application.StartupPath.Replace(@"\bin", @"\DataFiles") + @"\Lufian_urunler.xlsx";
                string cnnString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + @";Extended Properties=""Excel 12.0 Xml; HDR = YES""";
                OleDbConnection cnn = new OleDbConnection(cnnString);
                OleDbCommand cmd = new OleDbCommand("Select * From [Tablo1$]", cnn);
                cnn.Open();

                OleDbDataReader rdr = cmd.ExecuteReader();

                List<string> kodlar = new List<string>();
                while (rdr.Read())
                {
                    string kod = rdr["Madde Kodu"]?.ToString();
                    string urunAdi = rdr["Ürün Adı"]?.ToString() + "-" + rdr["Renk Açıklaması"]?.ToString();

                    if (kodlar.IndexOf(kod) == -1)
                    {
                        string productId = kod;
                        string productName = urunAdi;
                        string productSku = kod;
                        string productBrand = "Lufian";
                        string productOldPrice = "0";
                        string productPrice = "0";
                        string productCategories = rdr["Ürün Grubu"]?.ToString();
                        string productUrlKey = "";
                        string productUrl = "https://www.lufian.com/" + TurkishCharacterToEnglish(urunAdi.ToLower(new CultureInfo("en-US", true)).Replace(' ', '-'));
                        string productBreadCrumb = "";
                        var productDescription = "";

                        kodlar.Add(kod);


                        var _ProductImages = new List<string>();


                        var web = new HtmlWeb();
                        var doc = web.Load(productUrl);

                        var divImages = doc.DocumentNode.Descendants("ul")
                                                        .SingleOrDefault(p => p.GetAttributeValue("id", "") == "productImage");

                        if (divImages != null)
                        {
                            _ProductImages = divImages.Descendants("li")
                                                      .Select(p => p.Descendants("a").Select(u => u.GetAttributeValue("href", "")).FirstOrDefault()).ToList();
                        }

                        productPrice = doc.DocumentNode.Descendants("span")
                                                       .FirstOrDefault(p => p.GetAttributeValue("class", "") == "product-price")?.InnerHtml.Trim();

                        if (_ProductImages.Any())
                        {
                            var categories = new List<Tuple<int, string>>().Select(t => new { categoryId = t.Item1, categoryName = t.Item2 }).ToList();
                            categories.Add(new { categoryId = 1, categoryName = productCategories.HtmlDecode().Trim() });

                            CreateOrUpdateCategory(18, categories);

                            _Product productData = new _Product()
                            {
                                ProductId = productId,
                                ProductName = productName,
                                ProductSku = productSku,
                                ProductBrand = productBrand,
                                ProductOldPrice = Convert.ToDecimal(productOldPrice),
                                ProductPrice = string.IsNullOrEmpty(productPrice) ? 0 : Convert.ToDecimal(productPrice.Replace('.', ',')),
                                ProductCategories = productCategories,
                                ProductUrlKey = productUrlKey,
                                ProductUrl = productUrl,
                                ProductDescription = productDescription,
                                ProductBreadCrumb = productBreadCrumb,
                                ProductImages = new List<_ProductImage>(),
                                ProductThumbnailImages = new List<_ProductImage>()
                            };

                            if (!products.Any(p => p.ProductId == productData.ProductId))
                            {
                                productData.ProductBrandId = CreateOrUpdateBrand(18, productData.ProductBrand);

                                products.Add(productData);

                                bool urunVarmi = CreateOrUpdateProduct(18, productData);

                                if (!urunVarmi)
                                {
                                    CreateOrUpdateProductCategories(18, productData, categories);

                                    int imageCounter = 1;
                                    foreach (var _ProductImage in _ProductImages)
                                    {
                                        //TODO: resim veritabanında varsa indirme yoksa indir ve veritabanına yaz
                                        var _ProductImageUri = new Uri(_ProductImage);
                                        string _ProductImageBaseUri = _ProductImageUri.GetLeftPart(UriPartial.Authority);
                                        var _ProductImageExtension = Path.GetExtension(_ProductImage);
                                        var _ProductImageName = _ProductImageUri.AbsolutePath.Replace("/", "").Replace(_ProductImageExtension, "");
                                        var _ProductImageFullName = _ProductImageName + _ProductImageExtension;

                                        string imageDirectory = string.IsNullOrEmpty(productData.ProductSku) ? productData.ProductId.ToString() : productData.ProductSku;
                                        string staticPath = @"\Data\Lufian\";
                                        string writeToPath = Application.StartupPath.Replace(Application.ProductName + "\\bin", "") + staticPath + imageDirectory;
                                        string writeToFilePath = writeToPath + "\\" + _ProductImageFullName;

                                        //eğer klasör yoksa oluştur
                                        if (!Directory.Exists(writeToPath))
                                        {
                                            Directory.CreateDirectory(writeToPath);
                                        }

                                        //eğer dosya yoksa indir
                                        string filepath = imageDirectory + "\\" + _ProductImageFullName;
                                        if (!File.Exists(writeToFilePath))
                                        {
                                            using (WebClient wc = new WebClient())
                                            {
                                                wc.DownloadFile(_ProductImage, writeToFilePath);

                                                _ProductImage prImage = new _ProductImage()
                                                {
                                                    ImagePath = staticPath + filepath,
                                                    OriginalImagePath = _ProductImage
                                                };
                                                productData.ProductImages.Add(prImage);
                                            }
                                        }

                                        imageCounter++;
                                    }

                                    CreateOrUpdate_ProductImages(18, productData);
                                }
                            }
                        }
                        else
                        {
                            CreateLog(18, "GetWebSiteProductDataToSql", "ProductInfo verisi bulunamadı.");
                        }
                    }
                }

                cnn.Close();
            }
            catch (Exception ex)
            {
                CreateLog(18, "GetWebSiteProductDataToSql", ex.Message);
            }
        }

        #region Ortak

        //OK
        private void MakeProductLinkHistoryPassive(int webSiteId)
        {
            //veritabanındaki bütün linkleri pasif et            
            SqlConnection cnn = new SqlConnection(connectionString);
            string command = @"Update [DataAktarim].[DataUrunLink]
                               Set IsActive=0
                               Where WebSiteID=@WebSiteID";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //OK
        private void MakeProductPassive(int webSiteId)
        {
            //veritabanındaki bütün ürünleri pasif et
            SqlConnection cnn = new SqlConnection(connectionString);
            string command = @"Update [DataAktarim].[DataUrun]
                               Set IsActive=0
                               Where WebSiteID=@WebSiteID";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        //OK
        private List<string> GetProductLinkHistories(int webSiteId)
        {
            List<string> allProductLinks = new List<string>();

            //sayfalara girip içerisindeki dataları almalı.
            SqlConnection cnn = new SqlConnection(connectionString);
            string command = @"Select 
                               ProductLink
                               From [DataAktarim].[DataUrunLink]
                               Where IsActive=1
                               And WebSiteID=@WebSiteID";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cnn.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                allProductLinks.Add(rdr.GetString(0));
            }
            cnn.Close();
            return allProductLinks;
        }

        //OK
        private int GetProductId(int webSiteId, string originalId)
        {
            int foundedProductID = 0;
            SqlConnection cnn = new SqlConnection(connectionString);

            //böyle bir product var mı?
            string command = @"Select 
                               DataUrunID
                               From [DataAktarim].[DataUrun]
                               Where WebSiteID=@WebSiteID
                               and OriginalID=@OriginalID";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cmd.Parameters.AddWithValue("@OriginalID", originalId);
            cnn.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                foundedProductID = rdr.GetInt32(0);
            }
            cnn.Close();

            return foundedProductID;
        }

        //OK
        private void CreateOrUpdateProductLinkHistory(int webSiteId, string pageUrl)
        {
            int foundedProductLinkHistoryID = 0;

            SqlConnection cnn = new SqlConnection(connectionString);

            //böyle bir link var mı?
            string command = @"Select 
                               ProductLinkHistoryID
                               From [DataAktarim].[DataUrunLink]
                               Where WebSiteID = @WebSiteID
                               and ProductLink = @ProductLink";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cmd.Parameters.AddWithValue("@ProductLink", pageUrl);
            cnn.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                foundedProductLinkHistoryID = rdr.GetInt32(0);
            }
            cnn.Close();

            if (foundedProductLinkHistoryID == 0)
            {
                //insert
                cnn = new SqlConnection(connectionString);
                command = @"Insert Into [DataAktarim].[DataUrunLink]
                            Values (@WebSiteID, @ProductLink, @LastModifiedDate, @IsActive)";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                cmd.Parameters.AddWithValue("@ProductLink", pageUrl);
                cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", true);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
            else
            {
                //update aktif
                cnn = new SqlConnection(connectionString);
                command = @"Update [DataAktarim].[DataUrunLink]
                            Set LastModifiedDate=@LastModifiedDate, IsActive=@IsActive
                            Where ProductLinkHistoryID=@ProductLinkHistoryID";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@ProductLinkHistoryID", foundedProductLinkHistoryID);
                cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", true);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }
        }

        //OK
        private void CreateOrUpdateCategory(int webSiteId, IEnumerable<dynamic> categories)
        {
            int? parentCategoryId = null;
            string categoryName = "";
            foreach (dynamic category in categories)
            {
                int categoryId = Convert.ToInt32(category.categoryId);

                if (string.IsNullOrEmpty(categoryName))
                {
                    string catName = category.categoryName;
                    categoryName = catName.HtmlDecode();
                }
                else
                {
                    string catName = category.categoryName;
                    categoryName += " > " + catName.HtmlDecode();
                }

                SqlConnection cnn = new SqlConnection(connectionString);

                //böyle bir kategori var mı?
                int foundedCategoryId = 0;
                string command = @"Select 
                                   CategoryID
                                   From [DataAktarim].[DataKategori]
                                   Where WebSiteID=@WebSiteID
                                   and CategoryName=@CategoryName";
                SqlCommand cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                cnn.Open();
                var rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    foundedCategoryId = rdr.GetInt32(0);
                }
                cnn.Close();

                if (foundedCategoryId == 0)
                {
                    command = @"Insert Into [DataAktarim].[DataKategori]
                                Values (@WebSiteID, @OriginalCategoryID, @ParentOriginalCategoryID, @TargetCategoryID, @CategoryName, @LastModifiedDate, @IsActive)";
                    cmd = new SqlCommand(command, cnn);
                    cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                    cmd.Parameters.AddWithValue("@OriginalCategoryID", categoryId.ToString());
                    cmd.Parameters.AddWithValue("@ParentOriginalCategoryID", parentCategoryId.HasValue ? (object)parentCategoryId.Value.ToString() : DBNull.Value);
                    cmd.Parameters.AddWithValue("@TargetCategoryID", DBNull.Value);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                    cmd.Parameters.AddWithValue("@IsActive", 1);
                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    cnn.Close();
                }

                parentCategoryId = categoryId;
            }
        }

        //OK
        private int CreateOrUpdateBrand(int webSiteId, string markaAdi)
        {
            markaAdi = markaAdi.HtmlDecode();

            //marka varsa idsini al, yoksa insert et. çünkü o marka üründe kullanılacak
            int markaId = 0;
            SqlConnection cnn = new SqlConnection(connectionString);
            string command = @"Select 
                               DataMarkaID
                               From [DataAktarim].[DataMarka]
                               Where WebSiteID=@WebSiteID
                               and MarkaAdi=@MarkaAdi";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cmd.Parameters.AddWithValue("@MarkaAdi", markaAdi);
            cnn.Open();
            var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                markaId = rdr.GetInt32(0);
            }
            cnn.Close();

            if (markaId == 0)
            {
                command = @"Insert Into [DataAktarim].[DataMarka]
                            Values (@WebSiteID, @MarkaAdi, @LastModifiedDate, @IsActive);
                            Select @@identity";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                cmd.Parameters.AddWithValue("@MarkaAdi", markaAdi);
                cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cnn.Open();
                markaId = Convert.ToInt32(cmd.ExecuteScalar());
                cnn.Close();
            }

            return markaId;
        }

        //OK
        private bool CreateOrUpdateProduct(int webSiteId, _Product productData)
        {
            bool result = true;
            string command = "";
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, cnn);
            int foundedProductId = GetProductId(webSiteId, productData.ProductId);

            if (foundedProductId == 0)
            {
                result = false;
                //insert      
                command = @"Insert Into [DataAktarim].[DataUrun]
                            Values (@WebSiteID, @DataMarkaID, @OriginalID, @Name, @SKU, @OldPrice, @Price, @Url, @Description, @LastModifiedDate, @IsActive);
                            Select @@identity";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                cmd.Parameters.AddWithValue("@DataMarkaID", productData.ProductBrandId);
                cmd.Parameters.AddWithValue("@OriginalID", productData.ProductId);
                cmd.Parameters.AddWithValue("@Name", productData.ProductName.HtmlDecode());
                cmd.Parameters.AddWithValue("@SKU", productData.ProductSku);
                cmd.Parameters.AddWithValue("@OldPrice", Convert.ToDecimal(productData.ProductOldPrice));
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(productData.ProductPrice));
                cmd.Parameters.AddWithValue("@Url", productData.ProductUrl);
                cmd.Parameters.AddWithValue("@Description", string.IsNullOrEmpty(productData.ProductDescription) ? DBNull.Value : (object)productData.ProductDescription);
                cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cnn.Open();
                foundedProductId = Convert.ToInt32(cmd.ExecuteScalar());
                cnn.Close();
            }
            else
            {
                result = true;
                //update aktif
                command = @"Update [DataAktarim].[DataUrun]
                            Set Name=@Name, OldPrice=@OldPrice, Price=@Price, LastModifiedDate=@LastModifiedDate, IsActive=@IsActive
                            Where DataUrunId=@DataUrunId";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@DataUrunId", foundedProductId);
                cmd.Parameters.AddWithValue("@Name", productData.ProductName.HtmlDecode());
                cmd.Parameters.AddWithValue("@OldPrice", Convert.ToDecimal(productData.ProductOldPrice));
                cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(productData.ProductPrice));
                cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                cmd.Parameters.AddWithValue("@IsActive", 1);
                cnn.Open();
                cmd.ExecuteNonQuery();
                cnn.Close();
            }

            //ürün fiyat tarihçesi tut
            command = @"Insert Into [DataAktarim].[DataUrunFiyatTarihce]
                        Values (@DataUrunId, @OldPrice, @Price, @LastModifiedDate, @IsActive)";
            cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@DataUrunId", foundedProductId);
            cmd.Parameters.AddWithValue("@OldPrice", Convert.ToDecimal(productData.ProductOldPrice));
            cmd.Parameters.AddWithValue("@Price", Convert.ToDecimal(productData.ProductPrice));
            cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
            cmd.Parameters.AddWithValue("@IsActive", 1);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();

            return result;
        }

        //OK
        private void CreateOrUpdateProductCategories(int webSiteId, _Product productData, IEnumerable<dynamic> categories)
        {
            string command = "";
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, cnn);
            SqlDataReader rdr;
            int foundedProductId = GetProductId(webSiteId, productData.ProductId);

            if (foundedProductId != 0)
            {
                //bu productın categorysi var mı?
                //böyle bir category var mı?
                List<int> foundedCategories = new List<int>();
                command = @"Select 
                            CategoryID
                            From [DataAktarim].[DataUrunKategori]
                            Where ProductID=@ProductID";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@ProductID", foundedProductId);
                cnn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    foundedCategories.Add(rdr.GetInt32(0));
                }
                cnn.Close();

                string categoryName = "";
                foreach (dynamic category in categories)
                {
                    if (string.IsNullOrEmpty(categoryName))
                    {
                        string catName = category.categoryName;
                        categoryName = catName.HtmlDecode();
                    }
                    else
                    {
                        string catName = category.categoryName;
                        categoryName += " > " + catName.HtmlDecode();
                    }


                    int foundedCategoryId = 0;
                    command = @"Select 
                                CategoryID
                                From [DataAktarim].[DataKategori]
                                Where CategoryName=@CategoryName
                                and WebSiteID=@WebSiteID";
                    cmd = new SqlCommand(command, cnn);
                    cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
                    cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                    cnn.Open();
                    rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        foundedCategoryId = rdr.GetInt32(0);
                    }
                    cnn.Close();

                    if (!foundedCategories.Contains(foundedCategoryId))
                    {
                        //insert      
                        command = @"Insert Into [DataAktarim].[DataUrunKategori]
                                    Values (@ProductID, @CategoryID, @LastModifiedDate, @IsActive)";
                        cmd = new SqlCommand(command, cnn);
                        cmd.Parameters.AddWithValue("@ProductID", foundedProductId);
                        cmd.Parameters.AddWithValue("@CategoryID", foundedCategoryId);
                        cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();
                    }
                }
            }
        }

        //OK
        private void CreateOrUpdate_ProductImages(int webSiteId, _Product productData)
        {
            string command = "";
            SqlConnection cnn = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(command, cnn);
            SqlDataReader rdr;
            int foundedProductId = GetProductId(webSiteId, productData.ProductId);

            if (foundedProductId != 0)
            {
                //bu productın imageları var mı?

                List<string> founded_ProductImages = new List<string>();
                command = @"Select 
                            ImagePath
                            From [DataAktarim].[DataUrunResim]
                            Where ProductID=@ProductID";
                cmd = new SqlCommand(command, cnn);
                cmd.Parameters.AddWithValue("@ProductID", foundedProductId);
                cnn.Open();
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    founded_ProductImages.Add(rdr.GetString(0));
                }
                cnn.Close();

                int imageOrder = founded_ProductImages.Count() + 1;
                foreach (var _ProductImage in productData.ProductImages)
                {
                    if (!founded_ProductImages.Contains(_ProductImage.ImagePath))
                    {
                        //insert      
                        command = @"Insert Into [DataAktarim].[DataUrunResim]
                                    Values (@ProductID, @ImagePath, @OriginalImagePath, @OrderNumber, @LastModifiedDate, @IsActive)";
                        cmd = new SqlCommand(command, cnn);
                        cmd.Parameters.AddWithValue("@ProductID", foundedProductId);
                        cmd.Parameters.AddWithValue("@ImagePath", _ProductImage.ImagePath);
                        cmd.Parameters.AddWithValue("@OriginalImagePath", _ProductImage.OriginalImagePath);
                        cmd.Parameters.AddWithValue("@OrderNumber", imageOrder);
                        cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@IsActive", 1);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                        cnn.Close();

                        imageOrder++;
                    }
                }
            }
        }

        //OK
        private void CreateLog(int webSiteId, string processName, string errorLogContent)
        {
            //log kaydına yaz               
            SqlConnection cnn = new SqlConnection(connectionString);
            string command = @"Insert Into [DataAktarim].[DataHataLog]
                               Values (@WebSiteID, @ProcessName, @ErrorLogContent, @LastModifiedDate)";
            SqlCommand cmd = new SqlCommand(command, cnn);
            cmd.Parameters.AddWithValue("@WebSiteID", webSiteId);
            cmd.Parameters.AddWithValue("@ProcessName", processName);
            cmd.Parameters.AddWithValue("@ErrorLogContent", errorLogContent);
            cmd.Parameters.AddWithValue("@LastModifiedDate", DateTime.Now);
            cnn.Open();
            cmd.ExecuteNonQuery();
            cnn.Close();
        }

        #endregion

        #endregion

        #region Transform Events

        //OK
        private void btnBrandTransform_Click(object sender, EventArgs e)
        {
            var dbSourceEntities = new DBTargetEntities();
            var dBTargetEntities = new DBTargetEntities();

            var dateTime = DateTime.Now;

            var targetInsertProductList = dBTargetEntities.Marka
                                                          .AsNoTracking()
                                                          .ToList();
            var sourceInsertProductList = dbSourceEntities.DataMarka
                                                          .AsNoTracking()
                                                          .ToList()
                                                          .Where(p => p.IsActive &&
                                                                      !targetInsertProductList.Any(x => x.WebSiteId == p.WebSiteID &&
                                                                                                        x.MarkaAdi == p.MarkaAdi))
                                                          .ToList()
                                                          .Select(p => new Marka()
                                                          {
                                                              MarkaId = p.DataMarkaID,
                                                              WebSiteId = p.WebSiteID,
                                                              MarkaAdi = p.MarkaAdi,
                                                              Aciklama = null,
                                                              ResimUrl = null,
                                                              Resim = null,
                                                              AnasayfadaGosterilsin = false,
                                                              MetaKeywords = null,
                                                              MetaDescription = null,
                                                              MetaTitle = null,
                                                              KayitTarih = dateTime,
                                                              Sira = 0,
                                                              AktifMi = p.IsActive,
                                                          });

            EFBatchOperation.For(dBTargetEntities, dBTargetEntities.Marka).InsertAll(sourceInsertProductList);
        }

        //OK
        private void btnProductTransform_Click(object sender, EventArgs e)
        {
            var dbSourceEntities = new DBTargetEntities();
            var dBTargetEntities = new DBTargetEntities();
            var dateTime = DateTime.Now;

            var sourceUpdateProducts = dbSourceEntities.DataUrun
                                                       .AsNoTracking()
                                                       .ToList();

            var targetUpdateProductList = dBTargetEntities.Urun
                                                          .ToList();
            int sayac = 0;
            targetUpdateProductList.ForEach(p =>
            {
                sayac++;

                var sourceProduct = sourceUpdateProducts.FirstOrDefault(x => x.SKU == p.Sku &&
                                                                             x.OriginalID == p.OriginalId);

                if (sourceProduct == null)
                    return;

                p.OriginalId = sourceProduct.OriginalID;
                p.MarkaId = sourceProduct.BrandID;
                p.WebSiteId = sourceProduct.WebSiteID;
                p.Sku = sourceProduct.SKU;
                p.UrunAdi = sourceProduct.Name;
                p.KisaAciklama = null;
                p.Aciklama = string.IsNullOrEmpty(sourceProduct.Description) ? sourceProduct.Name : sourceProduct.Description;
                p.Fiyat = sourceProduct.Price;
                p.Etiketler = sourceProduct.DataMarka.MarkaAdi + "|" + string.Join("|", sourceProduct.DataUrunKategori.Select(o => o.DataKategori.CategoryName));
                p.AdresUrl = sourceProduct.Url;
                //p.AnasayfadaGoster = false;
                //p.GoruntulenmeSayisi = 0;
                p.MetaKeywords = null;
                p.MetaDescription = null;
                p.MetaTitle = null;
                //p.KayitTarih = DateTime.Now;
                p.GuncellemeTarih = DateTime.Now;
                //p.Sira = 0;
                //p.AktifMi = true;
            });

            dBTargetEntities.SaveChanges();

            //EFBatchOperation.For(dBTargetEntities, dBTargetEntities.Urun).UpdateAll(targetUpdateProductList, p => p.ColumnsToUpdate(x => x.UrunAdi, x => x.Aciklama, x => x.Fiyat));

            var targetInsertProductList = dBTargetEntities.Urun
                                                          .AsNoTracking()
                                                          .ToList();

            var sourceInsertProductList = dbSourceEntities.DataUrun
                                                          .Include("DataMarka")
                                                          .Include("DataUrunKategori")
                                                          .Include("DataUrunKategori.DataKategori")
                                                          .AsNoTracking()
                                                          .ToList()
                                                          .Where(p => p.IsActive
                                                                      && !targetInsertProductList.Any(x => x.Sku == p.SKU &&
                                                                                                           x.OriginalId == p.OriginalID))
                                                          .ToList()
                                                          .Select(p => new Urun()
                                                          {
                                                              UrunId = p.DataUrunID,
                                                              OriginalId = p.OriginalID,
                                                              WebSiteId = p.WebSiteID,
                                                              MarkaId = p.BrandID,
                                                              Sku = p.SKU,
                                                              UrunAdi = p.Name,
                                                              KisaAciklama = null,
                                                              Aciklama = string.IsNullOrEmpty(p.Description) ? p.Name : p.Description,
                                                              Fiyat = p.Price,
                                                              Etiketler = p.DataMarka.MarkaAdi + "|" + string.Join("|", p.DataUrunKategori.Select(o => o.DataKategori.CategoryName)),
                                                              AdresUrl = p.Url,
                                                              AnasayfadaGoster = false,
                                                              GoruntulenmeSayisi = 0,
                                                              MetaKeywords = null,
                                                              MetaDescription = null,
                                                              MetaTitle = null,
                                                              KayitTarih = DateTime.Now,
                                                              GuncellemeTarih = DateTime.Now,
                                                              Sira = 0,
                                                              AktifMi = true
                                                          });

            EFBatchOperation.For(dBTargetEntities, dBTargetEntities.Urun).InsertAll(sourceInsertProductList, batchSize: 500);
        }

        //OK
        private void btnCategoryTransform_Click(object sender, EventArgs e)
        {
            var dbSourceEntities = new DBTargetEntities();
            var dBTargetEntities = new DBTargetEntities();

            var dateTime = DateTime.Now;

            //update kısmı açılacak
            //var sourceUpdateProductList = dbSourceEntities.DataUrunKategori
            //                                              .AsNoTracking()
            //                                              .Select(p => p.ProductCategoryID)
            //                                              .ToList();

            //var sourceUpdateProducts = dbSourceEntities.DataUrunKategori
            //                                           .Include("DataKategori")
            //                                           .AsNoTracking()
            //                                           .ToList();

            //var targetUpdateProductList = dBTargetEntities.UrunKategori
            //                                              .ToList();

            //targetUpdateProductList.ForEach(p =>
            //{
            //    var sourceProduct = sourceUpdateProducts.FirstOrDefault(x => x.ProductCategoryID == p.UrunKategoriId);

            //    if (sourceProduct.DataKategori != null && sourceProduct.DataKategori.TargetCategoryID != null)
            //    {
            //        p.UrunId = sourceProduct.ProductID;
            //        p.KategoriId = sourceProduct.DataKategori.TargetCategoryID.Value;
            //    }
            //});

            //EFBatchOperation.For(dBTargetEntities, dBTargetEntities.UrunKategori).UpdateAll(targetUpdateProductList, p => p.ColumnsToUpdate(x => x.UrunId, x => x.KategoriId));

            var targetInsertProductList = dBTargetEntities.UrunKategori
                                                          .Include("Urun")
                                                          .AsNoTracking()
                                                          .ToList();

            var targetproductlist = dBTargetEntities.Urun.ToList();

            var sourceInsertProductList = dbSourceEntities.DataUrunKategori
                                                          .Include("DataUrun")
                                                          .Include("DataKategori")
                                                          .AsNoTracking()
                                                          .ToList()
                                                          .Where(p => p.IsActive
                                                                      && p.DataKategori != null
                                                                      && p.DataKategori.TargetCategoryID != null
                                                                      && !targetInsertProductList.Any(x => x.Urun.OriginalId == p.DataUrun.OriginalID &&
                                                                                                           x.KategoriId == p.DataKategori.TargetCategoryID.Value))
                                                          .ToList()
                                                          .Select(p => new UrunKategori()
                                                          {
                                                              //UrunKategoriId = p.ProductCategoryID,
                                                              UrunId = targetproductlist.FirstOrDefault(x => x.OriginalId == p.DataUrun.OriginalID).UrunId,
                                                              KategoriId = p.DataKategori.TargetCategoryID.Value,
                                                              Sira = 0,
                                                              AktifMi = true
                                                          });

            EFBatchOperation.For(dBTargetEntities, dBTargetEntities.UrunKategori).InsertAll(sourceInsertProductList, batchSize: 500);
        }

        //OK
        private void btnPictureTransform_Click(object sender, EventArgs e)
        {
            int webSiteId = 4;

            var dbEntities = new DBTargetEntities();
            var dateTime = DateTime.Now;

            var targetInsertList = dbEntities.UrunResim
                                             .Include("Urun")
                                             .AsNoTracking()
                                             .Where(p => p.Urun.WebSiteId == webSiteId)
                                             .Select(p => p.OrjinalResimUrl)
                                             .ToList();

            var targetList = dbEntities.Urun.Where(p => p.WebSiteId == webSiteId)
                                            .Select(p => new { p.UrunId, p.OriginalId });

            var sourceInsertList = dbEntities.DataUrunResim
                                             .Include("DataUrun")
                                             .Include("DataUrun.WebSite")
                                             .AsNoTracking()
                                             .Where(p => p.IsActive &&
                                                         p.DataUrun.WebSiteID == webSiteId)
                                             .ToList()
                                             .Where(p => targetInsertList.IndexOf(p.OriginalImagePath) == -1)
                                             .Select(p => new UrunResim()
                                             {
                                                 //UrunResimId = p.DataUrunResimID,
                                                 UrunId = targetList.FirstOrDefault(x => x.OriginalId == p.DataUrun.OriginalID) == null ? -1 : targetList.FirstOrDefault(x => x.OriginalId == p.DataUrun.OriginalID).UrunId,
                                                 OrjinalResimUrl = p.OriginalImagePath,
                                                 ResimUrl = p.ImagePath,
                                                 Sira = p.OrderNumber,
                                                 KayitTarih = dateTime,
                                                 AktifMi = true
                                             });

            int c = sourceInsertList.Count();

            EFBatchOperation.For(dbEntities, dbEntities.UrunResim).InsertAll(sourceInsertList, batchSize: 500);
        }

        //OK
        private DataUrun GetProductFromSource(string Sku)
        {
            DataUrun product = null;

            using (var dbSourceEntities = new DBTargetEntities())
            {
                product = dbSourceEntities.DataUrun.SingleOrDefault(p => p.SKU == Sku);
            }

            return product;
        }

        //OK
        private Urun GetProductFromTarget(string Sku)
        {
            Urun product = null;

            using (var dbTargetEntities = new DBTargetEntities())
            {
                product = dbTargetEntities.Urun.SingleOrDefault(p => p.Sku == Sku);
            }

            return product;
        }
        #endregion

        #region Helpers

        string saatvesaatIgnoreText = "\n    <div class=\"hide\" id=\"messages\"><ul class=\"messages\"><li class=\"notice-msg\"><ul><li><span>Ürün İçeriği Hazırlanıyor.</span></li></ul></li></ul></div>\n<p class=\"mnm-g-info mb15\">\n    Sitemizde bulunan tüm <strong>Guess</strong> Ürün Modelleri SAAT VE SAAT SANAYİ TİCARET A.Ş güvencesi altındadır. Alacağınız bu ürün 2 yıl garanti kapsamındadır. Siparişiniz onaylanmış orijinal garanti belgesi ve kutusu ile anlaşmalı kargo firması (MNG Kargo) tarafından adresinize teslim edilecektir. \"Aynı gün Kargoda\" ibaresi yer alan ürünler \"Hızlı Teslimat” seçeneği tercih edildiği takdirde gün içinde teslim edilmektedir. Bu hizmetten 14:00'a kadar faydalanabilirsiniz. Bunun dışındaki siparişleriniz ortalama 5 iş günü içerisinde kargo yetkilisine teslim edilecektir.</p>\n";

        //string saatvesaatIgnoreText = "<div class=\"hide\" id=\"messages\"><ul class=\"messages\"><li class=\"notice-msg\"><ul><li><span>Ürün İçeriği Hazırlanıyor.</span></li></ul></li></ul></div>";

        public string TurkishCharacterToEnglish(string text)
        {
            char[] turkishChars = { 'ı', 'ğ', 'İ', 'Ğ', 'ç', 'Ç', 'ş', 'Ş', 'ö', 'Ö', 'ü', 'Ü' };
            char[] englishChars = { 'i', 'g', 'I', 'G', 'c', 'C', 's', 'S', 'o', 'O', 'u', 'U' };

            // Match chars
            for (int i = 0; i < turkishChars.Length; i++)
                text = text.Replace(turkishChars[i], englishChars[i]);

            return text;
        }

        #endregion
    }
}
