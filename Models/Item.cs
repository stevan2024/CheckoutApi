using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CheckoutApi.Models
{
    public class Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string ItemId { get; set; }
        public string Name { get; set; }
        public decimal AppliedPrice { get; set; } = 0;
        public decimal AppliedDiscount { get; set; } = 0;
    }
}
