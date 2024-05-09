using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalogo.API.Models
{
    [Table("Categories")]
    public class Category
    {

        // é uma boa prática iniciar a coleção aqui, já que é de responsabilidade da classe.
        public Category() { 
            Products = new Collection<Product>();
        }

        [Key]
        public int CategoryId { get; set; }

        [Required]
        [StringLength(80)]
        public string? Name { get; set; }

        public ICollection<Product> Products { get; set;}

    }
}
