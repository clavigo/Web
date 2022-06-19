using MySql.Data.MySqlClient;

namespace WebApplication3
{
    public class BookBase
    {
        public const string Book = "Book";

        public int? id { get; set; }
        public string? Name { get; set; }
        public string? Category { get; set; }
        public string? Author { get; set; }
        public string? BookCondition { get; set; }
        public string? Year { get; set; }
        public int? Reader { get; set; }
    }


}
