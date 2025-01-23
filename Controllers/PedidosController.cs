using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Concentrix.Models;
using Concentrix.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using EntityState = Microsoft.EntityFrameworkCore.EntityState;



namespace Concentrix.Controllers
{
    [Route("orders")]
    [ApiController]
    public class PedidosController:ControllerBase
    {

        private readonly PedidosDbContext _dbContextPedidos;

        public PedidosController(PedidosDbContext dbContextPedidos)
        {
            _dbContextPedidos = dbContextPedidos;
        }

        public PedidosController()
        {
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pedidos>>> GetPedidos()
        {
            return await _dbContextPedidos.gerarPedidos.Include(t=>t.ItensPedidos).ToListAsync();
        }





        [HttpGet("{id}")]
        public async Task<ActionResult<Pedidos>> GetPedido(int id)
        {
            var resultPedido =   _dbContextPedidos.gerarPedidos.Include(t => t.ItensPedidos).FirstOrDefault(t => t.id == id);

            if (resultPedido == null)
            {
                return NotFound();
            }

            return resultPedido;

        }

       


        [HttpPost]
        public async Task<ActionResult<Pedidos>> PostEstudante(Pedidos gerarPedido)
        {
            _dbContextPedidos.gerarPedidos.Add(gerarPedido);
            await _dbContextPedidos.SaveChangesAsync();

            return CreatedAtAction("GetPedido", new { id = gerarPedido.id }, gerarPedido);
        }




        [HttpDelete("{id}")]
        public async Task<IActionResult> excluirPedido(int id)
        {
            var exclusao =  _dbContextPedidos.gerarPedidos.Include(t => t.ItensPedidos).FirstOrDefault(t => t.id == id);
            if (exclusao == null)
            {
                return NotFound();
            }

            _dbContextPedidos.gerarPedidos.Remove(exclusao);
            await _dbContextPedidos.SaveChangesAsync();

            return NoContent();
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> putPedido(int id,[FromBody] Pedidos atualizarPedido)
        {
            var atualizar =   _dbContextPedidos.gerarPedidos.Include(t => t.ItensPedidos).FirstOrDefault(t => t.id == id);

            if (atualizar.id == 0)
            {
                return NotFound();
            }
            try
            {
                _dbContextPedidos.Entry(atualizar).CurrentValues.SetValues(atualizarPedido);
                _dbContextPedidos.SaveChanges();

             
            }
            catch
            {
                return BadRequest("Dados Invalidos");

            }

            return NoContent();
        }

  

        [HttpGet("/orders/NomeCliente")]
        public async Task<ActionResult<Pedidos>> GetPedidoByName(string nome)
        {
            var resultNome = _dbContextPedidos.gerarPedidos.Include(t => t.ItensPedidos).FirstOrDefault(t => t.nomeCliente == nome);

            if (resultNome == null)
            {
                return NotFound();
            }

            return resultNome;
        }


    }
}
