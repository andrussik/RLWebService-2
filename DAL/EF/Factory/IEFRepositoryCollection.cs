using System.Collections.Generic;
using DAL.Common.Factory;
using DAL.EF.Repositories;
using Domain.Entities;

namespace DAL.EF.Factory
{
    public interface IEFRepositoryCollection : IRepositoryFactory
    {
        IAuthorRepository Authors { get; }
        IWorkRepository Works { get; }
        IWorkAuthorRepository WorkAuthors { get; }
    }
}