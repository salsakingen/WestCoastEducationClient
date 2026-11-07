using CommunityToolkit.Mvvm.ComponentModel;

namespace WestCoastEducationClient.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle { get; set; } = "";
}
