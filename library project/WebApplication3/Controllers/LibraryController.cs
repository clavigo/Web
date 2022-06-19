using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using static WebApplication3.ClientsBase;

namespace WebApplication3.Controllers
{
    public class LibraryController : Controller
    {

        // GET: LibraryController/Create
        [HttpPost("LibraryController/CreateClient")]
        public ActionResult Create(string name, string birthDate, string city, string phone, string regDate)
        {

            Client a = new Client();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=0011;database=library"))
            {
                a.Name = name;
                a.BirthDate = birthDate;
                a.Phone = phone;
                a.RegisterDate = regDate;
                
                MySqlCommand command = new MySqlCommand("INSERT INTO reader(name, birthDate, phoneNumber, registerDate) VALUES(@name, @birthDate, @phone, @regDate)", con);
                command.Parameters.AddWithValue("@name", a.Name);
                command.Parameters.AddWithValue("@birthDate", a.BirthDate) ;
                command.Parameters.AddWithValue("@phone", a.Phone);
                command.Parameters.AddWithValue("@regDate", a.RegisterDate);
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }
            return Ok(a);
        }
        
        [HttpGet("LibraryController/GetClients")]
        public ActionResult GetClient()
        {
            List<Client> clients = new List<Client>();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=0011;database=library"))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand("SELECT * FROM reader", con);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    Client client = new Client();
                    client.id = reader.GetInt32(0);
                    client.Name = reader.GetString(1);
                    client.BirthDate = reader.GetString(2);
                    client.Phone = reader.GetString(3);
                    client.RegisterDate = reader.GetString(4);
                    clients.Add(client);
                }
                reader.Close();
            }
            return Ok(clients);
        }

        [HttpPost("LibraryController/AddBook")]
        public ActionResult AddBook(int Id, string name, string category, string author, string bookCond, string year, int reader)
        {

            BookBase book = new BookBase();
            using (MySqlConnection con = new MySqlConnection("server=localhost;user=root;password=0011;database=library"))
            {
                book.id = Id;
                book.Name = name;
                book.Category = category;
                book.Author = author;
                book.BookCondition = bookCond;
                book.Year = year;
                book.Reader = reader;

                MySqlCommand command = new MySqlCommand("INSERT INTO book VALUES(@idbooks, @bookName, @category, @author, @bookCondition, @releaseDate, @readId)", con);
                command.Parameters.AddWithValue("@idbooks", book.id);
                command.Parameters.AddWithValue("@bookName", book.Name);
                command.Parameters.AddWithValue("@category", book.Category);
                command.Parameters.AddWithValue("@author", book.Author);
                command.Parameters.AddWithValue("@bookCondition", book.BookCondition);
                command.Parameters.AddWithValue("@releaseDate", book.Year);
                command.Parameters.AddWithValue("@readId", book.Reader);                
                con.Open();
                command.ExecuteNonQuery();
                con.Close();

            }
            return Ok(book);
        }

        [HttpGet("LibraryController/GetBook")]
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

    }
}
