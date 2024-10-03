using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using apiPrueba1.src.Models;

namespace apiPrueba1.src.Data
{
    public class Seeder
    {
        public static async Task Seed(ApplicationDBContext context)
        {
            if (context.Users.Any())
            {
                return;
            }

            var user = new User
            {
                Rut = "12345678-1",
                Name = "Juan Pérez",
                Email = "juan.perez@example.com",
                Genre =  "masculino",
                Birthdate = new DateTime(1990, 7, 4)
            };
            await context.Users.AddAsync(user);

            var user2 = new User
            {
                Rut = "15367688-2",
                Name = "María González",
                Email = "maria.gonzalez@example.com",
                Genre =  "femenino",
                Birthdate = new DateTime(1985, 8, 2)
            };
            await context.Users.AddAsync(user2);

            var user3 = new User
            {
                Rut = "12345654-3",
                Name = "Pedro Pérez",
                Email = "maria.gonzalez@example.com",
                Genre =  "masculino",
                Birthdate = new DateTime(1980, 9, 1)
            };

            await context.Users.AddAsync(user3);

            var user4 = new User
            {
                Rut = "12345678-4",
                Name = "Ana Pérez",
                Email = "ana.perez@example.com",
                Genre =  "femenino",
                Birthdate = new DateTime(1975, 10, 3)
            };

            await context.Users.AddAsync(user4);

            var user5 = new User
            {
                Rut = "12345678-5",
                Name = "José Pérez",
                Email = "jose.perez@example.com",
                Genre =  "masculino",
                Birthdate = new DateTime(1970, 11, 5)
            };

            await context.Users.AddAsync(user5);

            var user6 = new User
            {
                Rut = "12345678-6",
                Name = "Luisa Pérez",
                Email = "luisa.perez@example.com",
                Genre =  "femenino",
                Birthdate = new DateTime(1965, 12, 6)
            };

            await context.Users.AddAsync(user6);

            var user7 = new User
            {
                Rut = "12345678-7",
                Name = "Carlos Pérez",
                Email = "carlos.perez@example.com",
                Genre =  "masculino",
                Birthdate = new DateTime(1960, 1, 7)
            };

            await context.Users.AddAsync(user7);

            var user8 = new User
            {
                Rut = "12345678-8",
                Name = "Sofía Pérez",
                Email = "sofia.perez@example.com",
                Genre =  "femenino",
                Birthdate = new DateTime(1955, 2, 8)
            };

            await context.Users.AddAsync(user8);

            var user9 = new User
            {
                Rut = "12345678-9",
                Name = "Jorge Pérez",
                Email = "jorge.perez@example.com",
                Genre =  "masculino",
                Birthdate = new DateTime(1950, 3, 9)
            };

            await context.Users.AddAsync(user9);

            var user10 = new User
            {
                Rut = "12345678-0",
                Name = "Marta Pérez",
                Email = "marta.perez@example.com",
                Genre =  "femenino",
                Birthdate = new DateTime(1945, 4, 10)
            };

            await context.Users.AddAsync(user10);

            await context.SaveChangesAsync();
        }
    }
}