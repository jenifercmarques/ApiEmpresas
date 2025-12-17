public interface IEmpresaService
{
    Task AdicionarEmpresaAsync(AddUpdateEmpresaDto empresa);
    Task AtualizarEmpresaAsync(int id, AddUpdateEmpresaDto empresa);
    Task RemoverEmpresaAsync(int id);
    Task<IEnumerable<EmpresaDto>?> ObterTodosAsync();
}