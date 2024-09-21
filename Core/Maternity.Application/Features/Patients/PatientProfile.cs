using AutoMapper;
using Maternity.Application.Dto;
using Maternity.Domain.Model;

namespace Maternity.Application.Features.Patients;

public class PatientProfile : Profile
{
    public PatientProfile()
    {
        CreateMap<Patient, PatientDto>().ReverseMap();
    }
}