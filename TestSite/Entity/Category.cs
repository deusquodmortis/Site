using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSite.Entity
{
    public class Category
    {
        public int Id { get; set; }
        [DisplayName("Kategori Adı")]
        [StringLength(maximumLength:20,ErrorMessage ="Max 20 karakter")]
        public string Name { get; set; }
        [DisplayName("Kategori Aıklaması")]
        public string Description { get; set; }
        public List<Product> Products { get; set; }
    }
}