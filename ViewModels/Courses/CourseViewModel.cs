using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;
using WestCoastEducationClient.Service;

namespace WestCoastEducationClient.ViewModels;

public partial class CourseViewModel : ViewModelBase
{
    [ObservableProperty]
    public partial string CourseName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string DurationDays { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string StartDate { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string EndDate { get; set; } = string.Empty;

    private readonly CourseService _courseService;
    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    public CourseViewModel(CourseService courseService)
    {
        _courseService = courseService;
        Init();
    }


    [RelayCommand]
    private async Task Delete(string id)
    {
        await _courseService.Delete(id);
        await LoadCourses();
    }
    private async Task LoadCourses()
    {
        var courses = await _courseService.GetAll();
        Courses = new ObservableCollection<Course>(courses);
    }

    private async void Init()
    {
        await LoadCourses();
    }
}
