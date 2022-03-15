using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Libreria;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IBooksServices
    {
        Task<ResponseDto> GetAllBooks(string token);

        Task<ResponseDto> DeleteBook(string token, int idBooks);
        Task<ResponseDto> InsertBook(string token, InsertBooksDto booksDto);

        Task<ResponseDto> UpdateBook(string token, AlterBooksDto booksDto);
    }
}
