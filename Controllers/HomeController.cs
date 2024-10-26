using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using RPBDISlLab4.Data;
using RPBDISlLab4.Models;
using RPBDISlLab4.Services;
using RPBDISlLab4.ViewModels;
using System.Diagnostics;
using System.Threading.Tasks;

namespace RPBDISlLab4.Controllers
{

    public class HomeController : Controller
    {
        private readonly IInspectionService _InspectionService;

        public HomeController(IInspectionService inspectionService)
        {
            _InspectionService = inspectionService;
        }


        public IActionResult Index()
        {

            //int numberRows = 10;
            //List<Enterprise> enterprises = [.. _db.Enterprises.Take(numberRows)];
            //List<Inspector> inspectors = [.. _db.Inspectors.Take(numberRows)];
            //List<ViolationType> violationTypes = [.. _db.ViolationTypes.Take(numberRows)];
            //List<InspectionViewModel> inspection = [.. _db.Inspections
            //    .OrderByDescending(d => d.InspectionDate)
            //    .Select(t => new InspectionViewModel { OperationID = t.OperationID, FuelType = t.Fuel.FuelType, TankType = t.Tank.TankType, Inc_Exp = t.Inc_Exp, Date = t.Date })
            //    .Take(numberRows)];

            //HomeViewModel homeViewModel = new() { Enterprises = enterprises, FInspectors = inspectors, ViolationTypes= violationTypes, Inspections = inspection };


            return View(_InspectionService.GetHomeViewModel(10));
        }
    }
}
