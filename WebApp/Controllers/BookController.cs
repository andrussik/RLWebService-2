using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Factory;
using DTO.PublicApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController
    {
        private readonly IServiceCollection _bll;

        public BookController(IServiceCollection bll)
        {
            _bll = bll;
        }

        [HttpGet("{searchString}")]
        public async Task<IEnumerable<Book>> GetBooks(string searchString)
        {
            return await _bll.Books.FindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task<IEnumerable<Book>> GetBooksFromElasticIndex(string searchString)
        {
            return await _bll.Books.ElasticFindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task GetElasticIndexResult(string searchString)
        {
            await _bll.Books.ElasticIndexResultAsync(searchString);
        }
        
        [HttpGet("IndexDataFromSierraToElasticsearch")]
        public async Task GetIndexDataFromSierraToElasticsearch()
        {
            await _bll.Books.IndexDataFromSierraToElasticsearch();
        }
    }
}