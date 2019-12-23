using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Context.IUnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IContext _context;
        public UnitOfWork(IContext context)
        {
            _context = context;
        }
        public DbSet<T> Repository<T>() where T : class
        {
            return _context.dbSet<T>();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }
    }
}
