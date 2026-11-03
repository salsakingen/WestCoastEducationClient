using System;

namespace WestCoastEducationClient.Client.Models;

public class Admin : EducationLeader
{
    public Admin(
            string firstName,
            string lastName,
            string phone,
            string personalNumber,
            string address,
            string postalCode,
            string city,
            string knowledgeArea,
            DateTime employmentDate)

        : base(firstName, lastName, phone, personalNumber, address, postalCode, city, knowledgeArea, employmentDate)
    { }

}
