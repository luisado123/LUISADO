using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class BookDto
    {

        [Key]
        public int IdBook { get; set; }



        [Required(ErrorMessage = "la Sinopsis es requerida")]
        [MaxLength(300)]
        [Display(Name = "Description")]
        public string Sinopsis { get; set; }


        [Required(ErrorMessage = "El Titulo del Libro es Obligatorio")]
        [MaxLength(100)]
        [Display(Name = "BookName")]
        public string Titulo { get; set; }




        public int IdEditorial { get; set; }
    }
}
