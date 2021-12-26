using Application.Common;
using System;

namespace Application.Statements.Dtos
{
    public class AddExtractStatementDto : IdDto
    {
        public Guid EncumbranceId { get; set; }
        public Guid StatementOwnerId { get; set; }
        public Guid StatementTypeId { get; set; } = new Guid("41b2c7aa-7af6-4221-9afa-3d54e70b8470");

        public AddExtractStatementDto(Guid encumbranceId, Guid userId)
        {
            EncumbranceId = encumbranceId;
            StatementOwnerId = userId;
        }
    }
}
