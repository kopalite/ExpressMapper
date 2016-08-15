namespace ExpressMapper.Tests.Model.Models
{
    public class DtoBase
    {
        public int Id { get; set; }

        public string GenderDesc { get; set; }

        public DtoSettingsBase Settings { get; set; }
    }
}
