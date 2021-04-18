using System;
using DAL.EF.Repositories;
using DAL.EF.Repositories.Impl;

namespace DAL.EF.Factory
{
    public class EFRepositoryCollection : EFRepositoryFactory, IEFRepositoryCollection
    {
        public EFRepositoryCollection(AppDbContext dbContext) : base(dbContext)
        {
        }

        public IAuthorRepository Authors =>
            GetRepository(() => new AuthorRepository(_dbContext));
        public IWorkRepository Works =>
            GetRepository(() => new WorkRepository(_dbContext));

        public IWorkAuthorRepository WorkAuthors =>
            GetRepository(() => new WorkAuthorRepository(_dbContext));
    }
}