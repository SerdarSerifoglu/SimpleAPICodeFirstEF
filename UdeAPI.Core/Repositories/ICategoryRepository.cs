using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdeAPI.Core.Models;

namespace UdeAPI.Core.Repositories
{
    public interface ICategoryRepository : IRepository<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);
    }
}
