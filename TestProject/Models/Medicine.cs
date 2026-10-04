using System.ComponentModel.DataAnnotations;
using TestProject.Models.Enums;

namespace TestProject.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите название лекарства")]
        [MaxLength(200)]
        public string Name { get; set; } = string.Empty;
        [Required]
        public MedicineType Type { get; set; }
        [MaxLength(50)]
        public string? Dosage { get; set; }
        [MaxLength(500)]
        public string? Purpose { get; set; }
        [Required]
        public StockLevel CurrentStockLevel { get; set; } = StockLevel.Full;
        [Required(ErrorMessage = "Укажите срок годности")]
        public DateTime ExpirationDate { get; set; }
        public bool RequiresPrescription { get; set; }
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser User { get; set; } = null!;
        public List<Prescription> Prescriptions { get; set; } = new();

    }
}
