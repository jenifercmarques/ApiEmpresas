using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiEmpresas.Domain.Entities
{
    /// <summary>
    /// Entidade que representa um Funcionário no domínio
    /// </summary>
    [Table("funcionario")]
    public record Funcionario
    {
        // Identificador único do funcionário (gerado automaticamente)
        [Key]
        [Required]
        [Column("id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        // Nome do funcionário (máximo 100 caracteres)
        [Required]
        [Column("nome")]
        [MaxLength(100)]
        public string Nome { get; set; }

        // CPF do funcionário (11 caracteres - apenas números)
        [Required]
        [Column("cpf")]
        [MaxLength(11)]
        public string Cpf { get; set; }

        // Status do contrato (Ativo ou Inativo)
        [Column("contrato_ativo")]
        public ContratoAtivoEnum ContratoAtivo { get; set; }
        /// <summary>
        /// Construtor que valida e inicializa um novo funcionário
        /// </summary>
        public Funcionario(string nome, string cpf, ContratoAtivoEnum contratoAtivo)
        {
            // Valida se o nome não está vazio
            if (string.IsNullOrWhiteSpace(nome))
                throw new ArgumentException("Nome da empresa não pode ser vazio.");

            // Valida se o CPF possui 11 caracteres
            if (string.IsNullOrWhiteSpace(cpf) || cpf.Length != 11)
                throw new ArgumentException("CPF deve conter 11 caracteres.");

            Nome = nome;
            Cpf = cpf;
            ContratoAtivo = contratoAtivo;
        }
    }
}
