using Maternity.Application.Dto;
using Maternity.Application.Features.Patients;
using Microsoft.AspNetCore.Mvc;

namespace Maternity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientsController : ControllerBase
{
    private readonly ILogger<PatientsController> _logger;
    private readonly PatientService _patinetService;

    public PatientsController(
        ILogger<PatientsController> logger,
        PatientService patinetService)
    {
        _logger = logger;
        _patinetService = patinetService;
    }

    /// <summary>
    /// Get Patients.
    /// </summary>
    [HttpGet(Name = "Get Patients")]
    public async Task<ActionResult<IEnumerable<PatientDto>>> Get()
    {
        try
        {
            var patients = await _patinetService.GetManyAsync();

            return Ok(patients);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    /// <summary>
    /// Get Patient By Id.
    /// </summary>
    [HttpGet("{id}", Name = "Get Patient By Id")]
    public async Task<ActionResult<PatientDto>> Get(int id)
    {
        try
        {
            var patient = await _patinetService.GetByIdAsync(id);

            if (patient == null)
            {
                return NotFound(id);
            }

            return Ok(patient);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    /// <summary>
    /// Create Patient.
    /// </summary>
    [HttpPost(Name = "Create Patient")]
    public async Task<ActionResult<PatientDto>> Create(PatientDto dto)
    {
        try
        {
            var patient = await _patinetService.CreateAsync(dto);

            return Ok(patient);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    /// <summary>
    /// Create Many Patients.
    /// </summary>
    [HttpPost("bulk", Name = "Create Many Patients.")]
    public async Task<ActionResult> CreateMany(IEnumerable<PatientDto> dtoList)
    {
        try
        {
            await _patinetService.CreateManyAsync(dtoList);

            return Ok();
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    /// <summary>
    /// Update Patient.
    /// </summary>
    [HttpPut(Name = "Update Patient")]
    public async Task<ActionResult> Update(PatientDto dto)
    {
        try
        {
            await _patinetService.UpdateAsync(dto);

            return Ok();
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    /// <summary>
    /// Delete Patient.
    /// </summary>
    [HttpDelete(Name = "Delete Patient")]
    public async Task<ActionResult<PatientDto>> Delete(int id)
    {
        try
        {
            var isSuccess = await _patinetService.DeleteAsync(id);

            if (isSuccess)
            {
                return Ok();
            }

            return NotFound(id);
        }
        catch (Exception ex)
        {
            return LogErrorAndReturnResult(ex);
        }
    }

    private ActionResult LogErrorAndReturnResult(Exception ex)
    {
        _logger.LogError(ex, ex.Message);

        return BadRequest(ex.Message);
    }
}