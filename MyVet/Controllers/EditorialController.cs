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
    public class EditorialController : Controller
    {
        #region Attribute
        private readonly IEditorialServices _editorialServices;
        #endregion
        #region Buider
        public EditorialController(IEditorialServices editorialServices)
        {
            _editorialServices = editorialServices;

        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEditorial()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;


            ResponseDto response = await _editorialServices.GetAllEditorial(token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteEditorial(int idEditorial)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;


           

            ResponseDto response = await _editorialServices.DeleteEditorial(token,idEditorial);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> InsertEditorial(string nombre,string sede)
        {
            var user=HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;
            ResponseDto response = await _editorialServices.InsertEditorial(token,nombre,sede);
            return Ok(response);
        }


        #endregion

    }
}
