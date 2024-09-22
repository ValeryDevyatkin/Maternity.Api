using Maternity.Application.Repository;
using Maternity.Application.Repository.Common;
using Maternity.Persistence.Context;

namespace Maternity.Persistence.Repository.Common;

public class UnitOfWork : IUnitOfWork
{
    private readonly MaternityDbContext _context;

    public UnitOfWork(
        MaternityDbContext context,
        IPatientRepository patientRepository)
    {
        _context = context;

        PatientRepository = patientRepository;
    }

    public IPatientRepository PatientRepository { get; }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}