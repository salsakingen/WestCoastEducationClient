using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.Client.ViewModels.Courses;
using WestCoastEducationClient.Client.ViewModels.Student;
using WestCoastEducationClient.Client.ViewModels.Teacher;

namespace WestCoastEducationClient.Client.ViewModels;

public partial class MainViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new();

    [RelayCommand]
    private void GoToHome() => CurrentView = new HomeViewModel();
    [RelayCommand]
    private void GoToStudent() => CurrentView = new StudentViewModel();
    [RelayCommand]
    private void GoToTeacher() => CurrentView = new TeacherViewModel();
    [RelayCommand]
    private void GoToCourses() => CurrentView = new CourseViewModel();


}
