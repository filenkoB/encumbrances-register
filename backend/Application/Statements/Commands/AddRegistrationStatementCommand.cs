using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Commands
{
    public class AddRegistrationStatementCommand : IRequest<RegistrationStatementDto>
    {
        public AddRegistrationStatementDto Dto { get; set; }

        public AddRegistrationStatementCommand(AddRegistrationStatementDto dto)
        {
            Dto = dto;
        }
    }

    public class AddRegistrationStatementCommandHandler : IRequestHandler<AddRegistrationStatementCommand, RegistrationStatementDto>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IMapper _mapper;
        public AddRegistrationStatementCommandHandler(IStatementWriteRepository statementWriteRepository, IMapper mapper)
        {
            _statementWriteRepository = statementWriteRepository;
            _mapper = mapper;
        }
        public async Task<RegistrationStatementDto> Handle(AddRegistrationStatementCommand command, CancellationToken token)
        {
            var registrationStatementDto = _mapper.Map<RegistrationStatementDto>(command.Dto);
            registrationStatementDto.GeneralInfo.Number = await _statementWriteRepository.GetNewStatementNumber();

            await _statementWriteRepository.AddStatementAsync(registrationStatementDto.ToBsonDocument());

            return registrationStatementDto;
        }
    }
}
