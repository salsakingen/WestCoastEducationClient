using System.Threading.Tasks;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Service;
using WestCoastEducationClient.ViewModels.Courses;
using WestCoastEducationClient.ViewModels.Teachers;

namespace WestCoastEducationClient.ViewModels;

public partial class MainViewModel(IPageViewFactory factory) : ViewModelBase
{
    private readonly IPageViewFactory _pageViewFactory = factory;
    [ObservableProperty]
    public partial ViewModelBase CurrentView { get; set; } = new HomeViewModel();

    [RelayCommand]
    private void GoToHome() => CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.Home);
    [RelayCommand]
    private void GoToStudent() => CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.Students);
    [RelayCommand]
    private void GoToTeacher() => CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.Teachers);
    [RelayCommand]
    private void GoToCourses() => CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.Courses);
    [RelayCommand]
    private void GoToAddTeacher() =>  CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.AddTeacher);
    
    [RelayCommand]
    private void GoToAddStudent() =>  CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.AddStudent);
    
    [RelayCommand]
    private void GoToAddCourse() =>   CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.AddCourse);


    [RelayCommand]
    private async Task GoToEditTeacher(string id)
    {
        CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.EditTeacher);
        await (CurrentView as EditTeacherViewModel)!.Init(id);
    }

    [RelayCommand]
    private async Task GoToEditCourse(string id)
    {
        CurrentView = _pageViewFactory.LoadPageViewModel(PageViewsEnum.EditCourse);
        await (CurrentView as EditCourseViewModel)!.Init(id);
    }
    
    


}
