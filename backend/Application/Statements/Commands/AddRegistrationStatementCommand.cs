using Application.Statements.Dtos;
using AutoMapper;
using Domain.Interfaces.Write;
using MediatR;
using MongoDB.Bson;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Statements.Commands
{
    public class RegisterStatementCommand : IRequest<StatementRegistrationDto>
    {
        public AddRegistrationStatementDto Dto { get; set; }

        public RegisterStatementCommand(AddRegistrationStatementDto dto)
        {
            Dto = dto;
        }
    }

    public class RegisterStatementCommandHandler : IRequestHandler<RegisterStatementCommand, StatementRegistrationDto>
    {
        private readonly IStatementWriteRepository _statementWriteRepository;
        private readonly IMapper _mapper;
        public RegisterStatementCommandHandler(IStatementWriteRepository statementWriteRepository, IMapper mapper)
        {
            _statementWriteRepository = statementWriteRepository;
            _mapper = mapper;
        }
        public async Task<StatementRegistrationDto> Handle(RegisterStatementCommand command, CancellationToken token)
        {
            var registrationStatementDto = _mapper.Map<StatementRegistrationDto>(command.Dto);

            registrationStatementDto.Status = 0;
            registrationStatementDto.GeneralInfo.Number = await _statementWriteRepository.GetNewStatementNumber();

            await _statementWriteRepository.AddStatementAsync(registrationStatementDto.ToBsonDocument());

            return registrationStatementDto;
        }
    }
}
