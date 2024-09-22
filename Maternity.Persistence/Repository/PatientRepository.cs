using Maternity.Application.Repository;
using Maternity.Domain.Model;
using Maternity.Persistence.Context;
using Maternity.Persistence.Repository.Common;

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
}