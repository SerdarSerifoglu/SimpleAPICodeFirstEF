using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdeAPI.Core.Repositories;

namespace UdeAPI.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IProductRepository Products { get; }
        ICategoryRepository Categories { get; }
        Task CommitAsync();
        void Commit();
    }
}
