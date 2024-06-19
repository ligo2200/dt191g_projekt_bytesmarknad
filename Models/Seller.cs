using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin.Models {
    public class Seller {

        //properties
        public int SellerId { get; set; }

        [Required]
        public string? SellerName { get; set; }

        [Required]
        public string? SellerPhoneNumber { get; set; }

        [Required]
        public string? SellerAdress { get; set; }

        // relation to Clothing
        public ICollection<Product>? Products { get; set; }

        // relation to sale
        public ICollection<Sale>? Sales { get; set; }
    }
}