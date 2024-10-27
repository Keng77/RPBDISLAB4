using Microsoft.AspNetCore.Mvc;
using RPBDISlLab4.Services;

namespace RPBDISlLab4.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class InspectionsController : Controller
    {
        private readonly IViewModelService _viewModelService;

        // Конструктор контроллера с внедрением зависимости
        public InspectionsController(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            return View(_viewModelService.GetHomeViewModel(30));
        }
    }
}
