
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication4.Models;
using WebApplication4.Repositories;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReimbursementController : ControllerBase
    {
        private readonly IReimbursement _loginRepository;
        private readonly ILogger<ReimbursementController> _logger;
        public ReimbursementController(IReimbursement loginRepository, ILogger<ReimbursementController> logger)
        {
            _loginRepository = loginRepository;
            _logger = logger;
        }
        [HttpGet]
        [Route("FetchAllReimbursement")]
        public async Task<IEnumerable<Reimbursement>> GetDetails() //Get All Books
        {

            var bookss = await _loginRepository.Get();

            return bookss;


        }
        
        [HttpGet("GetReimbursementById/{id}")]

        public async Task<Reimbursement> GetDetails(int id) //Get book by id
        {
            return await _loginRepository.Get(id);
        }
        [HttpPost]
        [Route("CreateReimbursement/attach")]
        public async Task<IActionResult> Post2(IFormFile file)
        {
            if (file.Length <= 0)
                return BadRequest("Empty file");

            //Strip out any path specifiers (ex: /../)
            var originalFileName = Path.GetFileName(file.FileName);

            //Create a unique file path
            var uniqueFileName = Path.GetRandomFileName();
            var uniqueFilePath = Path.Combine(@"C:\Users\KumarSu\source\repos\WebApplication4\Uploads\", originalFileName);

            //Save the file to disk
            using (var stream = System.IO.File.Create(uniqueFilePath))
            {
                await file.CopyToAsync(stream);
            }

            return Ok($"Saved file {originalFileName} with size {file.Length / 1024m:#.00} KB using unique name {uniqueFileName}");
        }

        /*public string Post()
        {
            var file = HttpContext.Request.Form.Files.Count>0 ? HttpContext.Request.Form.Files[0] : null;
            if(file == null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var path = Path.Combine(HttpContext)
            }
            return "sucess";
        }*/

        [HttpPost]
        [Route("CreateReimbursement")]
        public async Task<ActionResult<Reimbursement>> PostDetails([FromBody] Reimbursement book) //create book
        {
  
            var newBook = await _loginRepository.Create(book);

            return CreatedAtAction(nameof(GetDetails), new { id = newBook.Id }, newBook);

        }
        [HttpPut]
        [Route("UpdateReimbursementById/{id}")]
        public async Task<ActionResult> putDetails(int id, [FromBody] Reimbursement book) //update book
        {
            if (id != book.Id)
            {
                return BadRequest();
            }
            await _loginRepository.Update(book);
            return NoContent();
        }

        [HttpDelete("DeleteReimbursement/{id}")]
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
