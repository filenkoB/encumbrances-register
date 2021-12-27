using Domain.Entities;
using iTextSharp.text;
using System.IO;

namespace Domain.Interfaces.Services
{
    public interface IExtractGeneratorService
    {
        public void GenerateExtractForEncumbrance(ref MemoryStream mstream, ExtractEncumbrance encumbrance);
    }
}
