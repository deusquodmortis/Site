using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestSite.Models
{
    public class ShippingDetails
    {
        public string Username { get; set; }
        [Required(ErrorMessage = "Lütfen adresi tanımı girin")]
        public string AdresBasligi { get; set; }
        [Required(ErrorMessage = "Lütfen adresi girin")]
        public string Adres { get; set; }
        [Required(ErrorMessage = "Lütfen semti girin")]
        public string Il { get; set; }
        [Required(ErrorMessage = "Lütfen mahalle girin")]
        public string Ilce { get; set; }
        public string PostaKodu { get; set; }


    }
}