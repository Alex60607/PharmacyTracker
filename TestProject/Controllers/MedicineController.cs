using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using TestProject.Data;
using TestProject.Models;
using TestProject.Models.Enums;
using TestProject.ViewModels;

namespace TestProject.Controllers
{
    [Authorize]
    public class MedicineController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public MedicineController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index(string? search)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            }

            var viewModel = await BuildMedicineListViewModel(userId, search);

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CreateMedicineViewModel model)
        {
            if (!ModelState.IsValid)
            {
                var userId = _userManager.GetUserId(User);

                if (userId == null)
                {
                    return Unauthorized();
                }

                var viewModel = await BuildMedicineListViewModel(
                    userId,
                    createMedicine: model
                );

                viewModel.OpenCreateMedicineModal = true;

                return View("Index", viewModel);
            }

            var currentUserId = _userManager.GetUserId(User);
            if (currentUserId == null)
            {
                return Unauthorized();
            }

            var medicine = new Medicine
            {
                Name = model.Name,
                Type = model.Type,
                Dosage = model.Dosage,
                Purpose = model.Purpose,
                CurrentStockLevel = model.CurrentStockLevel,
                ExpirationDate = GetExpirationDate(
                    model.ExpirationYear!.Value,
                    model.ExpirationMonth!.Value
                ),
                RequiresPrescription = model.RequiresPrescription,
                UserId = currentUserId
            };

            _context.Medicines.Add(medicine);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditMedicineViewModel model)
        {
            var userId = _userManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            }

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.Id == model.MedicineId && m.UserId == userId);

            if (medicine == null)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var viewModel = await BuildMedicineListViewModel(
                    userId,
                    editMedicineId: model.MedicineId,
                    editMedicine: model
                );

                return View("Index", viewModel);
            }

            medicine.Name = model.Name;
            medicine.Type = model.Type;
            medicine.Dosage = model.Dosage;
            medicine.Purpose = model.Purpose;
            medicine.CurrentStockLevel = model.CurrentStockLevel;
            medicine.ExpirationDate = GetExpirationDate(
                model.ExpirationYear!.Value,
                model.ExpirationMonth!.Value
            );
            medicine.RequiresPrescription = model.RequiresPrescription;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = _userManager.GetUserId(User);

            var medicine = await _context.Medicines
                .FirstOrDefaultAsync(m => m.Id == id && m.UserId == userId);

            if (medicine == null)
            {
                return NotFound();
            }

            _context.Medicines.Remove(medicine);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        private async Task<MedicineListViewModel> BuildMedicineListViewModel(string userId, string? search = null, CreateMedicineViewModel? createMedicine = null, int? editMedicineId = null, EditMedicineViewModel? editMedicine = null)
        {
            var query = _context.Medicines
                .Where(m => m.UserId == userId);

            if (!string.IsNullOrWhiteSpace(search))
            {
                query = query.Where(m => EF.Functions.ILike(m.Name, $"%{search}%") || EF.Functions.ILike(m.Purpose, $"%{search}%"));
            }

            var allMedicines = await query
                .Include(m => m.Prescriptions)
                .OrderBy(m => m.Name)
                .ToListAsync();

            var today = DateTime.Today;
            var expirationThreshold = today.AddDays(30);

            return new MedicineListViewModel
            {
                AllMedicines = allMedicines,

                ExpiringSoon = allMedicines
                    .Where(m => m.ExpirationDate.Date <= expirationThreshold)
                    .ToList(),

                RunningOut = allMedicines
                    .Where(m => m.CurrentStockLevel == StockLevel.Low ||
                        m.CurrentStockLevel == StockLevel.Empty)
                    .ToList(),

                SearchQuery = search,
                CreateMedicine = createMedicine ?? new CreateMedicineViewModel(),
                EditMedicineId = editMedicineId,
                EditMedicine = editMedicine
            };
        }
        private static DateTime GetExpirationDate(int year, int month)
        {
            var lastDayOfMonth = DateTime.DaysInMonth(year, month);

            return new DateTime(
                year,
                month,
                lastDayOfMonth,
                0, 0, 0,
                DateTimeKind.Utc
            );
        }
    }
}
