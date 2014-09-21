using System.Collections.Generic;

namespace WBI.Models.Product
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; } 
        public  string Image { get; set; }
        public List<Review> Reviews { get; set; }
        public Rating Rating { get; set; }
    }
}