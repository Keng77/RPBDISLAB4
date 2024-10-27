using Microsoft.AspNetCore.Mvc;
using RPBDISlLab4.ViewModels;
using RPBDISlLab4.Data;
using RPBDISlLab4.Filters;
using System.Threading.Tasks;

namespace RPBDISlLab4.Controllers
{
    public class CachedController(InspectionsDbContext context) : Controller
    {
        private readonly InspectionsDbContext _context = context;

        // Кэширование с использования фильтра ресурсов
        [TypeFilter(typeof(CacheResourceFilterAttribute))]
        public IActionResult Index()
        {
            int numberRows = 10;
            var enterprises = _context.Enterprises.Take(numberRows).ToList();
            var inspectors = _context.Inspectors.Take(numberRows).ToList();
            var violationTypes = _context.ViolationTypes.Take(numberRows).ToList();
            List<InspectionViewModel> inspections = [.. _context.Inspections
                .OrderBy(d => d.InspectionId)
                .Select(t => new InspectionViewModel
                {
                    InspectionId = t.InspectionId,
                    Enterprise = t.Enterprise.Name,
                    InspectionDate = t.InspectionDate,
                    ProtocolNumber = t.ProtocolNumber,
                    ViolationType = t.ViolationType.Name,
                    ResponsiblePerson = t.Enterprise.DirectorName,
                    PenaltyAmount = t.ViolationType.PenaltyAmount,
                    PaymentDeadline = t.PaymentDeadline,
                    CorrectionDeadline = t.CorrectionDeadline,
                    PaymentStatus = t.PaymentStatus,
                    CorrectionStatus = t.CorrectionStatus,
                })
                .Take(numberRows)];

            HomeViewModel homeViewModel = new()
            {
                Enterprises = enterprises,
                Inspectors = inspectors,
                ViolationTypes = violationTypes,
                Inspections = inspections
            };
            return View("~/Views/Home/Index.cshtml", homeViewModel);
        }
    }
}
