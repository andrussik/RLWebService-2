using System;

namespace Domain.Common
{
    public interface IBaseEntity
    {
        Guid Id { get; }
        DateTime CreatedAt { get; }
        DateTime UpdatedAt { get; }
        DateTime? DeletedAt { get; }
    }
}