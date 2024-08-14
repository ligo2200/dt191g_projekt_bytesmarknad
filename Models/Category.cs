using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace admin.Models
{

    public class Category
    {
        public int CategoryId { get; set; }

        [Display(Name = "Kategorinamn")]
        public string? Name { get; set; }  // Ex: "Överdel", "Underdel", "Skor"
        public ICollection<Product>? Products { get; set; }
    }
}