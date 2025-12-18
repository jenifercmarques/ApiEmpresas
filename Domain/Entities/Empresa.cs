using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ApiEmpresas.Domain.Entities
{
    /// <summary>
    /// Entidade que representa uma Empresa no domínio
    /// </summary>
    [Table("empresa")]
    public record Empresa
    {
        // Identificador único da empresa (gerado automaticamente)
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nome da empresa (máximo 100 caracteres)
        [Required]
        [Column("nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        // CNPJ da empresa (14 caracteres - apenas números)
        [Required]
        [Column("cnpj")]
        [MaxLength(14)]
        public string Cnpj { get; set; }

        // Quantidade de funcionários (campo opcional)
        [Column("quantidade_funcionarios")]
        public int? QuantidadeFuncionarios { get; set; }
        /// <summary>
        /// Construtor que valida e inicializa uma nova empresa
        /// </summary>
        public Empresa(string nome, string cnpj, int? quantidadeFuncionarios)
        {
            // Valida se o nome não está vazio
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa não pode ser vazio.");

            // Valida se o CNPJ possui 14 caracteres
            if (string.IsNullOrWhiteSpace(cnpj) || cnpj.Length != 14)
                throw new ArgumentException("CNPJ deve conter 14 caracteres.");

            Nome = nome;
            Cnpj = cnpj;
            QuantidadeFuncionarios = quantidadeFuncionarios;
        }
    }
}
