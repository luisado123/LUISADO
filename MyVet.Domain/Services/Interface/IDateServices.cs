using MyVet.Domain.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services.Interface
{
    public interface IDateServices
    {

        List<DateDto> GetAllMyDates(int idUser);
        
        List<ServiceDto> GetAllServices();

        List<StateDto> GetAllState();
        Task<bool> InsertDatesAsync(DateDto dates);
        Task<ResponseDto> DeleteDatesync(int idDate);
        Task<bool> UpdateDateAsync(DateDto dates);





    }
}

