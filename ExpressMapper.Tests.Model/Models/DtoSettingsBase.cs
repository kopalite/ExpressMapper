using System.Collections.Generic;

namespace ExpressMapper.Tests.Model.Models
{
    public class DtoSettingsBase
    {
        public string cASEsENSITIVE { get; set; }

        public int ConfigId { get; set; }

        public List<string> Settings { get; set; }
    }
}
