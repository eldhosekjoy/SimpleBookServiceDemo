using Dapper;
using Microsoft.Data.Sqlite;
using System.Linq;

namespace SimpleBook.Demo.Database
{
    public class DatabaseBootstrap : IDatabaseBootstrap
    {
        private readonly DatabaseConfig databaseConfig;

        public DatabaseBootstrap(DatabaseConfig databaseConfig)
        {
            this.databaseConfig = databaseConfig;
        }

        public void Setup()
        {
            using var connection = new SqliteConnection(databaseConfig.Name);

            var table = connection.Query<string>("SELECT name FROM sqlite_master WHERE type='table' AND name = 'Books';");
            var tableName = table.FirstOrDefault();
            if (!string.IsNullOrEmpty(tableName) && tableName == "Books")
                return;

            connection.Execute("Create Table Books (" +
                "BookName VARCHAR(100) NOT NULL," +
                "Author VARCHAR(100) NOT NULL," +
                "RegistrationTimeStamp DATE NULL," +
                "Category VARCHAR(100) NOT NULL," +
                "Description VARCHAR(1000) NULL);");
        }
    }
}
