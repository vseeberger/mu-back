using apiweb.Data;
using apiweb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace apiweb.Controllers
{
    [ApiController]
    [Route("v1/clientes")]
    public class ClientsController : ControllerBase
    {
        #region Métodos de retornar o cliente (lista ou object)
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Client>>> Get([FromServices] DataContext context)
        {
            var clientes = await context.Clients
                                            .AsNoTracking()
                                            .ToListAsync();
            return clientes;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<Client>> GetById([FromServices] DataContext context, int id)
        {
            var dados = await context.Clients
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(q => q.Id == id);
            return dados;
        }

        #endregion

        #region Métodos de salvar o cliente (create / update / delete)
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Client>> Create(
            [FromServices] DataContext context,
            [FromBody] Client model
            )
        {
            if (ModelState.IsValid)
            {
                // se os dados forem validados pela class então vou validar o email
                var registros = context.Clients
                                        .FromSqlRaw("SELECT * FROM Clients WHERE SEmail = {0}", model.SEmail)
                                        .ToList();
                if (registros == null || registros.Count() == 0)
                {
                    context.Clients.Add(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest("E-mail já cadastrado");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("update")]
        public async Task<ActionResult<Client>> Update(
            [FromServices] DataContext context,
            [FromBody] Client model
            )
        {
            if (ModelState.IsValid)
            {
                // se os dados forem validados pela class então vou validar se o email existe em outro cliente
                var registros = context.Clients
                                        .FromSqlRaw("SELECT * FROM Clients WHERE SEmail = {0} AND Id != {1}", model.SEmail, model.Id)
                                        .ToList();
                if (registros == null || registros.Count() == 0)
                {
                    context.Clients.Update(model);
                    await context.SaveChangesAsync();
                    return model;
                }
                else
                {
                    return BadRequest("E-mail já cadastrado");
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult<Client>> Delete(
            [FromServices] DataContext context,
            int id
            )
        {
            if (id > 0)
            {
                var dados = await context.Clients
                                        .AsNoTracking()
                                        .FirstOrDefaultAsync(q => q.Id == id);

                if (dados == null || dados.Id <= 0)
                {
                    return BadRequest("Cliente não encontrado");
                }
                else
                {
                    context.Clients.Remove(dados);
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
