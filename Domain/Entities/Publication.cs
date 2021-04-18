using System.Collections.Generic;
using Domain.Common;

namespace Domain.Entities
{
    public class Publication : BaseEntity
    {
        public string MarcData { get; set; } = default!;
        public int Year { get; set; }

        public ICollection<Item>? Items { get; set; }
        public ICollection<PublicationAuthor>? PublicationAuthors { get; set; }
    }
}