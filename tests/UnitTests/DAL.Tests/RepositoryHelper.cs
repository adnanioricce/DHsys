using Core.Entities;
using DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Tests
{
    public class RepositoryHelper
    {
        public static Repository<T> GetRepository<T>(BaseContext context) where T : BaseEntity
        {
            return new Repository<T>(DbContextHelper.CreateContext());
        }        
    }
}
