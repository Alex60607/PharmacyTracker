using Microsoft.AspNetCore.Identity;

namespace TestProject.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<Medicine> Medicines { get; set; } = new();
    }
}
