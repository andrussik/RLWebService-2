using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Work : BaseEntity
    {
        public ICollection<Publication>? Publications { get; set; }
        public ICollection<WorkAuthor>? WorkAuthors { get; set; }
    }
}