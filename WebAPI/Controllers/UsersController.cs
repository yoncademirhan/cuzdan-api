using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.EntityFramework.Repositories;
using WebAPI.Interfaces.Repositories;
using WebAPI.Request;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IValidator<CreateUserRequest> _createUserRequest;
    private readonly IUserRepository _userRepository;
    private readonly IValidator<UpdateUserRequest> _updateUserValidator;

    public UsersController(IValidator<CreateUserRequest> createUserRequest, IUserRepository userRepository, IValidator<UpdateUserRequest> updateUserValidator)
    {
        _createUserRequest = createUserRequest;
        _userRepository = userRepository;
        _updateUserValidator = updateUserValidator;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateUser(CreateUserRequest request)
    {
        var validationResult = await _createUserRequest.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        User user = new User
        {
            Name = request.Name,
            Surname = request.Surname,
            Email = request.Email,
            Password = request.Password
        };

        user = await _userRepository.CreateUserAsync(user);

        return Ok(user);
    }

    [HttpGet("get/{id}")]
    public async Task<IActionResult> GetUserById(int id)
    {
        User user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        return Ok(user);
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> UpdateUser(int id, UpdateUserRequest request)
    {
        var validationResult = await _updateUserValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        User user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        user.Name = request.Name;
        user.Surname = request.Surname;
        user.Email = request.Email;
        user.Password = request.Password;

        user = await _userRepository.UpdateUserAsync(user);

        return Ok(user);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        User user = await _userRepository.GetUserByIdAsync(id);

        if (user == null)
        {
            return NotFound();
        }

        await _userRepository.DeleteUserAsync(id);
        return Ok();
    }
}