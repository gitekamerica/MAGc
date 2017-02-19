using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFCategoryRepository: ICategoryRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Category> Categorys
        {
            get { return context.Categorys; }
        }


    }
}