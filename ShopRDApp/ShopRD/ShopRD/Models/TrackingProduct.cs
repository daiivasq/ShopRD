﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ShopRD.Models
{
    class TrackingProduct
    {
        private string status;
        public string Title { get; set; }

     
        public string TitleStatus { get; set; }

        public string OrderStatus { get; set; }

     
        public double ProgressValue { get; set; }

      
        public string Status
        {
            get
            {
                return this.status;
            }

            set
            {
                this.status = value;
                if (this.status != null)
                {
                    this.StepStatus = this.Status == "InProgress" ? StepStatus.InProgress : this.Status == "Completed" ? StepStatus.Completed : StepStatus.NotStarted;
                }
            }
        }

        public StepStatus StepStatus { get; set; }

        public string Date { get; set; }


        public string OrderDate { get; set; }

    }
}
