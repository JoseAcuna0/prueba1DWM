using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba1.src.DTOs
{
    public class UserDto
    {
        public required string RUT { get; set; }

        [StringLength(100, MinimumLength = 4)]
        public required string Name { get; set; }

        [EmailAddress(ErrorMessage = "El email no es valido")]
        public required string Email { get; set; }

        [RegularExpression(@"MASCULINO|FEMENINO|OTRO|PREFIERO NO DECIRLO")]
        public required string Genre { get; set; }

        public required DateTime Birthdate { get; set; }
    }
}