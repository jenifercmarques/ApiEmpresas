public interface IFuncionarioService
{
    Task AdicionarFuncionarioAsync(AddUpdateFuncionarioDto funcionario);
    Task AtualizarFuncionarioAsync(int id, AddUpdateFuncionarioDto funcionario);
    Task RemoverFuncionarioAsync(int id);
    Task<IEnumerable<FuncionarioDto>?> ObterTodosAsync();
}