using System;
using System.Collections.Generic;

namespace Sample7.Models.Views
{
    public sealed class CartView: IModel
    {
        public int Id { get; set; }

        public User User { get; set; }

        public DateTime Date { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
