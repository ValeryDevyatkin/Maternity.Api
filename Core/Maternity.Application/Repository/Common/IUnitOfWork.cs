namespace Maternity.Application.Repository.Common;

public interface IUnitOfWork
{
    IPatientRepository PatientRepository { get; }

    public Task SaveChangesAsync();
}