using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.Enums
{
    public enum MedicineType
    {
        [Display (Name = "Таблетки")]
        Tablets,
        [Display (Name = "Мазь")]
        Ointment,
        [Display (Name = "Спрей")]
        Spray,
        [Display (Name = "Сироп")]
        Syrup,
        [Display (Name = "Капли")]
        Drops,
        [Display (Name = "Инъекции")]
        Injection,
        [Display (Name = "Порошок")]
        Powder,
        [Display (Name = "Пластырь")]
        Patch
    }
}
