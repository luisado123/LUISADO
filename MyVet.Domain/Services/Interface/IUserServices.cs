using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
  public interface IUserServices
    {
        #region Auth
        Task<ResponseDto> Login(UserDto user);
       
        #endregion
          
         Task<ResponseDto> GetAllUsers(string token);
    }
}
