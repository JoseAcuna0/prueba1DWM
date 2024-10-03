using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace apiPrueba1.src.DTOs
{
    public class UserDto
    {

        [RegularExpression(@"^[0-9]{1,8}-[0-9K]{1}$")]
        public required string Rut { get; set; }

        [StringLength(100, MinimumLength = 4)]
        public required string Name { get; set; }

        [EmailAddress(ErrorMessage = "El email no es valido")]
        public required string Email { get; set; }

        [RegularExpression(@"masculino|femenino|otro|prefiero no decirlo")]
        public required string Genre { get; set; }

        public required DateOnly Birthdate { get; set; }
    }
}