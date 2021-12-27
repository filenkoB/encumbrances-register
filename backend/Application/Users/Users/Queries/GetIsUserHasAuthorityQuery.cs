using Domain.Interfaces.Read;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Users.Queries
{
    public class GetIsUserHasAuthorityQuery : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public GetIsUserHasAuthorityQuery(Guid userId)
        {
            UserId = userId;
        }
    }

    public class GetIsUserHasAuthorityQueryHandler : IRequestHandler<GetIsUserHasAuthorityQuery, bool>
    {
        private readonly IUserReadRepository _userReadRepository;
        public GetIsUserHasAuthorityQueryHandler(IUserReadRepository userReadRepository)
        {
            _userReadRepository = userReadRepository;
        }

        public async Task<bool> Handle(GetIsUserHasAuthorityQuery query, CancellationToken token)
        {
            return await _userReadRepository.GetIsUserHasAuthorityAsync(query.UserId);
        }
    }
}
