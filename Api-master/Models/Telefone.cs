using System;


namespace TriscalWebApi.Models
{
	public class Telefone
	{   
        public int TelefoneId { get; set; }
        public string Tipo { get; set; }
        public string Numero { get; set; }
        public int ClienteId { get; set; }

    }
}
