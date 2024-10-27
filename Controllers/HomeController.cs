using Microsoft.AspNetCore.Mvc;
using RPBDISlLab4.Services;

namespace RPBDISlLab4.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class HomeController : Controller
    {
        private readonly IViewModelService _inspectionService;

        // Конструктор контроллера с внедрением зависимости
        public HomeController(IViewModelService inspectionService)
        {
            _inspectionService = inspectionService;
        }

        public IActionResult Index()
        {
            return View(_inspectionService.GetHomeViewModel(10));
        }
    }

}
