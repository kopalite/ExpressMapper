using System.Collections.Generic;

namespace ExpressMapper.Tests.Model.Models
{
    public class EntitySettings : EntitySettingsBase
    {
        public string Description { get; set; }

        public Dictionary<int, string> Additional { get; set; }
    }
}
