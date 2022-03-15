using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IEditorialServices
    {
        Task<ResponseDto> GetAllEditorial(string token);

        Task<ResponseDto> DeleteEditorial(string token,int idEditorial);

        Task<ResponseDto> InsertEditorial(string token,EditorialDto editorialDto);

        Task<ResponseDto> UpdateEditorial(string token,EditorialDto editorial);
    }
}
