using CopaDoMundo.Domain.Auxiliar;
using Microsoft.AspNetCore.Mvc;

namespace CopaDoMundo.Api.Auxiliar
{
    public abstract class ControllerApi : ControllerBase
    {
        protected new IActionResult Response<T>(ResultViewModel<T> result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected new IActionResult Response(ResultViewBaseModel result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
