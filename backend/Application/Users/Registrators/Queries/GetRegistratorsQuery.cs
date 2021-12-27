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
    public class GetRegistratorsQuery : IRequest<ShortRegistratorList>
    {
        public int Page { get; set; }
        public int Length { get; set; }

        public GetRegistratorsQuery(int page, int length)
        {
            Page = page;
            Length = length;
        }
    }

    public class GetRegistratorsQueryHandler : IRequestHandler<GetRegistratorsQuery, ShortRegistratorList>
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
        public async Task<ShortRegistratorList> Handle(GetRegistratorsQuery query, CancellationToken cancellationToken)
        {
            int page = query.Page;
            int length = query.Length;
            IEnumerable<Registrator> registrators = await _registratorReadRepository.GetEntitiesAsync("Registrators");

            var registratorDtos = new List<ShortRegistratorDto>();
            foreach (var registrator in registrators.Skip((page - 1) * length).Take(length))
            {
                var registratorDto = _mapper.Map<ShortRegistratorDto>(registrator);
                registratorDto.Status = (await _identificatorReadRepository.GetEntitiesByParamsAsync("Identificators",
                    ("Login", registrator.IdentificatorId)
                )).First().Status;

                registratorDtos.Add(registratorDto);
            }
            return new ShortRegistratorList()
            {
                Registrators = registratorDtos.ToArray(),
                Length = registrators.Count()
            };
        }
    }
}
