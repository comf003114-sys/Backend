namespace ChaChaClub.Domains.Models.Dish
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }

    public class DishDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDailyDish { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateDishDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }
        public bool IsDailyDish { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
    }
}