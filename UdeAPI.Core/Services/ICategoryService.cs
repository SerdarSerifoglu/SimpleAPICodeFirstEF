using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdeAPI.Core.Models;

namespace UdeAPI.Core.Services
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> GetWithProductsByIdAsync(int categoryId);

    }
}
