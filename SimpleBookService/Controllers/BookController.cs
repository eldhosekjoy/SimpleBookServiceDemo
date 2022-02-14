using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SimpleBook.Demo.BookMaster;

namespace SimpleBook.Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookProvider BookProvider;
        private readonly IBookRepository BookRepository;

        public BookController(IBookProvider BookProvider,
            IBookRepository BookRepository)
        {
            this.BookProvider = BookProvider;
            this.BookRepository = BookRepository;
        }

        // GET: api/<BookController>
        [HttpGet]
        public async Task<IEnumerable<Book>> Get()
        {
            return await BookProvider.Get();
        }

        [HttpGet("Search")]
        public async Task<IEnumerable<Book>> Search()
        {
            return await BookProvider.Get();
        }

        // POST api/<BookController>
        [HttpPost("create")]
        public async Task<int> Create([FromBody] Book book)
        {
            
            return await BookRepository.Create(book);
        }

        // POST api/<BookController>
        [HttpPut("{bookid}/update")]
        public async Task<Book> Update([FromBody] Book Book)
        {
            return await BookRepository.Update(Book);
        }
    }
    public class Sample
    {
        public string Name { get; set; }
    }
         
}