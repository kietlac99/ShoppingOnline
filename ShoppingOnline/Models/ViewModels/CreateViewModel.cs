using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models.ViewModels
{
    public class CreateViewModel
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Product's name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Short Description is required")]
        public string shortDescription { get; set; }

        [Required(ErrorMessage = "Long Description is required")]
        public string longDescription { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }

        [Required(ErrorMessage = "Instock is required")]
        public int Instock { get; set; }

        [Required(ErrorMessage = "Category is required")]
        public string Category { get; set; }

        [Required(ErrorMessage = "Photo path is required")]
        public IFormFile photoPath { get; set; }
    }
}
