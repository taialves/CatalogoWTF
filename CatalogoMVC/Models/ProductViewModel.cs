using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.ComponentModel;

namespace CatalogoMVC.Models
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [Required]
        public string? Code { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string? Supplier { get; set; }

        [Required]
        public string? Description { get; set; }

        public DateTime ExpirationDate { get; set; }

        [DisplayName("Categoria")]
        public int CategoryId { get; set; }

    }
}
