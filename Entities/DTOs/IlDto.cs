using Core.Entities;

namespace Entities.DTOs
{
    public class IlDto : IDto, ISqlEntityType
    {
        public int IL_KODU { get; set; }
        public string IL_ADI { get; set; }
        
    }
}
