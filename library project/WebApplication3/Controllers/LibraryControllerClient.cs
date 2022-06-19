using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static WebApplication3.ClientsBase;

namespace WebApplication3.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LibraryControllerClient : ControllerBase
    {

        [HttpGet("GetBook")]
        public ActionResult GetBooks()
        {
            List<BookBase> books = new List<BookBase>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=0011;database=library"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT idbooks, bookName, category, author, bookCondition, releaseDate FROM book", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    BookBase book = new BookBase();
                    book.id = reader.GetInt32(0);
                    book.Name = reader.GetString(1);
                    book.Category = reader.GetString(1);
                    book.Author = reader.GetString(3);
                    book.BookCondition = reader.GetString(4);
                    book.Year = reader.GetString(5);
                    //book.Reader = reader.GetInt32(6);
                    books.Add(book);
                }
                reader.Close();
            }
            return Ok(books);
        }
    };

        
}