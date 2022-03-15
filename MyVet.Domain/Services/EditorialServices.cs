using Common.Utils.RestServices;
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
    public class EditorialServices:IEditorialServices
    {
        #region Attribute
       
        private readonly IRestServices _restService;
        private readonly IConfiguration _config;
        #endregion


        #region Builder
        public EditorialServices(IRestServices restService, IConfiguration config)
        {
         
            _restService = restService;
            _config = config;
        }
        #endregion

        #region Methods
        public async Task<ResponseDto> GetAllEditorial(string token)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodGetAllEditoriales").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.Success)
                response.Result = JsonConvert.DeserializeObject<List<EditorialDto>>(response.Result.ToString());

            return response;

        }

        public async Task<ResponseDto> DeleteEditorial(string token,int idEditorial)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodDeleteEditoriales").Value;
            Dictionary<string,int> parameters = new Dictionary<string,int>();
            parameters.Add("idEditorial", idEditorial);

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);
           
         
           ResponseDto response= await _restService.DeleteRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            response.Success = true;
            if (response.Success)
              response.Message = "Se elminnó correctamente la Editorial";
            else
              response.Message = "Hubo un error al eliminar la Editorial, por favor vuelva a intentalo";

            return response;
        }


        public async Task<ResponseDto> InsertEditorial(string token,EditorialDto editorialDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodInsertEditorial").Value;
            EditorialDto parameters = new EditorialDto()
            {
                Name = editorialDto.Name,
                Sede = editorialDto.Sede
            };
              

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
          
            
            
                //response.Result = JsonConvert.DeserializeObject<List<InsertEditorialDto>>(response.Result.ToString());


            return response;
        }


        public async Task<ResponseDto> UpdateEditorial(string token,EditorialDto editorialDto)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerEditorial").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodUpdateEditoriales").Value;
            EditorialDto parameters = new EditorialDto()
            {
           Id = editorialDto.Id,
             Name = editorialDto.Name,
             Sede = editorialDto.Sede   

            };
           

            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);


            ResponseDto response = await _restService.PutRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

         


            return response;
        }
        #endregion
    }
}
