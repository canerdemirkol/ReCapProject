using Core.Entities;
using Core.Entities.Concrete;
using System;
using System.Collections.Generic;

namespace Entities.Concrete
{
    public class MAP_KEY : EntityBase<int>, IEntity
    {
        public string MAP_API_KEY { get; set; }
    }
}
