using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin.Models {
    public class Sale {

        //properties
        public int SaleId { get; set; }

        public DateTime SaleDate { get; set; }
        public int SalePrice { get; set; }


        //reference to clothingmodel
        public int ProductId { get; set; }
        public Product? Product { get; set; }


        // reference to Sellermodel
        public int SellerId { get; set; }

        public Seller? Seller { get; set; }
    }
}