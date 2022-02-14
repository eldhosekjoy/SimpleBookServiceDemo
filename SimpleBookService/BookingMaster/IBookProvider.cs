using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBook.Demo.BookMaster
{
    public interface IBookProvider
    {
        Task<IEnumerable<Book>> Get();
    }
}