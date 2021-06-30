using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ConsoleMessanger;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessengerController : ControllerBase
    {
        private static List<Message> listOfMessages = new List<Message>();
        // GET: api/Messanger/5
        [HttpGet("{id:int}", Name = "Get")]
        public string Get(int id)
        {
            string outputRow = "Not found";
            if ((id < listOfMessages.Count) && (id >= 0))
            {
                outputRow = JsonConvert.SerializeObject(listOfMessages[id]);
            }
            Console.WriteLine($"Запрошено сообщение № {id} : {outputRow}");
            return outputRow;
        }

        // POST: api/Messanger
        [HttpPost]
        public IActionResult SendMessage([FromBody] Message message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            listOfMessages.Add(message);
            Console.WriteLine($"Всего сообщений {listOfMessages.Count}, Посланное сообщение {message}");
            return new OkResult();
        }
    }
}
