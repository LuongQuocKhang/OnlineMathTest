using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineMathTest.Context.IUnitOfWork
{
    public interface IUnitOfWork
    {
        DbSet<T> Repository<T>() where T : class;
        int SaveChanges();
    }
}
