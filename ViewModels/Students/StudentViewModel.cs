using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Students;

public partial class StudentViewModel : ViewModelBase
{
    private readonly IService<Models.Student> _studentService;
    


    [ObservableProperty]
    public partial ObservableCollection<Models.Student> Students { get; set; } = [];

    public StudentViewModel(IService<Models.Student> studentService)
    {
        _studentService = studentService;
        Init();
    }
    
    private async Task Init()
    {
        var students = await _studentService.GetAll();
        Students = new ObservableCollection<Student>(students);
    }

    

    [RelayCommand]
    private async Task DeleteStudent(string id) {
        
        await _studentService.Delete(id);
        await Init();
    }

}
