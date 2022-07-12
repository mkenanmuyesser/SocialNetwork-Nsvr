using Iyzipay.Request;
using Iyzipay.Model;
using System.Collections.Generic;
using NeSever.Common.Models.Satis;
using System;
using NeSever.Common.Models.Uyelik;
using Microsoft.Extensions.Configuration;


namespace Iyzipay.Samples
{
    public class Odeme3D : Sample
    {
        string url;

        public Odeme3D()
        {       

            var appSettings = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("NeSeverSettings");
            if (appSettings != null)
            {            
                url = Convert.ToString(appSettings["Url"]);
            }
        }
        public ThreedsInitialize Should_Initialize_Threeds(OdemeIcerikVM model, KullaniciVM kullanici, SepetAdresVM faturaAdresi, SepetAdresVM gonderimAdresi)
        {
            

            Options options;
            options = new Options();
            options.ApiKey = "FMS4YjUfK8g1jbdVojBa26Sg3aHCY6cJ";
            options.SecretKey = "EKSdPaGloX3UAyLzLnQqkvRakW8fa2o3";
            //options.BaseUrl = "https://sandbox-api.iyzipay.com";
            options.BaseUrl = "https://api.iyzipay.com";

            CreatePaymentRequest request = new CreatePaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = model.OdemeId.ToString();
            request.Price = model.OdenecekToplamTutar.ToString().Replace(',', '.');
            request.PaidPrice = model.OdenecekToplamTutar.ToString().Replace(',', '.');
            request.Currency = Currency.TRY.ToString();
            request.Installment = 1;
            //request.BasketId = "B67832";
            request.PaymentChannel = PaymentChannel.WEB.ToString();
            request.PaymentGroup = PaymentGroup.PRODUCT.ToString();
            request.CallbackUrl = url + "/Sepet/OdemeCallback";

            PaymentCard paymentCard = new PaymentCard();
            paymentCard.CardHolderName = model.KrediKartiAdSoyad;
            paymentCard.CardNumber = model.KrediKartiNo;
            paymentCard.ExpireMonth = model.KrediKartiSonKullanmaTarihiAy;
            paymentCard.ExpireYear = model.KrediKartiSonKullanmaTarihiYil;
            paymentCard.Cvc = model.KrediKartiCvv;
            paymentCard.RegisterCard = 0;
            request.PaymentCard = paymentCard;

            Buyer buyer = new Buyer();
            buyer.Id = kullanici.KullaniciId.ToString();
            buyer.Name = kullanici.Adi;
            buyer.Surname = kullanici.Soyadi;
            buyer.GsmNumber = kullanici.Telefon;
            buyer.Email = kullanici.Eposta;
            buyer.IdentityNumber = faturaAdresi.TcNo == null ? "11111111111" : faturaAdresi.TcNo;
            //buyer.LastLoginDate = "2015-10-05 12:43:35";
            //buyer.RegistrationDate = "2013-04-21 15:12:09";
            buyer.RegistrationAddress = faturaAdresi.AdresBilgi;
            buyer.Ip = model.KullaniciIp;
            buyer.City = faturaAdresi.AdresIlAdi;
            buyer.Country = "Türkiye";
            //buyer.ZipCode = "34732";
            request.Buyer = buyer;

            Address shippingAddress = new Address();
            shippingAddress.ContactName = gonderimAdresi.Ad + " " + gonderimAdresi.Soyad;
            shippingAddress.City = gonderimAdresi.AdresIlAdi;
            shippingAddress.Country = "Türkiye";
            shippingAddress.Description = gonderimAdresi.AdresBilgi;
            shippingAddress.ZipCode = gonderimAdresi.PostaKodu;
            request.ShippingAddress = shippingAddress;

            Address billingAddress = new Address();
            billingAddress.ContactName = faturaAdresi.Ad + " " + faturaAdresi.Soyad; ;
            billingAddress.City = faturaAdresi.AdresIlAdi;
            billingAddress.Country = "Türkiye";
            billingAddress.Description = faturaAdresi.AdresBilgi;
            billingAddress.ZipCode = faturaAdresi.PostaKodu;
            request.BillingAddress = billingAddress;

            List<BasketItem> basketItems = new List<BasketItem>();

            foreach (var item in model.SepetIcerik.SepetUrunList)
            {
                basketItems.Add(new BasketItem
                {
                    Id = item.UrunId.ToString(),
                    Name = item.UrunAdi,
                    Category1 = item.MarkaAdi,
                    Category2 = item.MarkaAdi,
                    ItemType = BasketItemType.PHYSICAL.ToString(),
                    Price = item.UrunToplamFiyat.ToString().Replace(',', '.')
                });
            }

            request.BasketItems = basketItems;

            ThreedsInitialize threedsInitialize = ThreedsInitialize.Create(request, options);

            PrintResponse<ThreedsInitialize>(threedsInitialize);

            return threedsInitialize;

        }

        public ThreedsPayment Should_Create_Threeds_Payment(CreateThreedsPaymentRequest durum)
        {
            Options options;
            options = new Options();
            options.ApiKey = "FMS4YjUfK8g1jbdVojBa26Sg3aHCY6cJ";
            options.SecretKey = "EKSdPaGloX3UAyLzLnQqkvRakW8fa2o3";
            options.BaseUrl = "https://api.iyzipay.com";

            CreateThreedsPaymentRequest request = new CreateThreedsPaymentRequest();
            request.Locale = Locale.TR.ToString();
            request.ConversationId = durum.ConversationId;
            request.PaymentId = durum.PaymentId;
            if(durum.ConversationData != null)
                request.ConversationData = durum.ConversationData;

            ThreedsPayment threedsPayment = ThreedsPayment.Create(request, options);

            PrintResponse<ThreedsPayment>(threedsPayment);

            return threedsPayment;

        }
    }
}
