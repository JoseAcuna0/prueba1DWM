using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using apiPrueba1.src.Data;
using apiPrueba1.src.Models;
using apiPrueba1.src.Interfaces;
using apiPrueba1.src.DTOs;

namespace apiPrueba1.src.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet("")]
        public async Task<IResult> GetAllUsers()
        {
            var users = await _userRepository.GetAll();
            return TypedResults.Ok(users);
        }

        [HttpPost("")]
        public async Task<IResult> CreateUser(UserDto createUserDto)
        {

            var exist = await _userRepository.ExistsByRut(createUserDto.Rut);

            if (exist)
            {

                return TypedResults.Conflict("El Rut ya existe");

            }


            else
            {
                var user = new User
                {
                    Rut = createUserDto.Rut,
                    Name = createUserDto.Name,
                    Email = createUserDto.Email,
                    Genre = createUserDto.Genre,
                    Birthdate = createUserDto.Birthdate
                };
                await _userRepository.Post(user);
                return TypedResults.Ok("Usuario creado");
            }

            
        
        }

    }
}