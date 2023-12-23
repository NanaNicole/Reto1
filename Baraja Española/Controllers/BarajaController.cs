using Baraja_Española.Services;
using Microsoft.AspNetCore.Mvc;
using System;

[ApiController]
[Route("api/[controller]")]
public class BarajaController : ControllerBase
{
    [HttpGet("generar-baraja")]
    public IActionResult ObtenerBarajaInicial()
    {
        try
        {
            Baraja baraja = new Baraja();
            baraja.GuardarEnArchivo("baraja.txt");
            return Ok("Baraja inicial generada correctamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al generar la baraja: {ex.Message}");
        }
    }

    [HttpGet("imprimir")]
    public IActionResult ImprimirBaraja()
    {
        try
        {
            Baraja baraja = ObtenerBaraja();
            baraja.Imprimir();
            return Ok("Baraja impresa correctamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al imprimir la baraja: {ex.Message}");
        }
    }

    [HttpGet("ordenar")]
    public IActionResult OrdenarBaraja()
    {
        try
        {
            Baraja baraja = ObtenerBaraja();
            baraja.Ordenar();
            baraja.GuardarEnArchivo("baraja.txt");
            return Ok("Baraja ordenada correctamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al ordenar la baraja: {ex.Message}");
        }
    }

    [HttpGet("barajar")]
    public IActionResult BarajarBaraja()
    {
        try
        {
            Baraja baraja = ObtenerBaraja();
            baraja.Barajar();
            baraja.GuardarEnArchivo("baraja.txt");
            return Ok("Baraja barajada correctamente");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Error al barajar la baraja: {ex.Message}");
        }
    }

    private Baraja ObtenerBaraja()
    {
        Baraja baraja = new Baraja();
        baraja.LeerDesdeArchivo("baraja.txt");
        return baraja;
    }
}
