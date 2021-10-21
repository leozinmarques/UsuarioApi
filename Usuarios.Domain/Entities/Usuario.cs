using System;

namespace Domain.Entities
{
    public  class Usuario : BaseEntity
    {
        public string Nome { get; set;}
        public string Sobrenome { get; set;}
        public string Email { get; set;}
        public DateTime DataNascimento { get; set;}
        public int Escolaridade { get; set;}

    }
}
