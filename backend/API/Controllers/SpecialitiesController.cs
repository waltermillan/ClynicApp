using API.Responses;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers;

public class SpecialitiesController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public SpecialitiesController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Speciality>>> Get()
    {
        try
        {
            var specialities = await _unitOfWork.Specialities.GetAllAsync();
            return _mapper.Map<List<Speciality>>(specialities);
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
    public async Task<ActionResult<Speciality>> Get(int id)
    {
        try
        {
            var speciality = await _unitOfWork.Specialities.GetByIdAsync(id);

            if (speciality is null)
                return NotFound();

            return _mapper.Map<Speciality>(speciality);
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
    public async Task<ActionResult<Speciality>> Post(Speciality oSpeciality)
    {
        try
        {
            var speciality = _mapper.Map<Speciality>(oSpeciality);
            _unitOfWork.Specialities.Add(speciality);
            await _unitOfWork.SaveAsync();

            if (speciality is null)
                return BadRequest();

            oSpeciality.Id = speciality.Id;

            Log.Information($"{Constants.SPECIALITY_ADDED_SUCCESSFULLY} Details ${oSpeciality.Id}");

            return Ok(ApiResponseFactory.Success<object>(oSpeciality, Constants.SPECIALITY_ADDED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.SPECIALITY_ADDING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.SPECIALITY_ADDING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Speciality>> Put([FromBody] Speciality oSpeciality)
    {
        try
        {
            if (oSpeciality is null)
                return NotFound();

            var speciality = _mapper.Map<Speciality>(oSpeciality);
            _unitOfWork.Specialities.Update(speciality);
            await _unitOfWork.SaveAsync();

            Log.Information($"{Constants.SPECIALITY_UPDATED_SUCCESSFULLY} Details ${oSpeciality.Id}");

            return Ok(ApiResponseFactory.Success<object>(oSpeciality, Constants.SPECIALITY_UPDATED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.SPECIALITY_UPDATING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.SPECIALITY_UPDATING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var speciality = await _unitOfWork.Specialities.GetByIdAsync(id);

            if (speciality is null)
                return NotFound();

            _unitOfWork.Specialities.Remove(speciality);
            await _unitOfWork.SaveAsync();

            Log.Information($"{Constants.SPECIALITY_DELETED_SUCCESSFULLY} Details ${speciality.Id}");

            return Ok(ApiResponseFactory.Success<object>(speciality, Constants.SPECIALITY_DELETED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.SPECIALITY_DELETING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.SPECIALITY_DELETING_ERROR} Details ${ex.Message}"));
        }
    }
}
