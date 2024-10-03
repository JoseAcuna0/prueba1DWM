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

        
    }
}