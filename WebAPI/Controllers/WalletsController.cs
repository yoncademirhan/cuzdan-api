using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Entities;
using WebAPI.Interfaces.Repositories;
using WebAPI.Request;

namespace WebAPI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WalletsController : ControllerBase
{
    private readonly IValidator<CreateWalletRequest> _createWalletValidator;
    private readonly IWalletRepository _walletRepository;
    private readonly IValidator<UpdateWalletRequest> _updateWalletValidator;

    public WalletsController(IValidator<CreateWalletRequest> createWalletValidator, IWalletRepository walletRepository, IValidator<UpdateWalletRequest> updateWalletValidator)
    {

        _createWalletValidator = createWalletValidator;
        _walletRepository = walletRepository;
        _updateWalletValidator = updateWalletValidator;


    }




    [HttpPost("create")] //action - endpoint
    public async Task<IActionResult> Create(CreateWalletRequest request)
    {
        var validationResult = await _createWalletValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }

        Wallet wallet = new()
        {
            Name= request.Name,
            UserId = request.UserId,
            Currency = request.Currency,
            Description = request.Description
        };

        wallet = await _walletRepository.CreateWallet(wallet);

        return Ok(wallet);
    }

    [HttpDelete("delete/{id}")]
    public async Task<IActionResult> Delete(Int32 id)
    {
        Wallet wallet = await _walletRepository.GetWalletById(id);
        if (wallet == null)
        {
            return NotFound();
        }

        await _walletRepository.DeleteWallet(wallet);
        return Ok();
    }

    [HttpPut("update/{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] UpdateWalletRequest request)
    {
        var validationResult = await _updateWalletValidator.ValidateAsync(request);

        if (!validationResult.IsValid)
        {
            return BadRequest(validationResult.Errors);
        }
        Wallet wallet = await _walletRepository.GetWalletById(id);

        if (wallet == null)
        {
            return NotFound();
        }

        wallet.Name = request.Name;
        wallet.Description = request.Description;


        wallet = await _walletRepository.UpdateWallet(wallet);
        return Ok(wallet);
    }



    //update
    //delete
    //read

    [HttpGet("get/{id}")]
    public async Task<IActionResult> Get(Int32 id)
    {
        Wallet wallet = await _walletRepository.GetWalletById(id);

        if (wallet == null)
        {
            return NotFound();
        }

        return Ok(wallet);
    }
}


