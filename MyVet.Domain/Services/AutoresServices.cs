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
    public class AutoresServices : IAutoresServices
    {
        #region Attribute
       
        private readonly IRestServices _restService;
        private readonly IConfiguration _config;
        #endregion


        #region Builder
        public AutoresServices(IRestServices restService, IConfiguration config)
        {

            _restService = restService;
            _config = config;
         
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllAutores(string token)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerAutores").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodGetAllAutores").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.Success)
                response.Result = JsonConvert.DeserializeObject<List<AutoresDto>>(response.Result.ToString());

            return response;

        }

        public async Task<ResponseDto> DeleteAutor(string token, int idAutor)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerAutores").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodDeleteAutor").Value;
            Dictionary<string, int> parameters = new Dictionary<string, int>();
            parameters.Add("idAutor", idAutor);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            response.Success = true;
            if (response.Success)
                response.Message = "Se elminnó correctamente el autor";
            else
                response.Message = "Hubo un error al eliminar el autor, por favor vuelva a intentalo";

            return response;
        }


        public async Task<ResponseDto> InsertAutor(string token, InsertAutoresDto autorDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerAutores").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodInsertAutor").Value;
            InsertAutoresDto parameters = new InsertAutoresDto()
            {
               nombres=autorDto.nombres,
               Apellidos=autorDto.Apellidos
            };


            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);



            //response.Result = JsonConvert.DeserializeObject<List<InsertEditorialDto>>(response.Result.ToString());


            return response;
        }


        public async Task<ResponseDto> UpdateAutor(string token, InsertAutoresDto autoresDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerAutores").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodUpdateAutor").Value;
            InsertAutoresDto parameters = new InsertAutoresDto()
            {
              Id=autoresDto.Id,
              nombres=autoresDto.nombres,
              Apellidos=autoresDto.Apellidos

            };


            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);




            return response;
        }

        #endregion
    }
}
