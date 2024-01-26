using FluentValidation;
using WebAPI.Request;

namespace WebAPI.Request
{
    public class CreateUserRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }




    }


    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
      public  CreateUserRequestValidator()
        {
            RuleFor(x=>x.Name).NotEmpty();
            RuleFor(x=>x.Surname).NotEmpty();
            RuleFor(x => x.Password).NotEmpty().MaximumLength(10);
            RuleFor(x=>x.Email).NotEmpty().EmailAddress();

        }
    }

    public class UpdateUserRequest
    {
        public string Name { get; set; }
        public string? Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }

    }

    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {

        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Surname).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
        }



    }

}

