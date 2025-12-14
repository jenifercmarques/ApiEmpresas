using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiEmpresas.Domain.Entities
{
    [Table("empresa")]
    public record Empresa
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
        [Column("cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        [Column("quantidade_funcionarios")]
        public int? QuantidadeFuncionarios { get; set; }
        public Empresa(string nome, string cnpj, int? quantidadeFuncionarios)
        {
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa não pode ser vazio.");

            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
                throw new ArgumentException("CNPJ deve conter 14 caracteres.");

            Nome = nome;
            Cnpj = cnpj;
            QuantidadeFuncionarios = quantidadeFuncionarios;
        }
    }
}
