using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Application.Statements.Dtos
{
    public class EncumbranceObjectDto
    {
        [BsonId]
        public Guid Id { get; set; }
        public string ObjectDescription { get; set; }
        public string SerialNumber { get; set; }
        public string StateRegistrationNumber { get; set; }
        public string AnotherObjectsDesc { get; set; }
    }
}
