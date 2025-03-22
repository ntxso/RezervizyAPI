using System.ComponentModel.DataAnnotations;
using System;

namespace WebUI.Models
{
    public class OrderModel
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public int Status { get; set; }
        public DateTime? TakingDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public int Terminal { get; set; }
        [Range(0, 50000, ErrorMessage = "Makul bir değer girin!")]
        public decimal? Total { get; set; }
        public decimal? Paid { get; set; }
        public string Note { get; set; }
    }
}
