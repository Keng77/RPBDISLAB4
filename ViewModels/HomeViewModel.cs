using Microsoft.EntityFrameworkCore;
using RPBDISlLab4.Models;
using RPBDISlLab4.ViewModels;

namespace RPBDISlLab4.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Enterprise> Enterprises { get; set; }

        public IEnumerable<Inspector> Inspectors { get; set; }

        public IEnumerable<ViolationType> ViolationTypes { get; set; }

        public IEnumerable<InspectionViewModel> Inspections { get; set; }
    }
}
