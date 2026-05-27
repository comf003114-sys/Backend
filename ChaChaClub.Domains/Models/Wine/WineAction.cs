namespace ChaChaClub.Domains.Models.Wine
{
    public class WineDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Region { get; set; }
        public int Year { get; set; }
        public decimal Price { get; set; }
        public string Taste { get; set; }
        public string Category { get; set; }
        public string ImageUrl { get; set; }
    }

    public class CreateWineDto
    {
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