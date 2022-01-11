using Domain.Services.Infrastructure;
using MediatR;

namespace Application.Handlers.Queries.GetUserById;

public class GetUserByIdHandler : IRequestHandler<Request, Response>
{
    private readonly IUserService _userService;

    public GetUserByIdHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<Response> Handle(Request request, CancellationToken cancellationToken)
    {
        if (request == null)
        {
            return new();
        }

        var user = await _userService.FindUserByIdAsync(request.Id);

        return new()
        {
            User = user,
        };
    }
}

