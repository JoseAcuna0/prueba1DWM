using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPrueba1.src.Data;
using apiPrueba1.src.Interfaces;
using apiPrueba1.src.Models;
using Microsoft.EntityFrameworkCore;

namespace apiPrueba1.src.Repository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDBContext _dataContext;


        public UserRepository(ApplicationDBContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<User>> GetAll()
        {
            return await _dataContext.Users.ToListAsync();
        }

        public async Task<bool> ExistsByRut(string rut)
        {
            return await _dataContext.Users.AnyAsync(x => x.Rut == rut);
        }

        public async Task<User> Post(User user)
        {
            await _dataContext.Users.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }

        public async Task<User> Put(User user)
        {
            _dataContext.Users.Update(user);
            await _dataContext.SaveChangesAsync();
            return user;
        }
        
        public async Task<bool> GetById(int id)
        {
            return await _dataContext.Users.AnyAsync(x => x.Id == id);
        }

        public async Task<User?> Delete(int id)
        {
            var user = await _dataContext.Users.FindAsync(id);
            if (user != null)
            {
                _dataContext.Users.Remove(user);
                await _dataContext.SaveChangesAsync();
            }
            return user;
        }
        
    }
}