using RPBDISlLab4.ViewModels;

namespace RPBDISlLab4.Services
{
    public interface IInspectionService
    {
        HomeViewModel GetHomeViewModel(int numberRows = 10);

    }
}
