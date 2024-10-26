using Microsoft.EntityFrameworkCore;
using RPBDISlLab4.Models;

namespace RPBDISlLab4.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Enterprise> Enterprises { get; set; }

        public IEnumerable<Inspection> Inspections { get; set; }

        public IEnumerable<Inspector> Inspectors { get; set; }

        public IEnumerable<ViolationType> ViolationTypes { get; set; }
    }
}
