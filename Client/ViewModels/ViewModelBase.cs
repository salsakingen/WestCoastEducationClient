using CommunityToolkit.Mvvm.ComponentModel;

namespace WestCoastEducationClient.Client.ViewModels;

public partial class ViewModelBase : ObservableObject
{
    [ObservableProperty]
    public partial string PageTitle { get; set; } = "";
}
