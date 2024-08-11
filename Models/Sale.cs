using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin.Models {
    public class Sale {

        //properties
        public int SaleId { get; set; }

        [Display(Name = "Försäljningsdatum")]
        public DateTime SaleDate { get; set; }

        [Display(Name = "Säljpris")]
        public int SalePrice { get; set; }

        [Display(Name = "Köparens namn")]
        public string? BuyerName { get; set; }
        
        [Display(Name = "Köparens adress")]
        public string? BuyerAdress { get; set; }


        //reference to clothingmodel
        [Display(Name = "Produkt")]
        public int ProductId { get; set; }

        [Display(Name = "Produkt")]
        public Product? Product { get; set; }


        // reference to Sellermodel
        [Display(Name = "Säljare")]
        public int SellerId { get; set; }

        [Display(Name = "Säljare")]
        public Seller? Seller { get; set; }

    }
}