using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace StockMarket.Models
{
    public class Stock
    {
        [Key]
        public Guid StockId { get; set; }
        [Required]
        [StringLength(20)]
        public string StockName { get; set; }
        [Required]
        [StringLength(15)]
        public string StockSymbol { get; set; }
        [Required]
        [StringLength(20)]
        public double Price { get; set; }
        [Required]
        [StringLength(20)]
        public DateTime CreationDate { get; set; }

    }
}