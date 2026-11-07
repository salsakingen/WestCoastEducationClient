using System;
using System.Collections.Generic;
using System.Security.Cryptography;


namespace WestCoastEducationClient.Models;

public record Teacher
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalNumber { get; set; }
    public required string KnowledgeArea { get; set; }
}


