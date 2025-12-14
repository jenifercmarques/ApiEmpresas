using ApiEmpresas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly AppDbContext _context;

    public FuncionarioRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AddFuncionarioAsync(Funcionario funcionario)
    {
        await _context.Funcionarios.AddAsync(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync()
    {
        return await _context.Funcionarios.ToListAsync();
    }

    public async Task UpdateFuncionarioAsync(Funcionario funcionario)
    {
        _context.Funcionarios.Update(funcionario);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteFuncionarioAsync(int id)
    {
        var funcionario = await _context.Funcionarios.FindAsync(id);
        if (funcionario != null)
        {
            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();
        }
        else
        {
            throw new ApplicationException("Funcionario não encontrado.");
        }
    }

    public async Task<Funcionario?> GetFuncionarioByIdAsync(int id)
    {
        return await _context.Funcionarios.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
    }
}