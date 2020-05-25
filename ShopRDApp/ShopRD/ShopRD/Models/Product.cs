using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace ShopRD.Models
{
    class Product
    {
        private bool isFavourite;

        private string previewImage;

        private List<string> previewImages;

        private int totalQuantity;

        private double actualPrice;

        private double discountPrice;

        private double discountPercent;

        private ObservableCollection<Review> reviews = new ObservableCollection<Review>();

    }
}
