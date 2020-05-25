using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreWebApi.Models
{
    public abstract class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }
        public long IdCard { get; set; }
        public long Phone { get; set; }
        public DateTime BornYear { get; set; }
        public DateTime CreateUser { get => DateTime.Now; }
        public Address Address {    get; set; }
    }
}
