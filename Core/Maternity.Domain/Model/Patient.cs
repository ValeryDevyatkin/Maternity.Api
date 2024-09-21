using Maternity.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace Maternity.Domain.Model;

public class Patient : ModelBase
{
    [Required]
    public string? FamilyName { get; set; }

    [Required]
    public string[]? Name { get; set; }

    [Required]
    public DateTime BirthDate { get; set; }

    public string? Gender { get; set; }

    public bool? Active { get; set; }
}