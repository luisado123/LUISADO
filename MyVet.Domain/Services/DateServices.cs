using Common.Utils.Enums;
using Infraestructure.Core.UnitOfWork.Interface;
using Infraestructure.Entity.Model.Master;
using Infraestructure.Entity.Vet;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVet.Domain.Services
{
    public class DateServices : IDateServices
    {
        #region Attributes
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Builder
        public DateServices(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        #endregion

        public List<DateDto> GetAllMyDates(int idUser)
        {
            var dates = _unitOfWork.DatesRepository.FindAll(p => p.PetEntity.UserPetEntity.IdUser == idUser,
                                                           p => p.PetEntity.UserPetEntity,
                                                           p => p.ServicesEntity,
                                                           p => p.StateEntity).ToList();
            List<DateDto> list = dates.Select(x => new DateDto
            {
                Id = x.Id,
                Date = x.Date,
                Contact = x.Contact,
                IdPet = x.IdPet,
                IdService = x.IdServices,
                IdState = x.IdState,
                pet = x.PetEntity.Name,
                Services = x.ServicesEntity.Services,
                State = x.StateEntity.State,
                Description = x.Description,
            }).ToList();

            return list;
        }



        public List<ServiceDto> GetAllServices()
        {
            List<ServicesEntity> services = _unitOfWork.ServicesRepository.GetAll().ToList();

            List<ServiceDto> list = services.Select(x => new ServiceDto
            {
                IdService = x.Id,
                Services = x.Services,

            }).ToList();

            return list;
        }
        public List<StateDto> GetAllState()
        {
            List<StateEntity> state = _unitOfWork.StateRepository.GetAll().ToList();

            List<StateDto> list = state.Select(x => new StateDto
            {
                IdState = x.IdState,
                State = x.State,

            }).ToList();

            return list;

        }


        public async Task<bool> InsertDatesAsync(DateDto dates)
        {
            DatesEntity datesEntity = new DatesEntity()
            {
                Date = dates.Date,
                Contact = dates.Contact,
                IdServices = dates.IdService,
                IdPet = dates.IdPet,
                Description = dates.Description,
                IdState = (int)Enums.State.CitaActiva
            };

            _unitOfWork.DatesRepository.Insert(datesEntity);
            return await _unitOfWork.Save() > 0;
        }

        public async Task<ResponseDto> DeleteDatesync(int idDate)
        {
            ResponseDto response = new ResponseDto();

            _unitOfWork.DatesRepository.Delete(idDate);
            response.Success = await _unitOfWork.Save() > 0;
            if (response.Success)
                response.Message = "Se elminnó correctamente la cita";
            else
                response.Message = "Hubo un error al eliminar la cita, por favor vuelva a intentalo";

            return response;
        }

        public async Task<bool> UpdateDateAsync(DateDto dates)
        {
            bool result = false;

            DatesEntity datesEntity = _unitOfWork.DatesRepository.FirstOrDefault(x => x.Id == dates.Id);
            if (datesEntity != null)
            {
                datesEntity.Date = dates.Date;
                datesEntity.Contact = dates.Contact;
                datesEntity.IdServices =dates.IdService;
                datesEntity.IdPet=dates.IdPet;
                datesEntity.Description = dates.Description;
               

                _unitOfWork.DatesRepository.Update(datesEntity);

                result = await _unitOfWork.Save() > 0;
            }

            return result;
        }
    }
}
