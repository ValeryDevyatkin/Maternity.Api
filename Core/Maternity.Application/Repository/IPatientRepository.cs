using Maternity.Application.Features.Patients;
using Maternity.Application.Repository.Common;
using Maternity.Domain.Model;

namespace Maternity.Application.Repository;

public interface IPatientRepository : IRepositoryBase<Patient>
{
    Task CreateManyAsync(IEnumerable<Patient> items);
    Task<IEnumerable<Patient>> GetManyAsync(PatientFilter filter);
}