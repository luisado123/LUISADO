using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{
    [Authorize]
    public class DatesController : Controller
    {

        #region Attribute
        private readonly IDateServices _dateServices;
        #endregion

        #region Buider
        public DatesController(IDateServices dateServices)
        {
            _dateServices = dateServices;
        }
        #endregion



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult GetAllMyDates()
        {
            var user = HttpContext.User;
            string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;

            List<DateDto> list = _dateServices.GetAllMyDates(Convert.ToInt32(idUser));
            return Ok(list);
        }
        [HttpGet]
        public IActionResult GetAllState()
        {
            List<StateDto> response = _dateServices.GetAllState();
            return Ok(response);
        }

        [HttpGet]
        public IActionResult GetAllServices()
        {
            List<ServiceDto> response = _dateServices.GetAllServices();
            return Ok(response);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteDate(int idDate)
        {
            ResponseDto response = await _dateServices.DeleteDatesync(idDate);
            return Ok(response);
        }





        [HttpPost]
        public async Task<IActionResult> InsertDate(DateDto dates)
        {
            //var user = HttpContext.User;
           // string idUser = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.IdUser).Value;
           // datee.IdPet = Convert.ToInt32(idUser);

            bool response = await _dateServices.InsertDatesAsync(dates);
            return Ok(response);
        }
       
        [HttpPut]
        public async Task<IActionResult> UpdateDate(DateDto dates)
        {
            bool response = await _dateServices.UpdateDateAsync(dates);
            return Ok(response);
        }

    }


}
