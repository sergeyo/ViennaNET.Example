using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NUnit.Framework;
using TestApplication.Queries.GetRegisteredVaccineCount;
using TestDomain.Entities;
using ViennaNET.TestUtils.Orm;

namespace Test.Tests
{
    public class GetRegisteredVaccineCountQueryHandlerTests
    {
        private static GetRegisteredVaccineCountQueryHandler CreateHandler(IEnumerable<Manufacturer> manufacturers)
        {
            var efs = EntityFactoryServiceStubBuilder.Create()
                .WithRepository(EntityRepositoryStub.Create(manufacturers))
                .Build();

            return new GetRegisteredVaccineCountQueryHandler(efs);
        }

        [Test]
        public async Task Handle_ShouldReturnCorrectCount()
        {
            var yesterday = DateTime.Today.AddDays(-1);
            var tomorrow = DateTime.Today.AddDays(1);

            var manufacturers = new[]
            {
                new Manufacturer()
                {
                    Name = "Государственный научный центр вирусологии и биотехнологии «Вектор»", HasMedicalLicense = true, TradeMarks =
                    {
                        new TradeMark()
                        {
                            Name = "SARS-CoV2 Vaccine go live!!!",
                            Registered = yesterday,
                            Type = TestDomain.Enums.TradeMarkType.Vaccine
                        },
                        new TradeMark()
                        {
                            Name = "not registered yet :( will be available tomorrow",
                            Registered = tomorrow,
                            Type = TestDomain.Enums.TradeMarkType.Vaccine
                        },
                    }
                },
                new Manufacturer()
                {
                    Name = "Санкт-Петербургский НИИ вакцин и сывороток", HasMedicalLicense = true, TradeMarks =
                    {
                        new TradeMark()
                        {
                            Name = "no registration data",
                            Registered = null,
                            Type = TestDomain.Enums.TradeMarkType.Vaccine
                        },
                        new TradeMark()
                        {
                            Name = "not a vaccine",
                            Registered = yesterday,
                            Type = TestDomain.Enums.TradeMarkType.Staff
                        },
                    }
                },
                new Manufacturer()
                {
                    Name = "НИЦ эпидемиологии и микробиологии им. Н. Ф. Гамалеи", HasMedicalLicense = false, TradeMarks =
                    {
                        new TradeMark()
                        {
                            Name = "actual vaccine, BUT manufacturer has NO license to produce it",
                            Registered = yesterday,
                            Type = TestDomain.Enums.TradeMarkType.Vaccine
                        },
                    }
                },
            };

            var handler = CreateHandler(manufacturers);

            var result = await handler.HandleAsync(new GetRegisteredVaccineCountQuery(), CancellationToken.None);

            Assert.That(result, Is.EqualTo(1));
        }
    }
}
