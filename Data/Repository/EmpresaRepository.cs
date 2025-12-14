using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class EmpresaRepository : IEmpresaRepository
{
    private readonly AppDbContext _context;

    public EmpresaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddEmpresaAsync(Empresa empresa)
    {
        await _context.Empresas.AddAsync(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Empresa>> GetAllEmpresasAsync()
    {
        return await _context.Empresas.ToListAsync();
    }

    public async Task UpdateEmpresaAsync(Empresa empresa)
    {
        _context.Empresas.Update(empresa);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteEmpresaAsync(int id)
    {
        var empresa = await _context.Empresas.FindAsync(id);
        if (empresa != null)
        {
            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ApplicationException("Empresa não encontrada.");
        }
    }

    public async Task<Empresa?> GetEmpresaByIdAsync(int id)
    {
        return await _context.Empresas.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}