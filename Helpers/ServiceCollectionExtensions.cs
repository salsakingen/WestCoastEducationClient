using System;
using Client.Enums;
using Client.Factories;
using Client.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using WestCoastEducationClient.InterFace;
using WestCoastEducationClient.Models;
using WestCoastEducationClient.Service;
using WestCoastEducationClient.ViewModels;
using WestCoastEducationClient.ViewModels.Courses;
using AddCourseViewModel = WestCoastEducationClient.ViewModels.Courses.AddCourseViewModel;
using AddStudentViewModel = WestCoastEducationClient.ViewModels.Students.AddStudentViewModel;
using AddTeacherViewModel = WestCoastEducationClient.ViewModels.Teachers.AddTeacherViewModel;
using CourseViewModel = WestCoastEducationClient.ViewModels.Courses.CourseViewModel;
using EditTeacherViewModel = WestCoastEducationClient.ViewModels.Teachers.EditTeacherViewModel;
using StudentViewModel = WestCoastEducationClient.ViewModels.Students.StudentViewModel;
using TeacherViewModel = WestCoastEducationClient.ViewModels.Teachers.TeacherViewModel;

namespace Client.Helpers;

public static class ServiceCollectionExtensions
{
    public static void AddServices(this IServiceCollection collection)
    {
      
        collection.AddSingleton<PageViewFactory>();
        collection.AddSingleton<MainViewModel>();
        collection.AddTransient<HomeViewModel>();
        collection.AddTransient<TeacherViewModel>();
        collection.AddTransient<CourseViewModel>();
        collection.AddTransient<StudentViewModel>();
        collection.AddTransient<AddTeacherViewModel>();
        collection.AddTransient<AddCourseViewModel>();
        collection.AddTransient<AddStudentViewModel>();
        collection.AddTransient<EditTeacherViewModel>();
        collection.AddTransient<EditCourseViewModel>();

        collection.AddSingleton<IService<Course>,CourseService>();
        collection.AddSingleton<IService<Teacher>,TeacherService>();
        collection.AddSingleton<IService<Student>,StudentService>();
        
        collection.AddSingleton<IPageViewFactory, PageViewFactory>();
        
        
        
        
        
        collection.AddSingleton<Func<PageViewsEnum, ViewModelBase>>(c => name => name switch
        {
            PageViewsEnum.Home => c.GetRequiredService<HomeViewModel>(),
            PageViewsEnum.Students => c.GetRequiredService<StudentViewModel>(),
            PageViewsEnum.Teachers => c.GetRequiredService<TeacherViewModel>(),
            PageViewsEnum.Courses => c.GetRequiredService<CourseViewModel>(),
            PageViewsEnum.AddTeacher => c.GetRequiredService<AddTeacherViewModel>(),
            PageViewsEnum.AddCourse => c.GetRequiredService<AddCourseViewModel>(),
            PageViewsEnum.AddStudent => c.GetRequiredService<AddStudentViewModel>(),
            PageViewsEnum.EditTeacher => c.GetRequiredService<EditTeacherViewModel>(),
            PageViewsEnum.EditCourse => c.GetRequiredService<EditCourseViewModel>(),
            
            _ => throw new InvalidOperationException("Sidan som du försöker nå finns inte.")
        });
    
    }
}
