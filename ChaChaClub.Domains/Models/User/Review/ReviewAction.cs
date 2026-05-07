namespace ChaChaClub.Domains.Models.Review
{
    public class CreateReviewDto
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int DishId { get; set; }
    }

    public class ReviewDto
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public int Rating { get; set; }
        public int DishId { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}