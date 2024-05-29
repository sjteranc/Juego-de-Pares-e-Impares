using Microsoft.AspNetCore.Mvc;
using System;

namespace ParImparGame.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ParImparController : ControllerBase
    {
        [HttpPost]
        public ActionResult<string> Jugar(Jugada jugada)
        {
            Random random = new Random();
            int dado1 = random.Next(1, 7);
            int dado2 = random.Next(1, 7);
            int suma = dado1 + dado2;

            string resultado = (suma % 2 == 0) ? "par" : "impar";

            if (resultado == jugada.Eleccion)
                return $"Ganaste! La suma de los dados fue {suma} y es {resultado}.";
            else
                return $"Perdiste. La suma de los dados fue {suma} y es {resultado}.";
        }
    }

    public class Jugada
    {
        public string Eleccion { get; set; }
    }
}
