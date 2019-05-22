using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Data
{
    public interface IUnitOfWork
    {
        void SaveChanges();
    }
}
