using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Courses;

public partial class EditCourseViewModel(IService<Course> _courseService) : ViewModelBase
{
    private string _id = "";
    [ObservableProperty] public partial string CourseNumber { get; set; }
    [ObservableProperty] public partial string Title { get; set; }

    [ObservableProperty] public partial DateTimeOffset StartDate { get; set; } = DateTimeOffset.Now;

    [ObservableProperty] public partial DateTimeOffset EndDate { get; set; } = DateTimeOffset.Now;

    public async Task Init(string id)
    {
        var course = await _courseService.Get(id);
        
        _id = course.Id;
        CourseNumber = course.CourseNumber!;
        Title = course.Title!;
        StartDate = DateTimeOffset.Parse(course.StartDate.ToShortDateString());
        EndDate = DateTimeOffset.Now;
    }
    
    [RelayCommand]
    private async Task UpdateCourse()
    {
        if (string.IsNullOrWhiteSpace(Title) || string.IsNullOrWhiteSpace(CourseNumber))
        {
            return;
        }
        var course = new Course()
        {
            Id = _id,
            CourseNumber = CourseNumber,
            Title = Title,
            StartDate = StartDate.DateTime,
            EndDate = EndDate.DateTime
        };
        await _courseService.Put(course);
    

    }

    
}