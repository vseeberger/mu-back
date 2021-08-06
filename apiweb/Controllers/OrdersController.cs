using apiweb.Data;
using apiweb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Controllers
{
    [ApiController]
    [Route("v1/pedidos")]
    public class OrdersController : ControllerBase
    {
        #region Métodos de retornar o pedido (lista ou object)
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Order>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Orders
                                            .AsNoTracking()
                                            .ToListAsync();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> GetById([FromServices] DataContext context, int id)
        {
            var dados = await context.Orders
                                        .AsNoTracking()
                                        .Include(q => q.OrderItems)
                                        .FirstOrDefaultAsync(q => q.Id == id);
            return dados;
        }
        #endregion

        #region Métodos de salvar o pedido (create / update / delete)
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Order>> Create(
            [FromServices] DataContext context,
            [FromBody] Order model
            )
        {
            if (ModelState.IsValid)
            {
                context.Orders.Add(model);
                await context.SaveChangesAsync();

                //if(model.Id > 0)
                //{
                //    for (int i = 0; i < model.OrderItems.Count; i++)
                //    {
                //        var element = model.OrderItems[i];
                //        element.OrderId = model.Id;
                //        context.OrderItems.Add(element);
                //    }
                //}

                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Order>> Update(
            [FromServices] DataContext context,
            [FromBody] Order model
            )
        {
            if (ModelState.IsValid)
            {
                context.Orders.Update(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Order>> Delete(
            [FromServices] DataContext context,
            int id
            )
        {
            if (id > 0)
            {
                var dados = await context.Orders
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(q => q.Id == id);

                if (dados == null || dados.Id <= 0)
                {
                    return BadRequest("Pedido não encontrado");
                }
                else
                {
                    context.Orders.Remove(dados);
                    await context.SaveChangesAsync();
                    return dados;
                }
            }
            else
            {
                return BadRequest("Código não informado");
            }
        }
        #endregion
    }
}
