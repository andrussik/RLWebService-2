using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Services.Interfaces;
using DAL.EF.Interfaces;
using DAL.Elasticsearch.Factory;
using DAL.Riks.Factory;
using DAL.Sierra.Factory;
using DAL.Urram.Factory;
using DTO.PublicApi;
using DTO.PublicApi.Mappers;
using DTO.SearchEngine.Mappers;
using DTO.Sierra;
using Item = DTO.SearchEngine.Item;
using ItemMapper = DTO.SearchEngine.Mappers.ItemMapper;

namespace BLL.Services.Impl
{
    public class BookService : BaseService, IBookService
    {
        public BookService(
            IUnitOfWork uow,
            ISierraRepositoryCollection sierraRepo,
            IRiksRepositoryCollection riksRepo,
            IUrramRepositoryCollection urramRepo,
            IElasticsearchRepositoryCollection elasticRepo
        ) : base(uow, sierraRepo, riksRepo, urramRepo, elasticRepo)
        {
        }

        public async Task<IEnumerable<Book>> FindAsync(string searchString)
        {
            var searchResponse = await SierraRepo.Books.FindAsync(searchString);

            var books = BookMapper.Map(searchResponse);
            
            return books;
        }

        public async Task<IEnumerable<Book>> ElasticFindAsync(string searchString)
        {
            var publications = await ElasticRepo.Publications.FuzzySearchAsync(searchString);
            var books = BookMapper.Map(publications);
            return books;
        }

        public async Task ElasticIndexResultAsync(string searchString)
        {
            var searchResponse = await SierraRepo.Books.FindAsync(searchString);
            var bibs = searchResponse.Entries?.Select(x => x.Bib!) ?? new List<Bib>();
            var publications = PublicationMapper.Map(bibs).ToList();

            var publicationIds = publications.Select(x => x.Id).ToList();
            var total = publicationIds.Count();
            
            var items = new List<Item>();
            for (var i = 0; i < total; i += 20)
            {
                try
                {
                    var requestPublicationIds = i + 20 > total ?
                        publicationIds.GetRange(i, total - i) :
                        publicationIds.GetRange(i, 20);
                    var sierraItems = await SierraRepo.Books.GetItemsFromBibIdsAsync(requestPublicationIds);
                    items.AddRange(ItemMapper.Map(sierraItems, "sierra").ToList());
                }
                catch (Exception)
                {
                    // ignored
                }
            }

            foreach (var publication in publications)
            {
                publication.Items = items.Where(item => item.PublicationId == publication.Id).ToList();
            }

            await ElasticRepo.Publications.IndexManyAsync(publications);
            
            
            // await _elasticRepo.IndexManyAsync(publications, "publication");

            // var searchResponseBooks = BookMapper.Map(searchResponse).ToArray();
            // var bookIds = searchResponseBooks.Select(x => x.Id).ToArray();
            //
            // var bookDocuments = new List<BookDocument>();
            //
            // var tasks = new List<Task>();
            // for (var i = 0; i < bookIds.Length; i += 280)
            // {
            //     var index = i;
            //     var task = Task.Run(async () =>
            //     {
            //         var marcFileLinkResponse = await _sierraRepo.Books.GetMarcFileLinkFromIdsAsync(bookIds.Skip(index).Take(280));
            //         var marcString = await _sierraRepo.Books.GetMarcFileAsync(marcFileLinkResponse.File);
            //         bookDocuments.AddRange(BookDocumentMapper.Map(marcString));
            //     });
            //     tasks.Add(task);
            // }
            //
            // await Task.WhenAll(tasks);
            //
            // if (bookDocuments.Count > 0)
            // {
            //     await _elasticClient.IndexManyAsync(bookDocuments, "book");    
            // }
            //
            //
            // return searchResponseBooks;
        }

        public async Task IndexDataFromSierraToElasticsearch()
        {
            var start = 1046023;
            var end = start + 2001 * 3;

            for (var i = start; i <= end; i += 2001)
            {
                var bibs = await SierraRepo.Books.GetBibsFromIdRangeAsync(i, i + 2000);
                var publications = PublicationMapper.Map(bibs).ToList();

                var items = new List<Item>();
                for (var j = i; j <= i + 2000; j += 20)
                {
                    try
                    {
                        var sierraItems = await SierraRepo.Books.GetItemsFromBibIdRangeAsync(j, j + 19);
                        items.AddRange(ItemMapper.Map(sierraItems, "sierra").ToList());
                    }
                    catch (Exception)
                    {
                        // ignored
                    }
                }

                foreach (var publication in publications)
                {
                    publication.Items = items.Where(item => item.PublicationId == publication.Id).ToList();
                }

                await ElasticRepo.Publications.IndexManyAsync(publications);
            }
        }
    }
}