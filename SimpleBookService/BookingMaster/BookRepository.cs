using Dapper;
using Microsoft.Data.Sqlite;
using SimpleBook.Demo.Database;
using System.Threading.Tasks;
using System.Linq;
using System.Collections.Generic;

namespace SimpleBook.Demo.BookMaster
{
    public class BookRepository : IBookRepository
    {
        private readonly DatabaseConfig databaseConfig;

        public BookRepository(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public async Task<int> Create(Book Book)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            //The command should be replaced with Stored Procedures 
            //for better security 
            var result= connection.ExecuteScalarAsync<int>("INSERT INTO Books (BookName, Author,RegistrationTimeStamp,Category, Description)" +
                "VALUES (@BookName, @Author,@RegistrationTimeStamp,@Category, @Description);" +
                " SELECT last_insert_rowid() FROM Books;", Book);
            return await result;

        }
        public async Task<Book> Update(Book Book)
        {
            using var connection = new SqliteConnection(databaseConfig.Name);
            //The command should be replaced with Stored Procedures 
            //for better security 
            var result= connection.ExecuteScalarAsync<Book>("UPDATE Books SET BookName=@BookName,Author=@Author" +
                ",Category=@Category, Description=@Description " +
                " WHERE rowid=@Id;", Book);
               
            return await result;
        }
    }
}
