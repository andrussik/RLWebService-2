using System.ComponentModel.DataAnnotations;
using Domain.Base;

namespace Domain.Entities
{
    public class Author : BaseEntity
    {
        [MaxLength(255)]
        public string Name { get; set; } = default!;
    }
}