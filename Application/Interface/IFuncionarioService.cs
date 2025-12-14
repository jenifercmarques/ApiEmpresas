public interface IFuncionarioService
{
    Task AdicionarFuncionarioAsync(FuncionarioDto funcionario);
    Task AtualizarFuncionarioAsync(int id, FuncionarioDto funcionario);
    Task RemoverFuncionarioAsync(int id);
    Task<IEnumerable<FuncionarioDto>?> ObterTodosAsync();
}