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

public class AppointmentsController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly AppointmentService _turnService;

    public AppointmentsController(IUnitOfWork unitOfWork, IMapper mapper, AppointmentService turnService)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _turnService = turnService;
    }

    [HttpGet("dto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AppointmentDTO>>> GetAllTurnsDTO()
    {
        try
        {
            var turns = await _turnService.GetAllAppointmentDTOsAsync();
            return _mapper.Map<List<AppointmentDTO>>(turns);
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
    public async Task<ActionResult<AppointmentDTO>> GetByIdTurnsDTO(int id)
    {
        try
        {
            var turn = await _turnService.GetByIdAppointmentDTOsAsync(id);

            if (turn is null)
                return NotFound();

            return _mapper.Map<AppointmentDTO>(turn);
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
    public async Task<ActionResult<IEnumerable<Appointment>>> Get()
    {
        try
        {
            var turns = await _unitOfWork.Appointments.GetAllAsync();
            return _mapper.Map<List<Appointment>>(turns);
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
    public async Task<ActionResult<Appointment>> Get(int id)
    {
        try
        {
            var turn = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (turn is null)
                return NotFound();

            return _mapper.Map<Appointment>(turn);
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
    public async Task<ActionResult<Appointment>> Post(Appointment oTurn)
    {
        try
        {
            var turn = _mapper.Map<Appointment>(oTurn);
            _unitOfWork.Appointments.Add(turn);
            await _unitOfWork.SaveAsync();

            if (turn is null)
                return BadRequest();

            oTurn.Id = turn.Id;

            Log.Information($"Turn {oTurn.Id} added successfully");

            return Ok(ApiResponseFactory.Success<object>(oTurn, Constants.APPOINTMENT_ADDED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.APPOINTMENT_ADDING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.APPOINTMENT_ADDING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Appointment>> Put([FromBody] Appointment oTurn)
    {
        try
        {
            if (oTurn is null)
                return NotFound();

            var turn = _mapper.Map<Appointment>(oTurn);
            _unitOfWork.Appointments.Update(turn);
            await _unitOfWork.SaveAsync();

            Log.Information($"Turn {oTurn.Id} updated successfully");

            return Ok(ApiResponseFactory.Success<object>(oTurn, Constants.APPOINTMENT_UPDATED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.APPOINTMENT_UPDATING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.APPOINTMENT_UPDATING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var turn = await _unitOfWork.Appointments.GetByIdAsync(id);

            if (turn is null)
                return NotFound();

            _unitOfWork.Appointments.Remove(turn);
            await _unitOfWork.SaveAsync();

            Log.Information($"Turn {turn.Id} deleted successfully");

            return Ok(ApiResponseFactory.Success<object>(turn, Constants.APPOINTMENT_DELETED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.APPOINTMENT_DELETING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.APPOINTMENT_DELETING_ERROR} Details ${ex.Message}"));
        }
    }
}
