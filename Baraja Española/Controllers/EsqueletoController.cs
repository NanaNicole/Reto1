using Baraja_Española.Services;
using Microsoft.AspNetCore.Mvc;

namespace Baraja_Española.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EsqueletoController: ControllerBase
    {
        [HttpGet("cargar-informacion")]
        public IActionResult CargarInformacion()
        {
            try
            {
                Esqueleto esqueleto = new Esqueleto();
                for (int numero = 0; numero < 206; numero++)
                {
                    if (numero % 2 == 0)
                    {
                        esqueleto.CargarInformacion(numero, "Húmero", 2.7 + numero / 4, 1.5 + numero, 33 + numero, numero);
                    }else
                    {
                        esqueleto.CargarInformacion(numero, "Fémur", 4.7+numero/2, 1.7+numero, 50+numero/2, numero+1);
                    }
                }
                esqueleto.GuardarEnArchivo(esqueleto);
                return Ok("Baraja inicial generada correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al generar la baraja: {ex.Message}");
            }
        }

        [HttpGet("imprimir")]
        public IActionResult OrdenarEImprimir(string opcion)
        {
            try
            {
                Esqueleto esqueleto = ObtenerEsqueleto();
                esqueleto.OrdenarEImprimir(opcion);
                esqueleto.GuardarEnArchivo(esqueleto);
                return Ok("Esqueleto impreso correctamente");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al imprimir la baraja: {ex.Message}");
            }
        }

        private Esqueleto ObtenerEsqueleto()
        {
            Esqueleto esqueleto = new Esqueleto();
            esqueleto.CargarDesdeArchivo("esqueleto.txt");
            return esqueleto;
        }
    }
}
