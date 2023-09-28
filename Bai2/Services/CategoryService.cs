using Bai2.Common;
using Bai2.Data;
using Bai2.Interfaces;
using Bai2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bai2.Services
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        public CategoryService(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
