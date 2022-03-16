using Microsoft.AspNetCore.Mvc;
using MyVet.Domain.Dto;
using MyVet.Domain.Services.Interface;
using System.Linq;
using System.Threading.Tasks;
using static Common.Utils.Constant.Const;

namespace LibreriaMVC.Controllers
{
    public class UsuariosController : Controller
    {
        #region Attribute
        private readonly IUserServices _userServices;
        #endregion
        #region Buider
        public UsuariosController(IUserServices usersServices)
        {
            _userServices= usersServices;

        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsuarios()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;


            ResponseDto response = await _userServices.GetAllUsers(token);
            return Ok(response);
        }
        #endregion
    }
}
