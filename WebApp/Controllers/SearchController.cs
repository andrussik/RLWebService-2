using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Factory;
using Domain.Entities;
using DTO.PublicApi;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SearchController
    {
        private readonly IServiceCollection _bll;

        public SearchController(IServiceCollection bll)
        {
            _bll = bll;
        }

        [HttpGet("{searchString}")]
        public async Task<IEnumerable<Book>> GetBooks(string searchString)
        {
            return await _bll.Searches.FindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task<IEnumerable<Book>> GetBooksFromElasticIndex(string searchString)
        {
            return await _bll.Searches.ElasticFindAsync(searchString);
        }

        [HttpGet("Elastic/{searchString}")]
        public async Task GetElasticIndexResult(string searchString)
        {
            await _bll.Searches.ElasticIndexResultAsync(searchString);
        }
        
        [HttpGet("IndexDataFromSierraToElasticsearch")]
        public async Task GetIndexDataFromSierraToElasticsearch()
        {
            await _bll.Searches.IndexDataFromSierraToElasticsearch();
        }
        
        [HttpGet("Authors")]
        public async Task<IEnumerable<Author>> GetAuthors()
        {
            return await _bll.Authors.GetAllAsync();
        }

        [HttpGet("Books")]
        public async Task GetBooks([FromQuery] SearchRequestDTO searchRequestDTO)
        {
            await _bll.Searches.SearchBooksAsync(searchRequestDTO);
        }
    }
}