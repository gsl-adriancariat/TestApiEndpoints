using FluentValidation;

namespace Application.Handlers.Queries.GetUserById
{
    public class RequestValidator : AbstractValidator<Request>
    {
        public RequestValidator()
        {
            RuleFor(request => request.Id).GreaterThan(0).WithMessage("Id is not valid");
        }
    }
}
