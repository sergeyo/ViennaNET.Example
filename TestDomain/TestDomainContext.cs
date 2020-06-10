using System;
using System.Collections.Generic;
using System.Text;
using TestDomain.Entities;
using ViennaNET.Orm.Seedwork;

namespace TestDomain
{
    public class TestDomainContext : BoundedContext
    {
        public TestDomainContext()
        {
            AddEntity<Manufacturer>();
            AddEntity<TradeMark>();
        }
    }
}
