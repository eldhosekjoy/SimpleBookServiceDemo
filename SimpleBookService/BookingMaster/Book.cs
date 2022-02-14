using SimpleBookService.Enum;
using System;

namespace SimpleBook.Demo.BookMaster
{
    public class Book
    {
        
        public int? Id { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }        
        public DateTime RegistrationTimeStamp { get; set; }
        public string Category { get; set; }
        public string Description { get; set; }
    }
}
