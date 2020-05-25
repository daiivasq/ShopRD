using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRD.Models
{
    public class Category
    {
        private string icon;
        private bool isExpanded;

        public string Icon { get; set; }
     
        public bool IsExpanded
        {
            get { return isExpanded; }
            set
            {
                isExpanded = value;
            }
        }
        public string Name { get; set; }
        public List<string> SubCategories { get; set; }
    }
}
