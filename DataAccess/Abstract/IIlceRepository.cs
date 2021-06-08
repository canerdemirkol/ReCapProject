using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.EntityFreamwork;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Abstract
{
    public interface IIlceRepository : IEntityRepository<ILCE>
    {
        List<ILCE> ilceListele(int ilKodu);
    }
}
