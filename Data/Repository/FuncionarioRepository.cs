using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repositório responsável pelo acesso aos dados de Funcionário
/// </summary>
public class FuncionarioRepository : IFuncionarioRepository
{
    // Contexto do banco de dados
    private readonly AppDbContext _context;

    /// <summary>
    /// Construtor que injeta o contexto do banco de dados
    /// </summary>
    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adiciona um novo funcionário no banco de dados
    /// </summary>
    public async Task AddFuncionarioAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retorna todos os funcionários do banco de dados
    /// </summary>
    public async Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    /// <summary>
    /// Atualiza um funcionário no banco de dados
    /// </summary>
    public async Task UpdateFuncionarioAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Remove um funcionário do banco de dados
    /// </summary>
    public async Task DeleteFuncionarioAsync(int id)
    {
        // Busca o funcionário por ID
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario != null)
        {
            // Remove o funcionário e salva as alterações
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ApplicationException("Funcionario não encontrado.");
        }
    }

    /// <summary>
    /// Busca um funcionário por ID sem rastreamento do EF
    /// </summary>
    public async Task<Funcionario?> GetFuncionarioByIdAsync(int id)
    {
        // AsNoTracking melhora a performance quando não há necessidade de rastrear mudanças
        return await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}