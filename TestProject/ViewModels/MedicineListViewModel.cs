using TestProject.Models;

namespace TestProject.ViewModels
{
    public class MedicineListViewModel
    {
        public List<Medicine> AllMedicines { get; set; } = new();
        public List<Medicine> ExpiringSoon { get; set; } = new();
        public List<Medicine> RunningOut { get; set; } = new();
        public string? SearchQuery { get; set; }
        public CreateMedicineViewModel CreateMedicine { get; set; } = new();
        public int? EditMedicineId { get; set; }
        public EditMedicineViewModel? EditMedicine { get; set; }
        public bool OpenCreateMedicineModal { get; set; }
    }
}
