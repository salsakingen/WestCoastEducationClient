using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Teachers;

public partial class EditTeacherViewModel(IService<Teacher> _teacherService) : ViewModelBase
{
    private string _teacherId = "";
    [ObservableProperty] public partial string FirstName { get; set; }
    [ObservableProperty] public partial string LastName { get; set; }
    [ObservableProperty] public partial string PersonalNumber { get; set; }
    [ObservableProperty] public partial string KnowledgeArea { get; set; }
    [ObservableProperty] public partial string ResponsibleCourse { get; set; }
    [ObservableProperty] public partial string PhoneNumber { get; set; }
    [ObservableProperty] public partial string Address { get; set; }
    [ObservableProperty] public partial string PostalCode { get; set; }
    [ObservableProperty] public partial string Town { get; set; }

    public async Task Init(string id)
    {
        var teacher = await _teacherService.Get(id);
        
        _teacherId = teacher.Id;
        FirstName = teacher.FirstName;
        LastName = teacher.LastName;
        PersonalNumber = teacher.PersonalNumber;
        KnowledgeArea = teacher.KnowledgeArea;
        ResponsibleCourse = teacher.ResponsibleCourse;
        PhoneNumber = teacher.PhoneNumber;
        Address = teacher.Address;
        PostalCode = teacher.PostalCode;
        Town = teacher.Town;
    }
    
    [RelayCommand]
    private async Task SaveTeacher()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }
        var teacher = new Teacher
        {
            Id = _teacherId,
            FirstName = FirstName,
            LastName = LastName,
            PersonalNumber = PersonalNumber,
            KnowledgeArea = KnowledgeArea,
            ResponsibleCourse = ResponsibleCourse,
            PhoneNumber = PhoneNumber,
            Address = Address,
            PostalCode = PostalCode,
            Town = Town
        };

        await _teacherService.Put(teacher);
   
    }

    
}