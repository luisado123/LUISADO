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
    public class BooksController : Controller
    {
        #region Attribute
        private readonly IBooksServices _booksServices;
        #endregion
        #region Buider
        public BooksController(IBooksServices  booksServices)
        {
            _booksServices = booksServices;

        }
        #endregion

        #region Methods
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllBooks()
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;


            ResponseDto response = await _booksServices.GetAllBooks(token);
            return Ok(response);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteBooks(int idBooks)
        {
            var user = HttpContext.User;
            string token = user.Claims.FirstOrDefault(x => x.Type == TypeClaims.Token).Value;




            ResponseDto response = await _booksServices.DeleteBook(token, idBooks);
            return Ok(response);
        }

        #endregion

    }

}

