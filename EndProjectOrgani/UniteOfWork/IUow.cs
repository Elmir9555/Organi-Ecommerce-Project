using System;
using System.Threading.Tasks;
using EndProjectOrgani.Entities;
using EndProjectOrgani.Repository;

namespace EndProjectOrgani.UniteOfWork
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : BaseEntity;
        Task SaveChangeAsync();
    }
}
