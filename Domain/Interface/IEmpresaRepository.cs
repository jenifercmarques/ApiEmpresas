using ApiEmpresas.Domain.Entities;

public interface IEmpresaRepository
{
    Task AddEmpresaAsync(Empresa empresa);
    Task<IEnumerable<Empresa>> GetAllEmpresasAsync();
    Task UpdateEmpresaAsync(Empresa empresa);
    Task DeleteEmpresaAsync(int id);
    Task<Empresa?> GetEmpresaByIdAsync(int id);
}