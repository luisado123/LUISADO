using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyVet.Domain.Dto
{
    public class StateDto
    {

        [Key]
        public int IdState { get; set; }

        public string State { get; set; }
    }
}
