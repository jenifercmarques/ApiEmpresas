using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEmpresas.Domain.Entities
{
    [Table("funcionario")]
    public record Funcionario
    {
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [Column("nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [Column("cpf")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        [Column("contrato_ativo")]
        public ContratoAtivoEnum ContratoAtivo { get; set; }
        public Funcionario(string nome, string cpf, ContratoAtivoEnum contratoAtivo)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                throw new ArgumentException("CPF deve conter 11 caracteres.");

            Nome = nome;
            Cpf = cpf;
            ContratoAtivo = contratoAtivo;
        }
    }
}
