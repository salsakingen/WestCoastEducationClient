using System;

namespace WestCoastEducation2.Models;

public class EducationLeader : Teacher
{
  public DateTime EmploymentDate { get; set; }


    public EducationLeader(
        string firstName,
        string lastName,
        string phone,
        string personalNumber,
        string address,
        string postalCode,
        string city,
        string knowledgeArea,
        DateTime employmentDate)

    : base(firstName, lastName, phone, personalNumber, address, postalCode, city, knowledgeArea)
    {
       EmploymentDate = employmentDate;
    }
    public override string GetInfo()
    {
        return base.GetInfo() + $", Employed: {EmploymentDate:yyyy-mm-dd}";
    }
}
