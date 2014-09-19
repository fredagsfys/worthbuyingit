using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net.Mime;
using System.Web;

namespace WorthBuyingIt.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string SerialNumber { get; set; } 
        public  string Image { get; set; }
        public List<Pros> Pros { get; set; }
        public List<Cons> Cons { get; set; }
        public Rating Rating { get; set; }
    }
}