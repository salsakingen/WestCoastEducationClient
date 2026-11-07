using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Service;

namespace WestCoastEducationClient.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new HomeViewModel();

    [RelayCommand]
    private void GoToHome() => CurrentView = new HomeViewModel();
    [RelayCommand]
    private void GoToStudent() => CurrentView = new StudentViewModel(new StudentService());
    [RelayCommand]
    private void GoToTeacher() => CurrentView = new TeacherViewModel(new TeacherService());
    [RelayCommand]
    private void GoToCourses() => CurrentView = new CourseViewModel(new CourseService());


}
