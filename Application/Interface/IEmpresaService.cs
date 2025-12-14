public interface IEmpresaService
{
    Task AdicionarEmpresaAsync(EmpresaDto empresa);
    Task AtualizarEmpresaAsync(int id, EmpresaDto empresa);
    Task RemoverEmpresaAsync(int id);
    Task<IEnumerable<EmpresaDto>?> ObterTodosAsync();
}