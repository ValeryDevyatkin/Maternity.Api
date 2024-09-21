using Maternity.Domain.Model;
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

    [HttpGet(Name = "GetPatients")]
    public async Task<IEnumerable<Patient>> Get()
    {
    }

    [HttpGet(template: "/{id}", Name = "GetPatientById")]
    public async Task<Patient> Get(int id)
    {
    }
}