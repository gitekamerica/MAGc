using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication.Abstract;
using WebApplication.Entities;

namespace WebApplication.Concrete
{
    public class EFPersonRepository: IPersonRepository
    {
        private EFDbContext context = new EFDbContext();

        public IQueryable<Persons> Persons
        {
            get { return context.Persons; }
        }



    }
}