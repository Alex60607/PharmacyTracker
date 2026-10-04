namespace TestProject.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public Medicine Medicine { get; set; } = null!;
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        public DateTime IssueDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string? DoctorName { get; set; }
    }
}
