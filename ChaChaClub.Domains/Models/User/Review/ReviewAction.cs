namespace ChaChaClub.Domains.Models.Review
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int DishId { get; set; }
    }
}