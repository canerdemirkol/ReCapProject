using Core.Entities;
using Core.Entities.Concrete;

namespace Entities.Concrete
{
    public class ILETISIM_TIP : EntityBase<int>, IEntity
    {
        public string TIP_ADI { get; set; }
    }
}
