using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public enum Category
    {
        [Display(Name = "Knuffeldier")]
        StuffedAnimal = 0,

        [Display(Name = "Speelgoed")]
        Toy = 1,
    }
}