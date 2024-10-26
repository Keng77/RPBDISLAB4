using RPBDISlLab4.ViewModels;
using RPBDISlLab4.Data;
using RPBDISlLab4.Models;

namespace RPBDISlLab4.Services
{
    // Класс выборки 10 записей из всех таблиц 
    public class InspectionService(InspectionsDbContext context) : IInspectionService
    {
        private readonly InspectionsDbContext _context = context;

        public HomeViewModel GetHomeViewModel(int numberRows = 10)
        {
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
            return homeViewModel;
        }
    }
}
