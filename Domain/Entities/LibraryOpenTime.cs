using System;
using Domain.Base;

namespace Domain.Entities
{
    public class LibraryOpenTime : BaseEntity
    {
        public int Day { get; set; }
        public DateTime From { get; set; }
    }
}