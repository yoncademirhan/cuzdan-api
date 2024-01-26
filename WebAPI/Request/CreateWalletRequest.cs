using FluentValidation;

namespace WebAPI.Request;

public class CreateWalletRequest {
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Currency { get; set; }
    public string? Description { get; set; }
}



public class CreateWalletRequestValidator : AbstractValidator<CreateWalletRequest> {
    public CreateWalletRequestValidator() {
        RuleFor(x => x.UserId).NotEmpty();
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Currency).NotEmpty();
        RuleFor(x => x.Description).MinimumLength(10).When(a => a.Description != null);
        
    }
}


public class UpdateWalletRequest
{
    public string Name { get; set; }
    public string? Description { get; set; }
}

public class  UpdateWalletRequestValidator: AbstractValidator<UpdateWalletRequest>{

    public UpdateWalletRequestValidator()
    {
        RuleFor(x => x.Name).NotEmpty();
        RuleFor(x => x.Description).NotEmpty();
    }



    }