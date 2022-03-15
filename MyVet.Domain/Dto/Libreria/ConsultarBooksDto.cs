using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.Libreria
{
   public class ConsultarBooksDto
    {
        public int idAutor { get; set; }
        public int idLibro { get; set; }

        public int idEditorial { get; set; }

        public string nameAutor { get; set; }


        public string titulo { get; set; }
        public string sinopsis { get; set; }

        public string editorial { get; set; }

    }
}
