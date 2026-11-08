using System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace WestCoastEducationClient.Models;

public class Teacher : Person
{
    public required string KnowledgeArea { get; set; }
    public required string ResponsibleCourse { get; set; }
}


