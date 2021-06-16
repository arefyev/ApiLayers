using System;
using System.Collections.Generic;

namespace Sample7.Models
{
    public sealed class Cart : IModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<ProductCard> Products { get; set; }
    }
}
