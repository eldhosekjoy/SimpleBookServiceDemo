using Dapper;
using Microsoft.Data.Sqlite;
using SimpleBook.Demo.Database;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBook.Demo.BookMaster
{
    public class BookProvider : IBookProvider
    {
        private readonly DatabaseConfig databaseConfig;

        public BookProvider(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<IEnumerable<Book>> Get()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            return await connection.QueryAsync<Book>("SELECT rowid AS Id, BookName,Author,Category, Description FROM Books;");
        }
    }
}
