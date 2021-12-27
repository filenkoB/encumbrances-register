using Application.Users.Registrators.Dtos;
using Domain.Interfaces.Abstract;
using Domain.PostgreSQL.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Users.Registrators.Commands
{
    public class UpdateRegistratorCommand : IRequest<Unit>
    {
        public UpdateRegistratorDto Registrator { get; set; }

        public UpdateRegistratorCommand(UpdateRegistratorDto registrator)
        {
            Registrator = registrator;
        }
    }

    public class UpdateRegistratorCommandHandler : IRequestHandler<UpdateRegistratorCommand, Unit>
    {
        private readonly IReadRepository<Registrator> _registratorReadRepository;
        private readonly IWriteRepository<Registrator> _registratorWriteRepository;
        private readonly IReadRepository<Identificator> _identificatorReadRepository;
        private readonly IWriteRepository<Identificator> _identificatorWriteRepository;

        public UpdateRegistratorCommandHandler(
            IReadRepository<Registrator> registratorReadRepository,
            IWriteRepository<Registrator> registratorWriteRepository,
            IReadRepository<Identificator> identificatorReadRepository,
            IWriteRepository<Identificator> identificatorWriteRepository)
        {
            _registratorReadRepository = registratorReadRepository;
            _registratorWriteRepository = registratorWriteRepository;
            _identificatorReadRepository = identificatorReadRepository;
            _identificatorWriteRepository = identificatorWriteRepository;
        }
        public async Task<Unit> Handle(UpdateRegistratorCommand command, CancellationToken cancellationToken)
        {
            UpdateRegistratorDto registratorDto = command.Registrator;
            Registrator registrator = await _registratorReadRepository.GetEntityByIdAsync(registratorDto.Id, "Registrators");
            registrator.FirstName = registratorDto.FirstName;
            registrator.LastName = registratorDto.LastName;
            registrator.Patronymic = registratorDto.Patronymic;
            registrator.BirthDate = registratorDto.BirthDate;
            registrator.Email = registratorDto.Email;
            registrator.AuthorityId = registratorDto.AuthorityId;
            await _registratorWriteRepository.UpdateAsync(registrator);

            Identificator identificator = (await _identificatorReadRepository.GetEntitiesByParamsAsync("Identificators",
                ("Login", registrator.IdentificatorId)
            )).First();
            identificator.Status = registratorDto.Status;
            await _identificatorWriteRepository.UpdateAsync(identificator);

            return Unit.Value;
        }
    }
}
