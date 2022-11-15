
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Collections;  
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginDetailsController : ControllerBase
    {
        private readonly ILoginDetails _loginRepository;
        private readonly ILogger<LoginDetailsController> _logger;
        public LoginDetailsController(ILoginDetails loginRepository, ILogger<LoginDetailsController> logger)
        {
            _loginRepository = loginRepository;
            _logger = logger;
        }

        [HttpGet]
        [Route("FetchAllLogins")]
        public async Task<IEnumerable<LoginDetails>> GetDetails() //Get All Books
        {
            var bookss = await _loginRepository.Get();

            return bookss;


        }
        [HttpPost]
        [Route("CreateFile")]
        public void Fs(string content)
        {
            if (!System.IO.File.Exists(@"\JMLogs\log.txt"))
            {
                FileStream stream = new FileStream(@"C:\JMLogs\log.txt", FileMode.OpenOrCreate);
                // Create a StreamWriter from FileStream  
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(content+"\n");
                }

            }
            else
            {
                System.IO.File.AppendAllText(@"C:\JMLogs\log.txt", content+"\n");
            }
            
               
        }

        [HttpGet("GetLoginById/{id}")]

        public async Task<LoginDetails> GetDetails(int id) //Get book by id
        {
            return await _loginRepository.Get(id);
        }
        [HttpPost]
        [Route("CreateLogin")]
        public async Task<ActionResult<LoginDetails>> PostDetails([FromBody] LoginDetails book) //create book
        {
            var newBook = await _loginRepository.Create(book);

            return CreatedAtAction(nameof(GetDetails), new { id = newBook.Id }, newBook);

        }
        [HttpPut]
        [Route("UpdateLogin/{id}")]
        public async Task<ActionResult> putDetails(int id, [FromBody] LoginDetails book) //update book
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await _loginRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("DeleteLogin/{id}")]
        /* [Route("DeleteBook")]*/
        public async Task<ActionResult> delete(int id) //delete
        {
            var booktoDelete = await _loginRepository.Get(id);
            if (booktoDelete == null)
            {
                return NotFound();
            }
            await _loginRepository.Delete(booktoDelete.Id);
            return NoContent();
        }
    }
}
