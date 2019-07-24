using TriscalWebApi.Context;
using TriscalWebApi.Interface;
using TriscalWebApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace TriscalWebApi.Repository
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly ClienteContext _DbContext;

        public ClienteRepository(ClienteContext dbContext)
        {
            this._DbContext = dbContext;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return this._DbContext.Clientes.ToList();
        }

        public Cliente GetById(Int32 id)
        {
            return this._DbContext.Clientes.Find(id);
        }

        public void Insert(Cliente cliente)
        {
            this._DbContext.Add(cliente);

            this.Save();
        }

        public void Update(Cliente cliente)
        {
            this._DbContext.Entry(cliente).State = EntityState.Modified;

            this.Save();
        }

        public void Delete(Int32 id)
        {
            Cliente cliente = this._DbContext.Clientes.Find(id);
            this._DbContext.Clientes.Remove(cliente);

            this.Save();
        }

        public void Save()
        {
            this._DbContext.SaveChanges();
        }
    }
}
