using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using P_2E_2.Domain;
using P_2E_2.Services;

namespace P_2E_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlcController : ControllerBase
    {
        [HttpGet]
        public IActionResult CalcularVolumen(Alc al)
        {
            var alser = new AlServices();

            var tac = alser.CalcAlc(al.bebida, al.cantidad);

            if (tac == 0)
            {
                return Ok("Bebida no encontrada.");
            }

            var CantAlS = alser.CalcAlcSan(tac);

            var masa = alser.CalM(CantAlS);

            var vs = alser.CalVs(al.peso);

            var volal = alser.CVolAlcohol(masa, vs);

            var res = alser.Validar(volal);

            return Ok(res);
        }
    }
}
