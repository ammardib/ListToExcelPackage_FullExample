using System;
using System.ComponentModel.DataAnnotations;

namespace ExamplesListToExcelPackage.Domain.Models
{
    public class Order
    {
        [Display(Name = "Order Id", Order = 1)]
        public int OrderId { get; set; }
        [Display(Name = "Order Date", Order = 2)]
        public DateTime OrderDate { get; set; }
        [Display(Name = "Order Amount", Order = 3)]
        public Decimal OrderAmount { get; set; }
    }
}
