using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using apiPrueba1.src.Models;

namespace apiPrueba1.src.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();

        Task<bool> ExistsByRut(string rut);

        Task<User> Post(User user);

        Task<User> Put(User user);

        Task<bool> GetById(int id);

        Task<User?> Delete(int id);
    }
}