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
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Http.HttpResults;

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
        public async Task<IResult> GetAllUsers(string? sort = null , string? gender = null)
        {

            if (sort != null && sort.ToLower() != "asc" && sort.ToLower() != "desc")
        {
            return TypedResults.BadRequest("El valor de 'sort' debe ser 'asc' o 'desc'.");
        }

        if  (gender != null && 
            gender.ToLower() != "masculino" && 
            gender.ToLower() != "femenino" && 
            gender.ToLower() != "otro" && 
            gender.ToLower() != "prefiero no decirlo")
        {
            return TypedResults.BadRequest("El valor de 'gender' no es válido.");
        }

            var users = await _userRepository.GetAll(sort, gender);
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

                var nowDate = DateOnly.FromDateTime(DateTime.Now);;
                if(user.Birthdate > nowDate)
                {
                    return TypedResults.BadRequest("Fecha de nacimiento inválida");
                }


                await _userRepository.Post(user);
                return TypedResults.Ok("Usuario creado");
            }
        }

        [HttpPut("{id}")]
        public async Task<IResult> UpdateUser(int id, UserDto updateUserDto)
        {
            var exist = await _userRepository.GetById(id);

            if (!exist)
            {
                return TypedResults.NotFound("Usuario no encontrado");
            }

            var exist2 = await _userRepository.ExistsByRut(updateUserDto.Rut);

            if (exist2)
            {

                return TypedResults.Conflict("El Rut ya existe");

            }

            var user = new User
            {
                Id = id,
                Rut = updateUserDto.Rut,
                Name = updateUserDto.Name,
                Email = updateUserDto.Email,
                Genre = updateUserDto.Genre,
                Birthdate = updateUserDto.Birthdate
            };

            var nowDate = DateOnly.FromDateTime(DateTime.Now);
            if (user.Birthdate > nowDate)
            {
                return TypedResults.BadRequest("Fecha de nacimiento inválida");
            }

            await _userRepository.Put(user);
            return TypedResults.Ok("Usuario actualizado");
        }

        [HttpDelete("{id}")]
        public async Task<IResult> DeleteUser(int id)
        {
            var exist = await _userRepository.GetById(id);

            if (!exist)
            {
                return TypedResults.NotFound("Usuario no encontrado");
            }
            await _userRepository.Delete(id);
            return TypedResults.Ok("Usuario eliminado");
        }
    }
}