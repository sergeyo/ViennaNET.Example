using FluentNHibernate.Mapping;
using TestDomain.Entities;
using TestDomain.Enums;

namespace TestDomain.Mappings
{
    public class TradeMarkMapping : ClassMap<TradeMark>
    {
        public TradeMarkMapping()
        {
            Table("trademark");
            Id(t => t.Id);
            Map(t => t.Type).CustomType<TradeMarkType>();
            Map(t => t.Name);
            Map(t => t.Created);
            Map(t => t.Registered);
        }
    }
}
