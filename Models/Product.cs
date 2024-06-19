using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin.Models {
    public class Product {

        //properties
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Typ av klädesplagg")]
        public string? TypeOfProduct { get; set; }

        [Required]
        [Display(Name = "Pris")]
        public int Price { get; set; }

        [Required]
        [Display(Name = "Storlek")]
        public string? Size { get; set; }

        [Required]
        [Display(Name = "Färg")]
        public string? Color { get; set; }

        [Required]
        [Display(Name = "Beskrivning")]
        public string? Description { get; set; }
        

        // for images
        public string? ImageName { get; set; }

        [NotMapped]
        [Display(Name = "Bild")]
        public IFormFile? ImageFile { get; set; }


        public bool IsSold { get; set; } = false;


        //reference to Sellermodel
        public int SellerId { get; set; }
        public Seller? Seller { get; set; }

        // reference to Categorymodel
        public int CategoryId { get; set; }
        public Category? Category{ get; set; }

    }
}