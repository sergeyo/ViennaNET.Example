using System;
using TestDomain.Enums;
using ViennaNET.Orm.Seedwork;

namespace TestDomain.Entities
{
    public class TradeMark : IEntityKey<int>
    {
        public virtual int Id { get; }

        public virtual TradeMarkType Type { get; set; }

        public virtual string Name { get; set; }

        public virtual DateTime Created { get; set; }

        public virtual DateTime? Registered { get; set; }

        public virtual bool IsActiveVaccine() => 
            Type == TradeMarkType.Vaccine && Registered < DateTime.Now;
    }
}
