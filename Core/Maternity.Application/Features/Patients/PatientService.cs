using AutoMapper;
using Maternity.Application.Dto;
using Maternity.Application.Repository.Common;
using Maternity.Domain.Model;

namespace Maternity.Application.Features.Patients;

public class PatientService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<PatientDto>> GetManyAsync()
    {
        var models = await _unitOfWork.PatientRepository.GetManyAsync();
        var dtoList = _mapper.Map<IEnumerable<PatientDto>>(models);

        return dtoList;
    }

    public async Task<PatientDto> GetByIdAsync(int id)
    {
        var model = await _unitOfWork.PatientRepository.GetByIdAsync(id);
        var dto = _mapper.Map<PatientDto>(model);

        return dto;
    }

    public async Task<PatientDto> CreateAsync(PatientDto dto)
    {
        var model = _mapper.Map<Patient>(dto);
        var createdModel = await _unitOfWork.PatientRepository.CreateAsync(model);
        var createdDto = _mapper.Map<PatientDto>(createdModel);
        await _unitOfWork.SaveChangesAsync();

        return createdDto;
    }

    public async Task CreateManyAsync(IEnumerable<PatientDto> dtoList)
    {
        var models = _mapper.Map<IEnumerable<Patient>>(dtoList);
        await _unitOfWork.PatientRepository.CreateManyAsync(models);
        await _unitOfWork.SaveChangesAsync();

    }

    public async Task UpdateAsync(PatientDto dto)
    {
        var model = _mapper.Map<Patient>(dto);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var isSuccess = await _unitOfWork.PatientRepository.DeleteAsync(id);

        if (isSuccess)
        {
            await _unitOfWork.SaveChangesAsync();
        }

        return isSuccess;
    }
}