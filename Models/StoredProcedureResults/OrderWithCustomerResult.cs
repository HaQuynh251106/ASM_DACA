namespace ASM_Bai2.Models.StoredProcedureResults
{
    public class OrderWithCustomerResult
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
    }
}
