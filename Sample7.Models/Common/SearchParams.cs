using System;
using System.ComponentModel.DataAnnotations;

namespace Sample7.Models.Common
{
    public sealed class SearchParams
    {
        [Range(0, int.MaxValue, ErrorMessage = "Параметр {0} должен быть больше {1}, но менее {2}.")]
        public int Page { get; set; }

        [Range(3, 100, ErrorMessage = "Параметр {0} должен быть больше {1}, но менее {2}.")]
        public int Count { get; set; }

        public string SortField { get; set; }

        public bool Asc { get; set; }
    }
}