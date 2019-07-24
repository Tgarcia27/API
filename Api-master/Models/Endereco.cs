using System;
using System.ComponentModel.DataAnnotations;


namespace TriscalWebApi.Models
{
    public class Endereco
    {
        public int EnderecoId {get; set;}
        public int ClienteId { get; set;}
        [Required(ErrorMessage = "Logradouro deve ser informado!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Logradouro deve ter no máximo 50 caracteres!")]
        public string Logradouro { get; set; }
        public string Numero { get; set; }
        [Required(ErrorMessage = "Bairro deve ser informado!")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Bairro ter no máximo 50 caracteres!")]
        public string Bairro { get; set; }
        [Required(ErrorMessage = "Cidade deve ser informado!")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Cidade deve ter no máximo 40 caracteres!")]
        public string Cidade { get; set; }
        [Required(ErrorMessage = "UF deve ser informado!")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "UF deve ter no máximo 40 caracteres!")]
        public string Uf { get; set; }
    }
}


