using System;
using System.Text.Json.Serialization;

namespace WestCoastEducationClient.Models;

public class Person
{
    [JsonPropertyName("_id")]
    public string? Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    
    public required string PhoneNumber { get; set; }
    public required string PersonalNumber { get; set; }
    public required string Address { get; set; }
    public required string PostalCode { get; set; }
    public required string Town { get; set; }
}