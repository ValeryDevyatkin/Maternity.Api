using Maternity.Application.Features.Patients;
using Maternity.Application.Repository;
using Maternity.Domain.Model;
using Maternity.Persistence.Context;
using Maternity.Persistence.Repository.Common;
using Microsoft.EntityFrameworkCore;

namespace Maternity.Persistence.Repository;

public class PatientRepository : RepositoryBase<Patient>, IPatientRepository
{
    public PatientRepository(MaternityDbContext context) : base(context)
    {
    }

    public async Task CreateManyAsync(IEnumerable<Patient> items)
    {
        await Context.Patients.AddRangeAsync(items);
        await Context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Patient>> GetManyAsync(PatientFilter filter)
    {
        var query = Context.Patients.AsNoTracking();
        var dateFilterValue = filter?.GetDateFilterValue();

        if (dateFilterValue != null)
        {
            if (filter.IsEqual)
            {
                query = query.Where(x => x.BirthDate == dateFilterValue);
            }
            else if (filter.IsNotEqual)
            {
                query = query.Where(x => x.BirthDate != dateFilterValue);
            }
            else if (filter.IsGreaterOrEqualThan)
            {
                query = query.Where(x => x.BirthDate >= dateFilterValue);
            }
            else if (filter.IsLessOrEqualThan)
            {
                query = query.Where(x => x.BirthDate <= dateFilterValue);
            }
        }

        return await query.ToListAsync();
    }
}