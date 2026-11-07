using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;
using WestCoastEducationClient.Service;

namespace WestCoastEducationClient.ViewModels;

public partial class TeacherViewModel : ViewModelBase
{

    private readonly TeacherService _teacherService;

    [ObservableProperty]
    public partial string FirstName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string LastName { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string PersonalNumber { get; set; } = string.Empty;

    [ObservableProperty]
    public partial string KnowledgeArea { get; set; } = string.Empty;


    [ObservableProperty]
    public partial ObservableCollection<Teacher> Teachers { get; set; } = [];

    public TeacherViewModel()
    {
        _teacherService = new TeacherService();
        Init();
    }
    public TeacherViewModel(TeacherService teacherService)
    {
        _teacherService = teacherService;
        Init();
    }
    private async Task LoadTeachers()
    {
        var teachers = await _teacherService.GetAll();
        Teachers = new ObservableCollection<Teacher>(teachers);
    }

    private async void Init()
    {
        await LoadTeachers();
    }

}
