using ChaChaClub.Domains.Entities.Refs;
using ChaChaClub.Domains.Entities.User;
using ChaChaClub.Domains.Entities.Dish;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaChaClub.Domains.Entities.Review
{
    public class ReviewData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(500)]
        public string Comment { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        public UserData User { get; set; }

        [ForeignKey("Dish")]
        public int DishId { get; set; }
        public DishData Dish { get; set; }
    }
}