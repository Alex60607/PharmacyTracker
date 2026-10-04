using System.ComponentModel.DataAnnotations;
using TestProject.ViewModels;
using TestProject.Models.Enums;

namespace TestProject.ViewModels
{
    public class CreateMedicineViewModel
    {
        [Required(ErrorMessage = "Введите название лекарства")]
        [StringLength(200, ErrorMessage = "Название не может быть длиннее 200 символов")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Укажите тип лекарства")]
        public MedicineType Type { get; set; }
        [StringLength(50, ErrorMessage = "Дозировка не может быть длиннее 50 символов")]
        public string? Dosage { get; set; }
        [StringLength(500, ErrorMessage = "Назначение лекарства не должно быть длиннее 500 символов")]
        public string? Purpose { get; set; }
        [Required(ErrorMessage ="Выберите сколько лекарства осталось")]
        public StockLevel CurrentStockLevel { get; set; } = StockLevel.Full;
        [Required(ErrorMessage = "Укажите месяц срока годности")]
        [Range(1, 12, ErrorMessage = "Некорректный месяц")]
        [Display(Name = "Месяц")]
        public int? ExpirationMonth { get; set; }
        [Required(ErrorMessage = "Укажите год срока годности")]
        [Range(2020, 2100, ErrorMessage = "Некорректный год")]
        [Display(Name = "Год")]
        public int? ExpirationYear { get; set; }
        public bool RequiresPrescription { get; set; }
    }
}
