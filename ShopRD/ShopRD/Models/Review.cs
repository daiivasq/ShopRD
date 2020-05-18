using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRD.Models
{
    class Review
    {
        private List<string> images;
        private string customerImage;
        public string CustomerName { get; set; }
        public string ReviewedDate { get; set; }
        public double Rating { get; set; }
        public string Comment { get; set; }
    }
}
