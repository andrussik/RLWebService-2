using System;
using Domain.Common;

namespace Domain.Entities
{
    public class LibraryOpenTime : BaseEntity
    {
        public int Day { get; set; }
        public DateTime From { get; set; }
    }
}