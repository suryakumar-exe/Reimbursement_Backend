using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public class ReimbursementRepository : IReimbursement
    {
        private readonly ReimbursementContext _context;
        public ReimbursementRepository(ReimbursementContext context)
        {
            _context = context;
        }
        public async Task<Reimbursement> Create(Reimbursement login)
        {
         
            _context.reimbursements.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.reimbursements.FindAsync(id);
            _context.reimbursements.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Reimbursement>> Get()
        {
            return await _context.reimbursements.ToListAsync();
        }

        public async Task<Reimbursement> Get(int id)
        {
            return await _context.reimbursements.FindAsync(id);
        }

        public async Task Update(Reimbursement login)
        {
            _context.Entry(login).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
