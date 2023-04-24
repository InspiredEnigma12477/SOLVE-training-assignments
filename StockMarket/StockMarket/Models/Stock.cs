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
        private Guid StockId { get; set; }
        [Required]
        [StringLength(20)]
        private string StockName { get; set; }
        [Required]
        [StringLength(5)]
        private string StockSymbol { get; set; }
        [Required]
        [StringLength(20)]
        private double Price { get; set; }
        [Required]
        [StringLength(20)]
        private DateTime CreationDate { get; set; }

    }
}