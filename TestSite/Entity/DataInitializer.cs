using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace TestSite.Entity
{
    public class DataInitializer : DropCreateDatabaseIfModelChanges<DataContext>
    {
        protected override void Seed(DataContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category(){Name="Ornek",Description="Ornek Aciklama"},
                new Category(){Name="Ornek1",Description="Ornek2 Aciklama"},
                new Category(){Name="Ornek2",Description="Ornek3 Aciklama"},
                new Category(){Name="Ornek3",Description="Ornek4 Aciklama"},
                new Category(){Name="Ornek4",Description="Ornek5 Aciklama"}
            };
            foreach (var kategori in kategoriler)
            {
                context.Categories.Add(kategori);

            }
            context.SaveChanges();
            var urunler = new List<Product>()
            {
                new Product(){Name="Urun ismi 1",Description="Urun ismi 1 Açıklaması",Price= 1500,Stock= 44,IsApproved= true,CategoryId=1,IsHome=true,Image="1.Jpg"},
                new Product(){Name="Urun ismi 2",Description="Urun ismi 2 Açıklaması",Price= 2500,Stock= 21,IsApproved= true,CategoryId=1,Image="2.Jpg"},
                new Product(){Name="Urun ismi 3",Description="Urun ismi 3 Açıklaması",Price= 1400,Stock= 22,IsApproved= true,CategoryId=2,IsHome=true,Image="1.Jpg"},
                new Product(){Name="Urun ismi 4",Description="Urun ismi 4 Açıklaması",Price= 1550,Stock= 25,IsApproved= true,CategoryId=2,Image="3.Jpg"},
                new Product(){Name="Urun ismi 5",Description="Urun ismi 5 Açıklaması Uzun Ornek Urun ismi 5 Açıklaması Uzun Ornek Urun ismi 5 Açıklaması Uzun Ornek ",Price= 1560,Stock= 12,IsApproved= true,CategoryId=3,Image="4.Jpg"},
                new Product(){Name="Urun ismi 6",Description="Urun ismi 6 Açıklaması",Price= 1600,Stock= 10,IsApproved= true,CategoryId=3,IsHome=true,Image="1.Jpg"},
                new Product(){Name="Urun ismi 7",Description="Urun ismi 7 Açıklaması",Price= 4500,Stock= 23,IsApproved= true,CategoryId=4,Image="2.Jpg"},
                new Product(){Name="Urun ismi 8",Description="Urun ismi 8 Açıklaması Uzun Ornek Urun ismi 8 Açıklaması Uzun Ornek Urun ismi 8 Açıklaması Uzun Ornek ",Price= 2500,Stock= 30,IsApproved= true,CategoryId=4,Image="1.Jpg"},
                new Product(){Name="Urun ismi 9",Description="Urun ismi 9 Açıklaması",Price= 1520,Stock= 0,IsApproved= false,CategoryId=4,IsHome=true,Image="5.Jpg"},


            };
            foreach (var urun in urunler)
            {
                context.Products.Add(urun);
            }
            context.SaveChanges();

            base.Seed(context);
        }

    }
}