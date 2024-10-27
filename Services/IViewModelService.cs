using RPBDISlLab4.ViewModels;

namespace RPBDISlLab4.Services
{
    public interface IViewModelService
    {
        HomeViewModel GetHomeViewModel(int numberRows = 10);

    }
}
