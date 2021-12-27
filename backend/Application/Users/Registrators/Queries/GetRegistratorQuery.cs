using Application.Authorities.Dtos;
using Application.Users.Registrators.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Registrators.Queries
{
    public class GetRegistratorQuery : IRequest<RegistratorDto>
    {
        public Guid RegistratorId { get; set; }

        public GetRegistratorQuery(Guid registratorId)
        {
            RegistratorId = registratorId;
        }
    }

    public class GetRegistratorQueryHandler : IRequestHandler<GetRegistratorQuery, RegistratorDto>
    {
        private readonly IReadRepository<Registrator> _registratorReadRepository;
        private readonly IReadRepository<Authority> _authorityReadRepository;
        private readonly IReadRepository<Identificator> _identificatorReadRepository;
        private readonly IMapper _mapper;

        public GetRegistratorQueryHandler(
            IReadRepository<Registrator> registratorReadRepository,
            IReadRepository<Authority> authorityReadRepository,
            IReadRepository<Identificator> identificatorReadRepository,
            IMapper mapper)
        {
            _authorityReadRepository = authorityReadRepository;
            _registratorReadRepository = registratorReadRepository;
            _identificatorReadRepository = identificatorReadRepository;
            _mapper = mapper;
        }
        public async Task<RegistratorDto> Handle(GetRegistratorQuery query, CancellationToken cancellationToken)
        {
            Guid registratorId = query.RegistratorId;
            Registrator registrator = await _registratorReadRepository.GetEntityByIdAsync(registratorId, "Registrators");
            var registratorDto = _mapper.Map<RegistratorDto>(registrator);
            registratorDto.Authority = _mapper.Map<ShortAuthorityDto>(
                await _authorityReadRepository.GetEntityByIdAsync(registrator.AuthorityId, "Authorities")
            );
            registratorDto.Status = (await _identificatorReadRepository.GetEntitiesByParamsAsync("Identificators",
                ("Login", registrator.IdentificatorId)
            )).First().Status;

            return registratorDto;
        }
    }
}
