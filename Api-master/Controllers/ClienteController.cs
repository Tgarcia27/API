using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using TriscalWebApi.Interface;
using TriscalWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TriscalWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteRepository _ClienteRepository;

        public ClienteController(IClienteRepository clienteRepository)
        {
            this._ClienteRepository = clienteRepository;
        }

        // GET: Api/cliente
        /// <summary>
        /// Retorna uma lista de todas os clientes cadastrados no banco de dados.
        /// </summary>
        /// <returns>Lista de objetos do tipo cliente</returns>
        [HttpGet]
        public IActionResult Get()
        {
            IEnumerable<Cliente> clientes = this._ClienteRepository.GetAll();

            return new OkObjectResult(clientes);
        }

        // GET: Api/cliente/5
        /// <summary>
        /// Filtra os clientes através do ID informado.
        /// </summary>
        /// <param name="id">ID do cliente</param>
        /// <returns>Objeto do tipo cliente</returns>
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Int32 id)
        {
            Cliente cliente = this._ClienteRepository.GetById(id);

            return new OkObjectResult(cliente);
        }

        // POST: Api/cliente
        /// <summary>
        /// Efetua o cadastro de um novo cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] Cliente cliente)
        {
            using (TransactionScope scope = new TransactionScope())
            {
               
                int idade = DateTime.Now.Year - cliente.DataNascimento.Year;

                if (cliente.DataNascimento < DateTime.Now)
                {
                    if(DateTime.Now.DayOfYear < cliente.DataNascimento.DayOfYear)
                    {
                        idade = idade - 1;
                    }
                    else
                    {
                        idade = 0;
                    }

                    cliente.Idade = idade;
                }

                this._ClienteRepository.Insert(cliente);
                scope.Complete();

                return this.CreatedAtAction(nameof(Get), new { id = cliente.IdCliente }, cliente);
            }
        }

        // PUT: Api/cliente/5
        /// <summary>
        /// Atualiza os dados de um cliente no banco de dados.
        /// </summary>
        /// <param name="cliente">Objeto do tipo cliente</param>
        /// <returns></returns>
        [HttpPut]
        public IActionResult Put([FromBody] Cliente cliente)
        {
            if (cliente != null)
            {
                using (TransactionScope scope = new TransactionScope())
                {

                    this._ClienteRepository.Update(cliente);
                    scope.Complete();

                    return new OkResult();
                }
            }

            return new NoContentResult();
        }

        // DELETE: Api/ApiWithActions/5
        /// <summary>
        /// Exclui um cliente do banco de dados.
        /// </summary>
        /// <param name="id">ID do cliente a ser excluído</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _ClienteRepository.Delete(id);

            return new OkResult();
        }



    }
}