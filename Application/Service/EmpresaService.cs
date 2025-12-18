using ApiEmpresas.Domain.Entities;

/// <summary>
/// Serviço responsável pela lógica de negócios de Empresa
/// </summary>
public class EmpresaService: IEmpresaService
{
    // Repositório para acesso aos dados de empresa
    private readonly IEmpresaRepository _empresaRepository;

    /// <summary>
    /// Construtor que injeta o repositório de empresa
    /// </summary>
    public EmpresaService(IEmpresaRepository empresaRepository)
    {
        _empresaRepository = empresaRepository;
    }
    
    /// <summary>
    /// Adiciona uma nova empresa
    /// </summary>
    public async Task AdicionarEmpresaAsync(AddUpdateEmpresaDto empresa)
    {
        // Cria e adiciona a empresa no repositório
        await _empresaRepository.AddEmpresaAsync(new Empresa(empresa.Nome, empresa.Cnpj, empresa.QuantidadeFuncionarios));
    }

    /// <summary>
    /// Atualiza uma empresa existente
    /// </summary>
    public async Task AtualizarEmpresaAsync(int id, AddUpdateEmpresaDto empresa)
    {   
        // Valida o CNPJ
        if (string.IsNullOrWhiteSpace(empresa.Cnpj) || empresa.Cnpj.Length != 14)
                throw new ArgumentException("CNPJ deve conter 14 caracteres.");
        
        // Busca a empresa existente
        var empresaExistente = await _empresaRepository.GetEmpresaByIdAsync(id);
        if (empresaExistente is null)
            throw new ApplicationException("Empresa não encontrada.");
        
        // Atualiza os dados usando o padrão with (record)
        await _empresaRepository.UpdateEmpresaAsync(empresaExistente with
        {
            Nome = empresa.Nome,
            Cnpj = empresa.Cnpj,
            QuantidadeFuncionarios = empresa.QuantidadeFuncionarios
        });
    }

    /// <summary>
    /// Remove uma empresa por ID
    /// </summary>
    public async Task RemoverEmpresaAsync(int id)
    {
        await _empresaRepository.DeleteEmpresaAsync(id);
    }

    /// <summary>
    /// Obtém todas as empresas e converte para DTO
    /// </summary>
    public async Task<IEnumerable<EmpresaDto>?> ObterTodosAsync()
    {
        // Busca todas as empresas
        var empresas = await _empresaRepository.GetAllEmpresasAsync();
        if (empresas is null)
            return null;
        
        // Converte as entidades para DTOs
        return empresas.Select(e => new EmpresaDto(e.Id, e.Nome, e.Cnpj, e.QuantidadeFuncionarios));
    }
}