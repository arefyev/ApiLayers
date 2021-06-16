namespace Sample7.Models
{
    public sealed class Product : IModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string Image { get; set; }
    }
}
