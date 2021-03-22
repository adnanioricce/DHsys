using Api.Tests;
using Core.Entities;
using DAL.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using Tests.Lib;

namespace DAL.Tests
{
    public class RepositoryHelper
    {
        public static Repository<T> GetRepository<T>() where T : BaseEntity
        {
            return new Repository<T>(new DHsysContextFactory().CreateContext(GlobalConfiguration.ConnectionString));
        }        
    }
}
