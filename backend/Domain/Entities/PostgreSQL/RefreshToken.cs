using Domain.Common;

namespace Domain.PostgreSQL.Entities
{
    public class RefreshToken : EntityId
    {
        public string Token { get; set; }

        public Identificator Identificator { get; set; }
    }
}
