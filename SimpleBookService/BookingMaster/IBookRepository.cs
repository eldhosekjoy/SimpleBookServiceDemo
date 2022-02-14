using System.Threading.Tasks;

namespace SimpleBook.Demo.BookMaster
{
    public interface IBookRepository
    {
        Task<int> Create(Book Book);
        Task<Book> Update(Book Book);
    }
}