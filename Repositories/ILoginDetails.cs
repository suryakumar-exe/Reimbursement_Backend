
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public interface ILoginDetails
    {
        Task<IEnumerable<LoginDetails>> Get(); //Get All Books
        Task<LoginDetails> Get(int id); //Get Book By ID
        Task<LoginDetails> Create(LoginDetails login);
        Task Update(LoginDetails login);
        Task Delete(int id);
    }
}
