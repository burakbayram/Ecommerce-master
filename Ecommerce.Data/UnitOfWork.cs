using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data
{
    // unit of work repository'ler arası transaction yönetimi için kullanılır.
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext db;
        public UnitOfWork(ApplicationDbContext context)
        {
            this.db = context;
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
