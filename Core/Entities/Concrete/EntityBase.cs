using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entities.Concrete
{
    public abstract class EntityBase<Tkey>
    {
        public Tkey ID { get; set; }
    }
}
