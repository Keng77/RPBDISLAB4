using Microsoft.AspNetCore.Mvc;
using RPBDISlLab4.Services;

namespace RPBDISlLab4.Controllers
{
    [ResponseCache(CacheProfileName = "Default")]
    public class Enterprises : Controller
    {
        private readonly IViewModelService _viewModelService;

        // Конструктор контроллера с внедрением зависимости
        public Enterprises(IViewModelService viewModelService)
        {
            _viewModelService = viewModelService;
        }

        public IActionResult Index()
        {
            return View(_viewModelService.GetHomeViewModel(30));
        }

    }
}
