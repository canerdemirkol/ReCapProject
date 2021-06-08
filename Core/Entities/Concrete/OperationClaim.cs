using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public partial class OperationClaim : EntityBase<int>, IEntity
    {
        public string Name { get; set; }
    }
}
