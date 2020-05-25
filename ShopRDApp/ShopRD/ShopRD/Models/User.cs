using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.Models
{
    public sealed class User:Person
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public IEnumerable<CarShop> CarShop { get; set; }
        public bool IsActive{ get; set; }

    }
}
