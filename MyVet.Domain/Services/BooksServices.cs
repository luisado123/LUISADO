
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.Libreria;
using MyVet.Domain.Services.Interface;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class BooksServices : IBooksServices
    {
        #region Attribute
       
        private readonly IRestServices _restService;
        private readonly IConfiguration _config;
        #endregion


        #region Builder
        public BooksServices(IRestServices restService, IConfiguration config)
        {
          
            _restService = restService;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllBooks(string token)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodGetAllBooks").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.Success)
                response.Result = JsonConvert.DeserializeObject<List<ConsultarBooksDto>>(response.Result.ToString());

            return response;

        }

        public async Task<ResponseDto> DeleteBook(string token, int idBooks)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodDeleteBooks").Value;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("idBooks", idBooks);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            response.Success = true;
            if (response.Success)
                response.Message = "Se elminnó correctamente el libro";
            else
                response.Message = "Hubo un error al eliminar libro, por favor vuelva a intentalo";

            return response;
        }


        public async Task<ResponseDto> InsertBook(string token,InsertBooksDto booksDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodInsertBooks").Value;
            InsertBooksDto parameters = new InsertBooksDto()
            {
              IdAuthor=booksDto.IdAuthor,
              IdEditorial=booksDto.IdEditorial,
              Titulo=booksDto.Titulo, 
              Sinopsis=booksDto.Sinopsis
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);


            


            return response;
        }

        public async Task<ResponseDto> UpdateBook(string token, AlterBooksDto booksDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerBooks").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodUpdateBooks").Value;
            AlterBooksDto parameters = new AlterBooksDto()
            {
                IdBook= booksDto.IdBook,
                IdEditorial = booksDto.IdEditorial,
                IdAutor=booksDto.IdAutor,
                Titulo = booksDto.Titulo,
                Sinopsis = booksDto.Sinopsis
            };

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);





            return response;
        }


        #endregion

    }
}