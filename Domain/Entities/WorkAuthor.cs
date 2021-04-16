using System;
using Domain.Base;

namespace Domain.Entities
{
    public class WorkAuthor : BaseEntity
    {
        public Guid WorkId { get; set; }
        public Work? Work { get; set; }

        public Guid AuthorId { get; set; }
        public Author? Author { get; set; }
    }
}