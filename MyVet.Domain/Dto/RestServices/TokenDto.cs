using System;
using System.Collections.Generic;
using System.Text;

namespace MyVet.Domain.Dto.RestServices
{
   public class TokenDto
    {
        public string Token { get; set; }
        public double Expiration { get; set; }
    }
}
