using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Context.IUnitOfWork
{
    public interface IContext
    {
        DbSet<T> dbSet<T>() where T : class;
        int SaveChanges();
    }
}
