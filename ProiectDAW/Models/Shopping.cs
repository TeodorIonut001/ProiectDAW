using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProiectDAW.Models
{
    public class Shopping
    {
        [Key]
        public int Id { get; set; }
        public string Date { get; set; }
        public float Price { get; set; }
        public string Basket { get; set; }

    }
}