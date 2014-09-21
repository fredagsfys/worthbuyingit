using System;

namespace WBI.Models.Product
{
    public class Review
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public ReviewType Type { get; set; }
    }
}
