using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Libreria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
   public interface IAutoresServices
    {
        Task<ResponseDto> GetAllAutores(string token);

        Task<ResponseDto> DeleteAutor(string token, int idAutor);

        Task<ResponseDto> InsertAutor(string token, InsertAutoresDto autores);

        Task<ResponseDto> UpdateAutor(string token, InsertAutoresDto autores);
    }
}
