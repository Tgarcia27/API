using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TriscalWebApi.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }

        [Required(ErrorMessage = "Nome deve ser informado!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Nome deve ter no máximo 30 caracteres!")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "CPF obrigatório")]
        [CustomValidation.CustomValidationCPF(ErrorMessage = "CPF inválido")]
        public string Cpf { get; set; }
        public string Rg { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date, ErrorMessage = "Uma data válida deve ser informada!")]
        public DateTime DataNascimento { get; set; }
        public int Idade { get; set; }
        public IEnumerable<Telefone> Telefones { get; set; }
        public Endereco Endereco { get; set; }


    }
}
