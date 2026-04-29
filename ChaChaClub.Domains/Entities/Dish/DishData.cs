using ChaChaClub.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaChaClub.Domains.Entities.Dish
{
    public class DishData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDailyDish { get; set; } = false;

        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public CategoryData Category { get; set; }
    }
}