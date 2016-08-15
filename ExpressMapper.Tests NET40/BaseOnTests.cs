using ExpressMapper.Tests.Model.Enums;
using ExpressMapper.Tests.Model.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressMapper.Tests
{
    [TestFixture]
    public class BaseOnTests : BaseTestClass
    {
        [SetUp]
        public void Setup()
        {
            Mapper.Register<EntityBase, DtoBase>()
                  .Member(dest => dest.GenderDesc, src => src.Gender.ToString())
                  .Value(dest => dest.Id, 999);

            Mapper.BaseOn<Entity, EntityBase, Dto, DtoBase>()
                  .Member(dest => dest.ExternalId, src => src.ExternalId.ToString("D"))
                  .Member(dest => dest.SizeRound, src => (int)src.Size.GetValueOrDefault());

            Mapper.Register<EntitySettingsBase, DtoSettingsBase>()
                  .CaseSensitive(false)
                  .Function(dest => dest.Settings, src => new List<string>(src.Settings));

            Mapper.BaseOn<EntitySettings, EntitySettingsBase, DtoSettings, DtoSettingsBase>()
                  .Member(dest => dest.Desc, src => src.Description)
                  .Member(dest => dest.Additional, src => src.Additional.Select(x => x.Value).ToArray());
        }

        

        [Test]
        public void FirstParentSecondChildTypesMapping()
        {
            //Arrange

            var entity = new EntityBase
            {
                Gender = GenderTypes.Unisex,
                Id = 5,
                Settings = new EntitySettings
                {
                    CaseSensitive = "casesensitivitycheck",
                    ConfigId = 10,
                    Settings = new List<string> { "key1:value1", "key2:value2" },
                    Additional = new Dictionary<int, string>
                    {
                        { 3, "value3" }, { 4, "value4" }
                    },
                    Description = "DescriptionTest"
                }
            };

            //Act

            var dto = Mapper.Map<EntityBase, DtoBase>(entity);

            //Assert   

            Assert.Inconclusive("TODO: Evaluate result!");
        }

        [Test]
        public void FirstChildSecondParentTypesMapping()
        {
            //Arrange

            var entity = new Entity
            {
                Gender = GenderTypes.Unisex,
                Id = 5,
                ExternalId = Guid.NewGuid(),
                Size = 8.9876m,
                Settings = new EntitySettingsBase
                {
                    CaseSensitive = "casesensitivitycheck",
                    ConfigId = 10,
                    Settings = new List<string> { "key1:value1", "key2:value2" }
                }
            };

            //Act

            var dto = Mapper.Map<Entity, Dto>(entity);

            //Assert   

            Assert.Inconclusive("TODO: Evaluate result!");
        }

        [Test]
        public void AllChildTypesMapping()
        {
            //Arrange

            var entity = new Entity
            {
                Gender = GenderTypes.Unisex,
                Id = 5,
                ExternalId = Guid.NewGuid(),
                Size = 8.9876m,
                Settings = new EntitySettings
                {
                    CaseSensitive = "casesensitivitycheck",
                    ConfigId = 10,
                    Settings = new List<string> { "key1:value1", "key2:value2" },
                    Additional = new Dictionary<int, string>
                    {
                        { 3, "value3" }, { 4, "value4" }
                    },
                    Description = "DescriptionTest"
                }
            };

            //Act

            var dto = Mapper.Map<Entity, Dto>(entity);

            //Assert   

            Assert.Inconclusive("TODO: Evaluate result!");
        }

    }
}
