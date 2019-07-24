using TriscalWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace TriscalWebApi.Interface
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(Int32 id);
        void Insert(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(Int32 id);
        void Save();
    }
}
