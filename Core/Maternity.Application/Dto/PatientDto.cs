using Maternity.Application.Dto.Common;

namespace Maternity.Application.Dto;

public class PatientDto : DtoBase
{
    public string? FamilyName { get; set; }

    public string[]? Name { get; set; }

    public DateTime? BirthDate { get; set; }

    public string? Gender { get; set; }

    public bool? Active { get; set; }
}