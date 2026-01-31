using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASM_Bai2.Models
{
    public class Product 
    {
        [Key]
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }

        // truy vấn ngược lại từ Product đến Category
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        // 1 product có thể có nhiều order item
        public virtual ICollection<OrderItem> OrderItems { get; set; }

    }
}
