using Core.DataAccess.EntityFreamwork;
using Core.Entities.Concrete;
using Core.Utilities.Results.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    public interface IUserRepository : IEntityRepository<User>
	{
		List<OperationClaim> GetClaims(int userId);//User rollerini cekmeye yariyor
	}
}
