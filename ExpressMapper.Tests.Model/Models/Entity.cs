using System;

namespace ExpressMapper.Tests.Model.Models
{
    public class Entity : EntityBase
    {
        public Guid ExternalId { get; set; }

        public decimal? Size { get; set; }
    }
}
