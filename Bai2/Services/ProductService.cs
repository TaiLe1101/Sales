using Bai2.Common;
using Bai2.Data;
using Bai2.Interfaces;
using Bai2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace Bai2.Services
{
    public class ProductService : BaseService<Product>, IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext) : base(dbContext)
        {
            this._dbContext = dbContext;
        }

        public override List<Product> FindAll()
        {
            return _dbContext.Products.Include(x => x.Category).ToList(); ;
        }
    }
}
