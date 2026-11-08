using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Teachers;

public partial class TeacherViewModel : ViewModelBase
{

    private readonly IService<Teacher> _teacherService;


    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    
    public TeacherViewModel(IService<Teacher> teacherService)
    {
        _teacherService = teacherService;
        Task.Run(Init);
    }
    

    private async Task Init()
    {
        var teachers = await _teacherService.GetAll();
        Teachers = new ObservableCollection<Teacher>(teachers);
    }

    [RelayCommand]
    private async Task DeleteTeacher(string id) {
        await _teacherService.Delete(id);
        await Init();
    }

}
