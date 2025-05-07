using API.DTOs;
using API.Responses;
using API.Services;
using AutoMapper;
using Core.Constants;
using Core.Entities;
using Core.Interfaces;
using Core.Interfases;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Controllers;

public class StaffController : BaseApiController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly StaffService _personalService;
    private readonly IPasswordHasher _passwordHasher;

    public StaffController(IUnitOfWork unitOfWork, IMapper mapper, StaffService personalService, IPasswordHasher passwordHasher)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _personalService = personalService;
        _passwordHasher = passwordHasher;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<StaffDTO>>> Get()
    {
        try
        {
            var personals = await _personalService.GetAllStaffDTOsAsync();
            return _mapper.Map<List<StaffDTO>>(personals);
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
    public async Task<ActionResult<StaffDTO>> Get(int id)
    {
        try
        {
            var personal = await _personalService.GetByIdStaffDTOAsync(id);

            if (personal is null)
                return NotFound();

            return _mapper.Map<StaffDTO>(personal);
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.GENERIC_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.GENERIC_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPost("login")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Staff>> Post([FromBody] LoginRequest request)
    {
        var userName = request.UserName.ToUpper();
        var password = request.Password;

        try
        {
            var user = await _personalService.GetByNameAsync(userName);

            if (user is null || !_passwordHasher.VerifyPassword(password, user.Password))
            {
                Log.Logger.Information($"{Constants.LOGIN_FAILED}: {userName}");
                return Unauthorized(new { Code = 401, Message = Constants.INVALID_USERNAME_OR_PASSWORD });
            }

            Log.Logger.Information(string.Format(Constants.USER_AUTHENTICATED_MESSAGE_WITH_USER, userName));

            var data = new
            {
                user.Id,
                user.Name,
                user.UserName,
                user.DateofBirth
            };

            return Ok(ApiResponseFactory.Success<object>(data, Constants.USER_AUTHENTICATED_MESSAGE));
        }
        catch (Exception ex)
        {
            Log.Logger.Error(Constants.AUTHENTICATION_ERROR, ex);
            return StatusCode(500, ApiResponseFactory.Fail<object>(string.Format(Constants.AUTHENTICATION_ERROR_WITH_MESSAGE, ex.Message)));
        }
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Staff>> Post(Staff oPersonal)
    {
        try
        {
            var personal = _mapper.Map<Staff>(oPersonal);
            _unitOfWork.Staff.Add(personal);
            await _unitOfWork.SaveAsync();

            if (personal is null)
                return BadRequest();

            oPersonal.Id = personal.Id;
            oPersonal.Password = _passwordHasher.HashPassword(oPersonal.Password);

            Log.Information($"{Constants.PERSONAL_ADDED_SUCCESSFULLY} {oPersonal.Id}");

            return Ok(ApiResponseFactory.Success<object>(oPersonal, Constants.PERSONAL_ADDED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PERSONAL_ADDING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PERSONAL_ADDING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Staff>> Put([FromBody] Staff oPersonal)
    {
        try
        {
            if (oPersonal is null)
                return NotFound();

            oPersonal.Password = _passwordHasher.HashPassword(oPersonal.Password);

            var personal = _mapper.Map<Staff>(oPersonal);
            _unitOfWork.Staff.Update(personal);
            await _unitOfWork.SaveAsync();

            Log.Information($"{Constants.PERSONAL_UPDATED_SUCCESSFULLY} {oPersonal.Id}");

            return Ok(ApiResponseFactory.Success<object>(oPersonal, Constants.PERSONAL_UPDATED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PERSONAL_UPDATING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PERSONAL_UPDATING_ERROR} Details ${ex.Message}"));
        }
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            var personal = await _unitOfWork.Staff.GetByIdAsync(id);

            if (personal is null)
                return NotFound();

            _unitOfWork.Staff.Remove(personal);
            await _unitOfWork.SaveAsync();

            return Ok(ApiResponseFactory.Success<object>(personal, Constants.PERSONAL_DELETED_SUCCESSFULLY));
        }
        catch (Exception ex)
        {
            Log.Error(ex, $"{Constants.PERSONAL_DELETING_ERROR} Details ${ex.Message}");
            return StatusCode(500, ApiResponseFactory.Fail<object>($"{Constants.PERSONAL_DELETING_ERROR} Details ${ex.Message}"));
        }
    }
}
