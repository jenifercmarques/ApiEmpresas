using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto do banco de dados da aplicação
/// Gerencia as entidades e a conexão com o MySQL
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Construtor que recebe as opções de configuração do contexto
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    // Representa a tabela de Empresas no banco de dados
    public DbSet<Empresa> Empresas { get; set; }
    
    // Representa a tabela de Funcionários no banco de dados
    public DbSet<Funcionario> Funcionarios { get; set; }
}