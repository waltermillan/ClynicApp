using API.DTOs;
using API.Responses;
using API.Services;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers;

public class DoctorsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly DoctorService _doctorService;

    public DoctorsController(IUnitOfWork unitOfWork, IMapper mapper, DoctorService doctorService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _doctorService = doctorService;
    }

    [HttpGet("dto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctorsDTO()
    {
        try
        {
            var doctors = await _doctorService.GetAllDoctorsDTOsAsync();
            return _mapper.Map<List<DoctorDTO>>(doctors);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.GENERIC_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.GENERIC_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpGet("dto/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DoctorDTO>> GetByIdDoctorDTO(int id)
    {
        try
        {
            var doctor = await _doctorService.GetByIdDoctorDTOAsync(id);

            if (doctor is null)
                return NotFound();

            return _mapper.Map<DoctorDTO>(doctor);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.GENERIC_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.GENERIC_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Doctor>>> Get()
    {
        try
        {
            var doctors = await _unitOfWork.Doctors.GetAllAsync();
            return _mapper.Map<List<Doctor>>(doctors);
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
    public async Task<ActionResult<Doctor>> Get(int id)
    {
        try
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);

            if (doctor is null)
                return NotFound();

            return _mapper.Map<Doctor>(doctor);
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
    public async Task<ActionResult<Doctor>> Post(Doctor oDoctor)
    {
        try
        {
            var doctor = _mapper.Map<Doctor>(oDoctor);
            _unitOfWork.Doctors.Add(doctor);
            await _unitOfWork.SaveAsync();

            if (doctor is null)
                return BadRequest();

            oDoctor.Id = doctor.Id;

            Log.Information($"{Constants.DOCTOR_ADDED_SUCCESSFULLY} Details ${oDoctor.Id} ${oDoctor.Name} ${oDoctor.IdSpeciality} ${oDoctor.DateOfBirth}");

            return Ok(ApiResponseFactory.Success<object>(oDoctor, Constants.DOCTOR_ADDED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.DOCTOR_ADDING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.DOCTOR_ADDING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Doctor>> Put([FromBody] Doctor oDoctor)
    {
        try
        {
            if (oDoctor is null)
                return NotFound();

            var doctor = _mapper.Map<Doctor>(oDoctor);
            _unitOfWork.Doctors.Update(doctor);
            await _unitOfWork.SaveAsync();

            Log.Information($"{Constants.DOCTOR_UPDATED_SUCCESSFULLY} Details ${oDoctor.Id} ${oDoctor.Name} ${oDoctor.IdSpeciality} ${oDoctor.DateOfBirth}");

            return Ok(ApiResponseFactory.Success<object>(oDoctor, Constants.DOCTOR_UPDATED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.DOCTOR_UPDATING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.DOCTOR_UPDATING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var doctor = await _unitOfWork.Doctors.GetByIdAsync(id);

            if (doctor is null)
                return NotFound();

            _unitOfWork.Doctors.Remove(doctor);
            await _unitOfWork.SaveAsync();

            Log.Information($"{Constants.DOCTOR_DELETED_SUCCESSFULLY} Details ${id}");

            return Ok(ApiResponseFactory.Success<object>(id, Constants.DOCTOR_DELETED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.DOCTOR_DELETING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.DOCTOR_DELETING_ERROR} Details ${ex.Message}"));
        }
    }
}
