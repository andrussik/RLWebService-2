using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Base;
using Domain.Enums;

namespace Domain.Entities
{
    public class Item : BaseEntity
    {
        [MaxLength(255)]
        public string Code { get; set; } = default!;

        public Guid PublicationId { get; set; }
        public Publication? Publication { get; set; }

        public Guid LibraryId { get; set; }
        public Library? Library { get; set; }

        [Column(TypeName = "int")]
        [DefaultValue(1)]
        public ItemStatus ItemStatus { get; set; }
    }
}