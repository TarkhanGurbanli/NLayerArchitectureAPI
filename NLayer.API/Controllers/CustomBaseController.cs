using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.Core.DTOs;

namespace NLayer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomBaseController : ControllerBase
    {
        [NonAction]
        public IActionResult CreateActionResult<T>(CustomResponseDTO<T> respons)
        {
            if (respons.StatusCode == 204)
                return new ObjectResult(null)
                {
                    StatusCode = respons.StatusCode,
                };

            return new ObjectResult(respons)
            {
                StatusCode = respons.StatusCode
            };
        }
    }
}
