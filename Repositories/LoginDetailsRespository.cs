
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication4.Models;

namespace WebApplication4.Repositories
{
    public class LoginDetailsRespository : ILoginDetails
    {
        private readonly LoginDetailsContext _context;
        public LoginDetailsRespository(LoginDetailsContext context)
        {
            _context = context;
        }
        public async Task<LoginDetails> Create(LoginDetails login)
        {
            _context.LoginDetailsDB.Add(login);
            await _context.SaveChangesAsync();
            return login;
        }

        public async Task Delete(int id)
        {
            var bookToDelete = await _context.LoginDetailsDB.FindAsync(id);
            _context.LoginDetailsDB.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<LoginDetails>> Get()
        {
            return await _context.LoginDetailsDB.ToListAsync();
        }

        public async Task<LoginDetails> Get(int id)
        {
            return await _context.LoginDetailsDB.FindAsync(id);
        }

        public async Task Update(LoginDetails login)
        {
            _context.Entry(login).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
