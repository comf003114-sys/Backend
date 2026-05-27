using ChaChaClub.Domains.Entities.Refs;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ChaChaClub.Domains.Entities.Wine
{
    public class WineData : SharedFields
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        public string Region { get; set; }

        public int Year { get; set; }

        public decimal Price { get; set; }

        public string Taste { get; set; }

        public string Category { get; set; }

        public string ImageUrl { get; set; }
    }
}