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
    [Route("v1/produtos")]
    public class ProductsController : ControllerBase
    {
        #region Métodos de retornar o produto (lista ou object)
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Product>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Products
                                            .AsNoTracking()
                                            .ToListAsync();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Product>> GetById([FromServices] DataContext context, int id)
        {
            var dados = await context.Products
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(q => q.Id == id);
            return dados;
        }

        #endregion

        #region Métodos de salvar o produto (create / update / delete)
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Product>> Create(
            [FromServices] DataContext context,
            [FromBody] Product model
            )
        {
            if (ModelState.IsValid)
            {
                context.Products.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Product>> Update(
            [FromServices] DataContext context,
            [FromBody] Product model
            )
        {
            if (ModelState.IsValid)
            {
                context.Products.Update(model);
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
        public async Task<ActionResult<Product>> Delete(
            [FromServices] DataContext context,
            int id
            )
        {
            if (id > 0)
            {
                var dados = await context.Products
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(q => q.Id == id);

                if (dados == null || dados.Id <= 0)
                {
                    return BadRequest("Produto não encontrado");
                }
                else
                {
                    context.Products.Remove(dados);
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
