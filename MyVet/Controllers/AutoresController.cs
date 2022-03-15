using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using MyVet.Handlers;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace MyVet.Controllers
{

    [Authorize]
    [TypeFilter(typeof(CustomExceptionHandler))]
    public class AutoresController : Controller
    {
        #region Attribute
        private readonly IAutoresServices _autoresServices;
        #endregion
        #region Buider
        public AutoresController(IAutoresServices autoresServices)
        {
            _autoresServices = autoresServices;

        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAutores()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;


            ResponseDto response = await _autoresServices.GetAllAutores(token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAutor(int idAutor)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;




            ResponseDto response = await _autoresServices.DeleteAutor(token, idAutor);
            return Ok(response);
        }

        #endregion

    }
}
