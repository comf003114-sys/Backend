using ChaChaClub.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaChaClub.Domains.Entities.Dish
{
    public class IngredientData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("Dish")]
        public int DishId { get; set; }
        public DishData Dish { get; set; }
    }
}