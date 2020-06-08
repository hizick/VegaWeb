using System;
using System.Collections.Generic;
using System.Text;
using VegaData.Models.Context;

namespace VegaData.Repositories
{
    public interface IUnitOfWork
    {
        void saveChanges();
    }

    public class UnitOfWork : IUnitOfWork
    {
        private readonly VegaDbContext context;

        public UnitOfWork(VegaDbContext context)
        {
            this.context = context;
        }
        public void saveChanges()
        {
            context.SaveChanges();
        }
    }
}
