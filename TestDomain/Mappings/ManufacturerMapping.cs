using FluentNHibernate.Mapping;
using TestDomain.Entities;

namespace TestDomain.Mappings
{
    public class ManufacturerMapping : ClassMap<Manufacturer>
    {
        public ManufacturerMapping()
        {
            Table("manufacturer");
            Id(m => m.Id);
            Map(m => m.Name);
            Map(m => m.Address);
            Map(m => m.HasMedicalLicense).Column("has_medical_license");
            HasMany(m => m.TradeMarks)
                .KeyColumn("manufacturer_id")
                .Cascade.AllDeleteOrphan();
        }
    }
}
