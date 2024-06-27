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


        //reference to clothingmodel
        public int ProductId { get; set; }

        [Display(Name = "Produkt")]
        public Product? Product { get; set; }


        // reference to Sellermodel
        public int SellerId { get; set; }

        [Display(Name = "Säljare")]
        public Seller? Seller { get; set; }
    }
}