using Domain.Entities;
using Domain.Interfaces.Services;
using iTextSharp.text;
using System.IO;
using iTextSharp.text.pdf;
using System.Text;
using System.Reflection;
using SautinSoft;

namespace Infrastructure.Services
{
    public class ExtractGeneratorService : IExtractGeneratorService
    {
        public void GenerateExtractForEncumbrance(ref MemoryStream mstream, ExtractEncumbrance encumbrance)
        {
            PdfMetamorphosis pdf = new PdfMetamorphosis();
            pdf.PageSettings.Size.A4();
            byte[] documentBytes = pdf.HtmlToPdfConvertStringToByte(GenerateFiledHtmlDocument(encumbrance));
            mstream.Write(documentBytes, 0, documentBytes.Length);
        }
        private string GetTemplateHtml()
        {
            return File.ReadAllText("./ExtractTemplate.html");
        }

        private string GenerateFiledHtmlDocument(ExtractEncumbrance encumbrance)
        {
            StringBuilder sb = new StringBuilder(GetTemplateHtml());

            PropertyInfo[] properties = encumbrance.GetType().GetProperties();
            foreach (var property in properties)
            {
                string propertyName = property.Name;
                string propertyValue = property.GetValue(encumbrance) as string;

                sb.Replace("[#" + propertyName + "#]", propertyValue);
            }

            return sb.ToString();
        }
    }
}
