using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;
using WestCoastEducationClient.Service;

namespace WestCoastEducationClient.ViewModels;

public partial class StudentViewModel : ViewModelBase
{
    private readonly StudentService _studentService;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PersonalNumber { get; set; } = string.Empty;


    [ObservableProperty]
    public partial ObservableCollection<Student> Students { get; set; } = [];

    public StudentViewModel(StudentService studentService)
    {
        _studentService = studentService;
        Init();
    }
    public StudentViewModel()
    {
        _studentService = new StudentService();
        PageTitle = "";
        Init();
    }
    private async Task LoadStudents()
    {
        var students = await _studentService.GetAll();
        Students = new ObservableCollection<Student>(students);
    }

    private async void Init()
    {
        await LoadStudents();
    }

}
