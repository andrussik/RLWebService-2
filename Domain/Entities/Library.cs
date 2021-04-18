using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
    public class Library : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
        [MaxLength(255)]
        public string Code { get; set; } = default!;

        public LibraryStatus LibraryStatus { get; set; } = LibraryStatus.Status2;

        public ICollection<Item>? Items { get; set; }
    }
}