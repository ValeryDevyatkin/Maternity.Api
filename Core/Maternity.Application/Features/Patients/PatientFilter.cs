namespace Maternity.Application.Features.Patients;

public record PatientFilter(string? DateFilter)
{
    public bool IsEqual => DateFilter?.StartsWith("eq") ?? false;
    public bool IsNotEqual => DateFilter?.StartsWith("ne") ?? false;
    public bool IsLessOrEqualThan => DateFilter?.StartsWith("le") ?? false;
    public bool IsGreaterOrEqualThan => DateFilter?.StartsWith("ge") ?? false;

    public DateTime? GetDateFilterValue()
    {
        if (DateFilter == null)
        {
            return null;
        }

        if (DateTime.TryParse(DateFilter.Substring(2, DateFilter.Length - 2), out var filterValue))
        {
            return filterValue;
        }

        return null;
    }
}