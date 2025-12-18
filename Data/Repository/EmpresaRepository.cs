using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Repositório responsável pelo acesso aos dados de Empresa
/// </summary>
public class EmpresaRepository : IEmpresaRepository
{
    // Contexto do banco de dados
    private readonly AppDbContext _context;

    /// <summary>
    /// Construtor que injeta o contexto do banco de dados
    /// </summary>
    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Adiciona uma nova empresa no banco de dados
    /// </summary>
    public async Task AddEmpresaAsync(Empresa empresa)
    {
        await _context.Empresas.AddAsync(empresa);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Retorna todas as empresas do banco de dados
    /// </summary>
    public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
    {
        return await _context.Empresas.ToListAsync();
    }

    /// <summary>
    /// Atualiza uma empresa no banco de dados
    /// </summary>
    public async Task UpdateEmpresaAsync(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Remove uma empresa do banco de dados
    /// </summary>
    public async Task DeleteEmpresaAsync(int id)
    {
        // Busca a empresa por ID
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa != null)
        {
            // Remove a empresa e salva as alterações
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ApplicationException("Empresa não encontrada.");
        }
    }

    /// <summary>
    /// Busca uma empresa por ID sem rastreamento do EF
    /// </summary>
    public async Task<Empresa?> GetEmpresaByIdAsync(int id)
    {
        // AsNoTracking melhora a performance quando não há necessidade de rastrear mudanças
        return await _context.Empresas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}