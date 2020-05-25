using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string TypeProduct { get; set; } 
        public IEnumerable<Size> Sizes { get; set; }
        public string Description { get; set; }
        public double Taxes { get; set; }
        public int Rate { get; set; }
        public List<Comment> Comments { get; set; }
        public List<Image> Photo { get; set; }
    }
}
