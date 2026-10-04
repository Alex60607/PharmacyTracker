using System.ComponentModel.DataAnnotations;

namespace TestProject.Models.Enums
{
    public enum StockLevel
    {
        [Display (Name = "Полно")]
        Full,
        [Display (Name = "Средне")]
        Medium,
        [Display (Name = "Заканчивается")]
        Low,
        [Display (Name = "Закончилось")]
        Empty
    }
}
