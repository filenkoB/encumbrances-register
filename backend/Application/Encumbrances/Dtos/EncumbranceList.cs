using Domain.Entities;

namespace Application.Encumbrances.Dtos
{
    public class EncumbranceList
    {
        public ShortEncumbrance[] Encumbrances { get; set; }
        public int Length { get; set; }
    }
}
