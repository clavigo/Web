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
            a.Name = name;
            a.BirthDate = birthDate;
            a.Phone = phone;
            a.RegisterDate = regDate;
            return Ok(a);
        }
        
        [HttpGet("LibraryController/GetClient")]
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
                    Client a = new Client();
                    a.id = reader.GetInt32(0);
                    a.Name = reader.GetString(1);
                    a.BirthDate = reader.GetString(2);
                    a.Phone = reader.GetString(3);
                    a.RegisterDate = reader.GetString(4);
                    clients.Add(a);
                }
                reader.Close();
            }
            return Ok(clients);
        }

        // POST: LibraryController/Create
        //[HttpPost("create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        
        [HttpGet("rand/{id}")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                //Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
