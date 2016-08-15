using System.Collections.Generic;

namespace ExpressMapper.Tests.Model.Models
{
    public class EntitySettingsBase
    {
        public string CaseSensitive { get; set; }

        public int ConfigId { get; set; }

        public List<string> Settings { get; set; }
    }
}
