using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto.Libreria
{
    public class InsertBooksDto
    {
       public int IdAuthor { get; set; }



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
