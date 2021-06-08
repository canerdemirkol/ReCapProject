using Core.Entities;
using Core.Entities.Concrete;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public partial class CUSTOMER : EntityBase<int>, IEntity
    {
        public CUSTOMER()
        {
            RENTALS = new HashSet<RENTAL>();
        }
        public int FK_USER_ID { get; set; }

        public string COMPANY_NAME { get; set; }

        public virtual ICollection<RENTAL> RENTALS { get; set; }
    }


}
