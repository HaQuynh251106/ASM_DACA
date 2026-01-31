using System.ComponentModel.DataAnnotations;

namespace ASM_Bai2.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        // 1 customer có thể có nhiều order
        public virtual ICollection<Order>Orders { get; set; }
    }
}
