using System;
using System.Collections.Generic;
using TriscalWebApi.Controllers;
using TriscalWebApi.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace WebAPI.Testes
{
    public class Cliente
    {
        private readonly IClienteRepository _ClienteRepository;
        


        /// Retorna uma lista de todas os clientes cadastrados no banco de dados.
        /// [metodo]_[condicao]_[ResultadoEsperado]
        /// Triscal WEB API

        [TestMethod]
        public void Get_All_Lista_Objeto_cliente()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                var testCliente = cliente.Get();
                List<Cliente> result = cliente.Get() as List<Cliente>;
                Assert.AreEqual(testCliente, result.Count);
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Filtra os clientes através do ID informado.
        /// [metodo]_[condicao]_[ResultadoEsperado]
        /// Triscal WEB API

        [TestMethod]
        public void Get_Cliente_Por_ID()
        {
            // ID Ficticio para pegar o Cliente que possui esse ID na base de Dados
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                var testCliente = cliente.Get(10);
                var result = cliente.Get() as List<Cliente>;
                Assert.AreEqual(testCliente, result.Count);

            }
            catch (Exception)
            {
                throw;
            }
        }

        /// Efetua o cadastro de uma nova cliente no banco de dados.
        /// [metodo]_[condicao]_[ResultadoEsperado]
        /// Triscal WEB API

        [TestMethod]
        public void Post_Cliente()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                TriscalWebApi.Models.Cliente cli = new TriscalWebApi.Models.Cliente
                {
                    Nome = "Thiago Garcia Siqueira",
                    Cpf = "102.103.104-66",
                    Rg = "11.12.13.14-1",
                    DataNascimento = DateTime.Parse("12/01/1985"),
                    Endereco = new TriscalWebApi.Models.Endereco
                    {
                        Logradouro = "Rua A",
                        Numero = "12 B",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Uf = "RJ"
                    }
                };

                cliente.Post(cli);

                Assert.AreEqual(cliente, 1);
            }
            catch (Exception)
            {
                throw;
            }
        }


        [TestMethod]
        public void Post_Cliente_Error_Nome()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                TriscalWebApi.Models.Cliente cli = new TriscalWebApi.Models.Cliente
                {
                    Nome = "Thiago Garcia Siqueira da Silva Santos",
                    Cpf = "102.103.104-10",
                    Rg = "11.12.13.14-1",
                    DataNascimento = DateTime.Parse("12/01/1985"),
                    Endereco = new TriscalWebApi.Models.Endereco
                    {
                        Logradouro = "Rua A",
                        Numero = "12 B",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Uf = "RJ"
                    }
                };

                cliente.Post(cli);

                Assert.AreEqual("Nome deve ter no máximo 30 caracteres!", cliente);
               
            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void Post_Cliente_Error_CPF()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                TriscalWebApi.Models.Cliente cli = new TriscalWebApi.Models.Cliente
                {
                    Nome = "Thiago Garcia Siqueira",
                    Cpf = "102.103.104",
                    Rg = "11.12.13.14-1",
                    DataNascimento = DateTime.Parse("12/01/1985"),
                    Endereco = new TriscalWebApi.Models.Endereco
                    {
                        Logradouro = "Rua A",
                        Numero = "12 B",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Uf = "RJ"
                    }
                };

                cliente.Post(cli);

                Assert.AreEqual("CPF inválido!", cliente);

            }
            catch (Exception)
            {
                throw;
            }
        }
        [TestMethod]
        public void Post_Cliente_Error_CPF_Obrigatorio()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                TriscalWebApi.Models.Cliente cli = new TriscalWebApi.Models.Cliente
                {
                    Nome = "Thiago Garcia Siqueira",
                    Cpf = "".Trim(),
                    Rg = "11.12.13.14-1",
                    DataNascimento = DateTime.Parse("12/01/1985"),
                    Endereco = new TriscalWebApi.Models.Endereco
                    {
                        Logradouro = "Rua A",
                        Numero = "12 B",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Uf = "RJ"
                    }
                };

                cliente.Post(cli);

                Assert.AreEqual("CPF obrigatório", cliente);

            }
            catch (Exception)
            {
                throw;
            }
        }

        [TestMethod]
        public void Post_Cliente_Error_Endereco()
        {
            try
            {
                ClienteController cliente = new ClienteController(_ClienteRepository);
                TriscalWebApi.Models.Cliente cli = new TriscalWebApi.Models.Cliente
                {
                    Nome = "Thiago Garcia Siqueira",
                    Cpf = "102.103.104-10",
                    Rg = "11.12.13.14-1",
                    DataNascimento = DateTime.Parse("12/01/1985"),
                    Endereco = new TriscalWebApi.Models.Endereco
                    {
                        Logradouro = "Rua Nossa Senhora de Copacabana esquina com Republica do Peru",
                        Numero = "12 B",
                        Bairro = "Centro",
                        Cidade = "Rio de Janeiro",
                        Uf = "RJ"
                    }
                };

                cliente.Post(cli);

                Assert.AreEqual("Logradouro deve ter no máximo 50 caracteres!", cliente);

            }
            catch (Exception)
            {
                throw;
            }
        }

    }
}
