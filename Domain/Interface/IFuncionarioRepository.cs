using ApiEmpresas.Domain.Entities;

public interface IFuncionarioRepository
{
    Task AddFuncionarioAsync(Funcionario funcionario);
    Task<Funcionario?> GetFuncionarioByIdAsync(int id);
    Task<IEnumerable<Funcionario>> GetAllFuncionariosAsync();
    Task UpdateFuncionarioAsync(Funcionario funcionario);
    Task DeleteFuncionarioAsync(int id);
}