using ApiEmpresas.Domain.Entities;

/// <summary>
/// Serviço responsável pela lógica de negócios de Funcionário
/// </summary>
public class FuncionarioService: IFuncionarioService
{
    // Repositório para acesso aos dados de funcionário
    private readonly IFuncionarioRepository _funcionarioRepository;

    /// <summary>
    /// Construtor que injeta o repositório de funcionário
    /// </summary>
    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }
    
    /// <summary>
    /// Adiciona um novo funcionário
    /// </summary>
    public async Task AdicionarFuncionarioAsync(AddUpdateFuncionarioDto funcionario)
    {
        // Cria e adiciona o funcionário no repositório
        await _funcionarioRepository.AddFuncionarioAsync(new Funcionario(funcionario.Nome, funcionario.Cpf, funcionario.ContratoAtivo));
    }

    /// <summary>
    /// Atualiza um funcionário existente
    /// </summary>
    public async Task AtualizarFuncionarioAsync(int id, AddUpdateFuncionarioDto funcionario)
    {
        // Busca o funcionário existente
        var funcionarioExistente = await _funcionarioRepository.GetFuncionarioByIdAsync(id);
        if (funcionarioExistente is null)
            throw new ApplicationException("Funcionario não encontrado.");
        
        // Atualiza os dados usando o padrão with (record)
        await _funcionarioRepository.UpdateFuncionarioAsync(funcionarioExistente with
        {
            Nome = funcionario.Nome,
            Cpf = funcionario.Cpf,
            ContratoAtivo = funcionario.ContratoAtivo
        });
    }

    /// <summary>
    /// Remove um funcionário por ID
    /// </summary>
    public async Task RemoverFuncionarioAsync(int id)
    {
        await _funcionarioRepository.DeleteFuncionarioAsync(id);
    }

    /// <summary>
    /// Obtém todos os funcionários e converte para DTO
    /// </summary>
    public async Task<IEnumerable<FuncionarioDto>?> ObterTodosAsync()
    {
        // Busca todos os funcionários
        var funcionarios = await _funcionarioRepository.GetAllFuncionariosAsync();
        if (funcionarios is null)
            return null;
        
        // Converte as entidades para DTOs
        return funcionarios.Select(f => new FuncionarioDto(f.Id, f.Nome, f.Cpf, f.ContratoAtivo));
    }
}