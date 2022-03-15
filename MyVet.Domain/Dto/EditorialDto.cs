using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
  public class EditorialDto
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "la Sede es requerida")]
        [MaxLength(300)]
        [Display(Name = "Direction")]
        public string Sede { get; set; }

        [Required(ErrorMessage = "El nombre de la Editorial es Obligatorio")]
        [MaxLength(100)]
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
