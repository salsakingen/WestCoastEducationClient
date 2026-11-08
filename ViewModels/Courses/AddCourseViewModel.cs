using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Courses;

public partial class AddCourseViewModel(IService<Course> _courseService): ViewModelBase
{
    [ObservableProperty] public partial string CourseNumber { get; set; }
    [ObservableProperty] public partial string Title { get; set; }

    [ObservableProperty] public partial DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;

    [ObservableProperty] public partial DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;

    [RelayCommand]
    private async Task AddCourse()
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(CourseNumber))
        {
            return;
        }
        var course = new Course()
        {
            CourseNumber = CourseNumber,
            Title = Title,
            StartDate = StartDate.DateTime,
            EndDate = EndDate.DateTime
        };
        await _courseService.Post(course);
        ClearFields();

    }

    void ClearFields()
    {
        CourseNumber = "";
        Title = "";
        StartDate = DateTimeOffset.Now;
        EndDate = DateTimeOffset.Now;
    }
}
