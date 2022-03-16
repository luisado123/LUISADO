using Common.Utils.RestServices;
using Common.Utils.RestServices.Interface;
using Microsoft.Extensions.Configuration;
using MyVet.Domain.Dto;
using MyVet.Domain.Dto.RestServices;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class UserServices:IUserServices
    {
        #region Attribute
  
        private readonly IRestServices _restService;
        private readonly IConfiguration _config;
        #endregion

        #region Builder
        public UserServices( IRestServices restService, IConfiguration config)
        {
           
            _restService = restService;
            _config = config;
        }
        #endregion

        #region authentication

        public async Task<ResponseDto> Login(UserDto user)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerAuthentication").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodLogin").Value;

            LoginDto parameters = new LoginDto()
            {
                Password = user.Password,
                UserName = user.UserName
            };
            Dictionary<string, string> headers = new Dictionary<string, string>();
            ResponseDto resultToken = await _restService.PostRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);

            return resultToken;

            //ResponseDto response = new ResponseDto();
            //UserEntity result = _unitOfWork.UserRepository.FirstOrDefault(x => x.Email == user.UserName
            //                                                                && x.Password == user.Password,
            //                                                               r => r.RolUserEntities);
            //if (result == null)
            //{
            //    response.Message = "Usuario o contraseña inválida!";
            //    response.IsSuccess = false;
            //}
            //else
            //{
            //    response.Result = result;
            //    response.IsSuccess = true;
            //    response.Message = "Usuario autenticado!";
            //}

            //return response;
        }

        #endregion

#region obtener

        public async Task<ResponseDto> GetAllUsers(string token)
        {
            string urlBase = _config.GetSection("ApiMyVet").GetSection("UrlBase").Value;
            string controller = _config.GetSection("ApiMyVet").GetSection("ControlerUsers").Value;
            string method = _config.GetSection("ApiMyVet").GetSection("MethodGetUsers").Value;


            Dictionary<string, string> parameters = new Dictionary<string, string>();
            Dictionary<string, string> headers = new Dictionary<string, string>();
            headers.Add("Token", token);

            ResponseDto response = await _restService.GetRestServiceAsync<ResponseDto>(urlBase, controller, method, parameters, headers);
            if (response.Success)
                response.Result = JsonConvert.DeserializeObject<List<ConsultarUsuariosDto>>(response.Result.ToString());

            return response;

        }

        #endregion



        
    }
}
