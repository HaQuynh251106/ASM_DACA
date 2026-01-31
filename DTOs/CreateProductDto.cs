using System.ComponentModel.DataAnnotations;

namespace ASM_Bai2.DTOs
{
    public class CreateProductDto
    {
        [Required(ErrorMessage = "Ten san pham khong duoc de trong")]
        public string ProductName { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Gia phai lon hon 0")]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
