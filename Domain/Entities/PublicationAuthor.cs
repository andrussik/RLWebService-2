using System;
using Domain.Base;

namespace Domain.Entities
{
    public class PublicationAuthor : BaseEntity
    {
        public Guid PublicationId { get; set; }
        public Publication? Publication { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}