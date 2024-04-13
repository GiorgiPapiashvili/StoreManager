namespace StoreManager.DTO
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int SupplierId { get; set; }
        public int EmployeeId { get; set; }
        public SignStatus Status { get; set; }
        public DateTime PurchaseDate { get; set; }
    }
}
