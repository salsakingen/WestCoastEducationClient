using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using WestCoastEducationClient.InterFace;

namespace WestCoastEducationClient.ViewModels.Students;

public partial class AddStudentViewModel(IService<Models.Student> _studentService) : ViewModelBase 
{
    [ObservableProperty] public partial string FirstName { get; set; }
    [ObservableProperty] public partial string LastName { get; set; }
    [ObservableProperty] public partial string PersonalNumber { get; set; }
    [ObservableProperty] public partial string PhoneNumber { get; set; }
    [ObservableProperty] public partial string Address { get; set; }
    [ObservableProperty] public partial string PostalCode { get; set; }
    [ObservableProperty] public partial string Town { get; set; }
    
    [RelayCommand]
    private async Task AddStudent()
    {
        if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
        {
            return;
        }
        var student = new Models.Student
        {
            FirstName = FirstName,
            LastName = LastName,
            PersonalNumber = PersonalNumber,
            PhoneNumber = PhoneNumber,
            Address = Address,
            PostalCode = PostalCode,
            Town = Town
        };

        await _studentService.Post(student);
        ClearFields();

    }

    void ClearFields()
    {
        FirstName = "";
        LastName = "";
        PersonalNumber = "";
        PhoneNumber = "";
        Address = "";
        PostalCode = "";
        Town = "";
        
    }
}
