using Maternity.Application.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Maternity.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PatientController : ControllerBase
{
    private readonly ILogger<PatientController> _logger;

    public PatientController(ILogger<PatientController> logger)
    {
        _logger = logger;
    }

    /// <summary>
    /// Get Patients.
    /// </summary>
    [HttpGet(Name = "Get Patients")]
    public async Task<ActionResult<IEnumerable<PatientDto>>> Get()
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Get Patient By Id.
    /// </summary>
    [HttpGet("{id}", Name = "Get Patient By Id")]
    public async Task<ActionResult<PatientDto>> Get(int id)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Create Patient.
    /// </summary>
    [HttpPost(Name = "Create Patient")]
    public async Task<ActionResult<PatientDto>> Create(PatientDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Update Patient.
    /// </summary>
    [HttpPut(Name = "Update Patient")]
    public async Task<ActionResult<PatientDto>> Update(PatientDto dto)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Delete Patient.
    /// </summary>
    [HttpDelete(Name = "Delete Patient")]
    public async Task<ActionResult<PatientDto>> Delete(int id)
    {
        throw new NotImplementedException();
    }
}