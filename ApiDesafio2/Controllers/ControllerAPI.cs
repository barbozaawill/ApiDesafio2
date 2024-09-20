using ApiDesafio2.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;

namespace ApiDesafio2.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class ControllerAPI : ControllerBase
    {
        private readonly SistemaPontuacaoService _service;

        public ControllerAPI(SistemaPontuacaoService service)
        {
            _service = service;
        }
        [HttpPost("calcular")]
        public IActionResult CalcularPontos([FromBody] Venda venda)
        {
            if (venda == null || venda.Valor <= 0 || venda.IdCliente <= 0)
            {
                return BadRequest("Dados inválidos para venda.");
            }

            var pontos = _service.CalcularPontos(venda.Valor);
            _service.AdicionarPontos(venda.IdCliente, pontos);

            return Ok(new
            {
                IdCliente = venda.IdCliente,
                IdVenda = venda.IdVenda,
                ValorVenda = venda.Valor,
                PontosGerados = pontos
            });
        }
        [HttpGet("simular-venda")]
        public IActionResult SimularVenda()
        {
            var venda = new Venda
            {
                IdCliente = 1,    
                IdVenda = 1,
                Valor = 150.00M      
            };

            var pontos = _service.CalcularPontos(venda.Valor);
            _service.AdicionarPontos(venda.IdCliente, pontos);

            return Ok(new
            {
                venda.IdCliente,
                venda.IdVenda,
                venda.Valor,
                PontosGerados = pontos
            });
        }
    }
}
