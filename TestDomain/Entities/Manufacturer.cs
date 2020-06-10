using System.Collections.Generic;
using System.Text;
using ViennaNET.Orm.Seedwork;

namespace TestDomain.Entities
{
    public class Manufacturer : IEntityKey<int>
    {
        public virtual int Id { get; }

        public virtual string Name { get; set; }

        public virtual string Address { get; set; }

        public virtual bool HasMedicalLicense { get; set; }

        public virtual ISet<TradeMark> TradeMarks { get; set; } = new HashSet<TradeMark>();
    }
}
