using System.Collections.Generic;
using AcmeRemote.BusinessEntity;

namespace AcmeRemote.DataAccess
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        List<T> Get();
        T GetById(int id);
    }
}