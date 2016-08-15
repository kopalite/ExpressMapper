using ExpressMapper.Tests.Model.Enums;
using System;

namespace ExpressMapper.Tests.Model.Models
{
    public class EntityBase
    {
        public int Id { get; set; }

        public GenderTypes Gender { get; set; }

        public EntitySettingsBase Settings { get; set; }
    }
}
