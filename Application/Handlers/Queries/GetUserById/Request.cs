using MediatR;

namespace Application.Handlers.Queries.GetUserById
{
    public class Request : IRequest<Response>
    {
        public int Id { get; set; }
    }
}