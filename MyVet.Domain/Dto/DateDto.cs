using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class DateDto
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "La fecha es requerida")]
        [Display(Name = "Fecha Cita")]
        public DateTime Date { get; set; }

      
     


        [Required(ErrorMessage = "El medio de Contacto es requerido")]
        [MaxLength(100)]
        [Display(Name = "Contacto")]
        public string Contact { get; set; }


        [Required(ErrorMessage = "La descripcion es requerida")]
        [MaxLength(100)]
        [Display(Name = "Description")]
        public string Description { get; set; }


        public string pet { get; set; }
        public int  IdState { get; set; }
        public string Services { get; set; }

        public string State { get; set; }
        public int IdPet { get; set; }
        public int IdService { get; set; }

   
    }
}