using Client.Enums;
using WestCoastEducationClient.ViewModels;

namespace Client.Interfaces;

public interface IPageViewFactory
{
    ViewModelBase LoadPageViewModel(PageViewsEnum page);
}
