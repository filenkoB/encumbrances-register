using Application.Users.Registrators.Dtos;
using AutoMapper;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Registrators.Queries
{
    public class GetRegistratorsQuery : IRequest<IEnumerable<ShortRegistratorDto>>
    {
        public int Page { get; set; }
        public int Length { get; set; }

        public GetRegistratorsQuery(int page, int length)
        {
            Page = page;
            Length = length;
        }
    }

    public class GetRegistratorsQueryHandler : IRequestHandler<GetRegistratorsQuery, IEnumerable<ShortRegistratorDto>>
    {
        private readonly IReadRepository<Registrator> _registratorReadRepository;
        private readonly IReadRepository<Identificator> _identificatorReadRepository;
        private readonly IMapper _mapper;

        public GetRegistratorsQueryHandler(
            IReadRepository<Registrator> registratorReadRepository,
            IReadRepository<Identificator> identificatorReadRepository,
            IMapper mapper)
        {
            _identificatorReadRepository = identificatorReadRepository;
            _registratorReadRepository = registratorReadRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<ShortRegistratorDto>> Handle(GetRegistratorsQuery query, CancellationToken cancellationToken)
        {
            int page = query.Page;
            int length = query.Length;
            IEnumerable<Registrator> registrators = (await _registratorReadRepository.GetEntitiesAsync("Registrators"))
                .Skip((page - 1) * length).Take(length);

            var registratorDtos = new List<ShortRegistratorDto>(); _mapper.Map<IEnumerable<ShortRegistratorDto>>(registrators);
            foreach (var registrator in registrators)
            {
                var registratorDto = _mapper.Map<ShortRegistratorDto>(registrator);
                registratorDto.Status = (await _identificatorReadRepository.GetEntitiesByParamsAsync("Identificators",
                    ("Login", registrator.IdentificatorId)
                )).First().Status;

                registratorDtos.Add(registratorDto);
            }
            return registratorDtos;
        }
    }
}
