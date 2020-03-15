using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UdeAPI.Core.Models;
using UdeAPI.Core.Repositories;
using UdeAPI.Core.Services;
using UdeAPI.Core.UnitOfWorks;

namespace UdeAPI.Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        public CategoryService(IUnitOfWork unitOfWork, IRepository<Category> repository) : base(unitOfWork, repository)
        {

        }

        public async Task<Category> GetWithProductsByIdAsync(int categoryId)
        {
            return await _unitOfWork.Categories.GetWithProductsByIdAsync(categoryId);
        }
    }
}
