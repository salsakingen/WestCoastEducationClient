using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Courses;

public partial class CourseViewModel : ViewModelBase
{

    private readonly IService<Course> _courseService;
    
    [ObservableProperty]
    public partial ObservableCollection<Course> Courses { get; set; } = [];

    public CourseViewModel(IService<Course> courseService)
    {
        _courseService = courseService;
        Init();
    }
    

    private async Task Init()
    {
        var courses = await _courseService.GetAll();
        Courses = new ObservableCollection<Course>(courses);
    }
    [RelayCommand]
    private async Task Delete(string id)
    {
        await _courseService.Delete(id);
        await Init();
    }
}
