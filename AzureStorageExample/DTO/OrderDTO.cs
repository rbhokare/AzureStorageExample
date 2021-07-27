using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class OrderDTO
    {
        public int OrderId { get; set; }

        [Required(ErrorMessage = "Order Date is Required")]
        public DateTime OrderDate { get; set; }

        [Required(ErrorMessage = "Order Text is Required")]
        public string OrderText { get; set; }

        //[Required(ErrorMessage = "Order Status is Required")]
        public string OrderStatus { get; set; }
    }
}
