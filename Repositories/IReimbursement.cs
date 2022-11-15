using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public interface IReimbursement
    {
        Task<IEnumerable<Reimbursement>> Get(); //Get All Books
        Task<Reimbursement> Get(int id); //Get Book By ID
        Task<Reimbursement> Create(Reimbursement login);
        Task Update(Reimbursement login);
        Task Delete(int id);
    }
}
