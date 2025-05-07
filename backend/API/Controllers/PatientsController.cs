using API.Responses;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers;

public class PatientsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PatientsController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Patient>>> Get()
    {
        try
        {
            var patients = await _unitOfWork.Patients.GetAllAsync();
            return _mapper.Map<List<Patient>>(patients);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.GENERIC_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.GENERIC_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Patient>> Get(int id)
    {
        try
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);

            if (patient is null)
                return NotFound();

            return _mapper.Map<Patient>(patient);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.GENERIC_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.GENERIC_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Patient>> Post(Patient oPatient)
    {
        try
        {
            var patient = _mapper.Map<Patient>(oPatient);
            _unitOfWork.Patients.Add(patient);
            await _unitOfWork.SaveAsync();

            if (patient is null)
                return BadRequest();

            oPatient.Id = patient.Id;

            Log.Information($"Patient {oPatient.Name} added successfully.");

            return Ok(ApiResponseFactory.Success<object>(oPatient, Constants.PATIENT_ADDED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PATIENT_ADDING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PATIENT_ADDING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Patient>> Put([FromBody] Patient oPatient)
    {
        try
        {
            if (oPatient is null)
                return NotFound();

            var patient = _mapper.Map<Patient>(oPatient);
            _unitOfWork.Patients.Update(patient);
            await _unitOfWork.SaveAsync();

            Log.Information($"Patient {oPatient.Name} updated successfully.");

            return Ok(ApiResponseFactory.Success<object>(oPatient, Constants.PATIENT_UPDATED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PATIENT_UPDATING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PATIENT_UPDATING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var patient = await _unitOfWork.Patients.GetByIdAsync(id);

            if (patient is null)
                return NotFound();

            _unitOfWork.Patients.Remove(patient);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponseFactory.Success<object>(patient, Constants.PATIENT_DELETED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PATIENT_DELETING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PATIENT_DELETING_ERROR} Details ${ex.Message}"));
        }
    }
}
