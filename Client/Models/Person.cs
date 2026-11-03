

using WestCoastEducation2.InterFaces;

namespace WestCoastEducation2.Models;

public abstract class Person : IDisplayable
{
public string FirstName {get; set;}
public string LastName {get; set;}
public string Phone {get; set;}
public string PersonalNumber {get; set;}
public string Address {get; set;}
public string PostalCode {get; set;}
public string City {get; set;}

protected Person (
        string firstName,
        string lastName,
        string phone,
        string personalNumber,
        string address,
        string postalCode,
        string city
    )
    {
        FirstName=firstName;
        LastName=lastName;
        Phone=phone;
        PersonalNumber=personalNumber;
        Address=address;
        PostalCode=postalCode;
        City=city;
    }

    //Gemensam metod för student och teacher så att kontrollen mot dubbletter bara skriv på ett ställe. Retunerar true om kursen lades till. 
    protected static bool AddCourseTo(List<Course> courses, Course coruse)
    {
        foreach (Course existingCourse in courses)
        {
            if (existingCourse.CourseNumber == coruse.CourseNumber)
            {
                Console.WriteLine("Course already exsist!");
                return false;
            }
        }
        //tillägget sker efter loopen. en lista får inte ändras medan man går igenom 
        courses.Add(coruse);
        Console.WriteLine("course added successfully");
        return true;
    }

    public virtual string GetInfo()
    {
        return $"{FirstName} {LastName} Phone: {Phone} Address: {Address} {PostalCode} {City} ";

    }
    public override string ToString() => GetInfo();

}
