using System;
using Domain.Common;

namespace Domain.Entities
{
    public class PublicationLanguage : BaseEntity
    {
        public Guid PublicationId { get; set; }
        public Publication? Publication { get; set; }

        public int Language { get; set; }
    }
}