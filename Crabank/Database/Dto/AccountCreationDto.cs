using System.ComponentModel.DataAnnotations;
using Crabank.Database.Models;

namespace Crabank.Database.Dto;

public class AccountCreationDto
{
    [Required]
    public string Name { get; set; }
    [Required]
    public string OwnerName { get; set; }
    public double? CreditLimit { get; set; }
    public string? Currency { get; set; }
    public int? AdvisorId { get; set; }
    public string? Type { get; set; }
}