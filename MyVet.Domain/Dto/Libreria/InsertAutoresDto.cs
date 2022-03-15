using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Libreria
{
    public class InsertAutoresDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "los nombres Son requeridos")]
        [MaxLength(300)]
        [Display(Name = "Nombre")]
        public string nombres { get; set; }

        [Required(ErrorMessage = "Los apellidos son Obligatorios")]
        [MaxLength(100)]
        [Display(Name = "Apellidos")]
        public string Apellidos { get; set; }
    }
}
