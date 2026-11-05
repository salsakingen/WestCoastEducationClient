using System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace WestCoastEducationClient.Client.Models;

public class Teacher 
{
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalNumber { get; set; }
    public required string? KnowledgeArea { get; set; }
    public string? Phone { get; set; }
    public string? Address { get; set; }
    public string? PostalCode { get; set; }
    public string? City { get; set; }
}

