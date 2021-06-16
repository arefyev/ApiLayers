namespace Sample7.Models
{
    public sealed class User : IModel
    {
        public int Id { get; set; }

        public UserName Name { get; set; }

        public string UserName { get; set; }
    }
}
