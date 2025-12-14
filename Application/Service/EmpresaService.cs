using ApiEmpresas.Domain.Entities;

public class EmpresaService: IEmpresaService
{
    private readonly IEmpresaRepository _empresaRepository;

    public EmpresaService(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }
    
    public async Task AdicionarEmpresaAsync(EmpresaDto empresa)
    {
        await _empresaRepository.AddEmpresaAsync(new Empresa(empresa.Nome, empresa.Cnpj, empresa.QuantidadeFuncionarios));
    }

    public async Task AtualizarEmpresaAsync(int id, EmpresaDto empresa)
    {
        var empresaExistente = await _empresaRepository.GetEmpresaByIdAsync(id);
        if (empresaExistente is null)
            throw new ApplicationException("Empresa não encontrada.");
        await _empresaRepository.UpdateEmpresaAsync(empresaExistente with
        {
            Nome = empresa.Nome,
            Cnpj = empresa.Cnpj,
            QuantidadeFuncionarios = empresa.QuantidadeFuncionarios
        });
    }

    public async Task RemoverEmpresaAsync(int id)
    {
        await _empresaRepository.DeleteEmpresaAsync(id);
    }

    public async Task<IEnumerable<EmpresaDto>?> ObterTodosAsync()
    {
        var empresas = await _empresaRepository.GetAllEmpresasAsync();
        if (empresas is null)
            return null;
        return empresas.Select(e => new EmpresaDto(e.Nome, e.Cnpj, e.QuantidadeFuncionarios));
    }
}