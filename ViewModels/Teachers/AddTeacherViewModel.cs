using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;

namespace WestCoastEducationClient.ViewModels.Teachers;

public partial class AddTeacherViewModel(IService<Teacher> _teacherservice) : ViewModelBase
{
    [ObservableProperty] public partial string FirstName { get; set; }
    [ObservableProperty] public partial string LastName { get; set; }
    [ObservableProperty] public partial string PersonalNumber { get; set; }
    [ObservableProperty] public partial string KnowledgeArea { get; set; }
    [ObservableProperty] public partial string ResponsibleCourse { get; set; }
    [ObservableProperty] public partial string PhoneNumber { get; set; }
    [ObservableProperty] public partial string Address { get; set; }
    [ObservableProperty] public partial string PostalCode { get; set; }
    [ObservableProperty] public partial string Town { get; set; }




    [RelayCommand]
    private async Task AddTeacher()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }
        var teacher = new Teacher
        {
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

        await _teacherservice.Post(teacher);
        ClearFields();

    }

    void ClearFields()
    {
        FirstName = "";
        LastName = "";
        PersonalNumber = "";
        KnowledgeArea = "";
        ResponsibleCourse = "";
        PhoneNumber = "";
        Address = "";
        PostalCode = "";
        Town = "";
        
    }
    
}
