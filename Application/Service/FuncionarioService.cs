using ApiEmpresas.Domain.Entities;

public class FuncionarioService: IFuncionarioService
{
    private readonly IFuncionarioRepository _funcionarioRepository;

    public FuncionarioService(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
    }
    
    public async Task AdicionarFuncionarioAsync(AddUpdateFuncionarioDto funcionario)
    {
        await _funcionarioRepository.AddFuncionarioAsync(new Funcionario(funcionario.Nome, funcionario.Cpf, funcionario.ContratoAtivo));
    }

    public async Task AtualizarFuncionarioAsync(int id, AddUpdateFuncionarioDto funcionario)
    {
        var funcionarioExistente = await _funcionarioRepository.GetFuncionarioByIdAsync(id);
        if (funcionarioExistente is null)
            throw new ApplicationException("Funcionario não encontrado.");
        await _funcionarioRepository.UpdateFuncionarioAsync(funcionarioExistente with
        {
            Nome = funcionario.Nome,
            Cpf = funcionario.Cpf,
            ContratoAtivo = funcionario.ContratoAtivo
        });
    }

    public async Task RemoverFuncionarioAsync(int id)
    {
        await _funcionarioRepository.DeleteFuncionarioAsync(id);
    }

    public async Task<IEnumerable<FuncionarioDto>?> ObterTodosAsync()
    {
        var funcionarios = await _funcionarioRepository.GetAllFuncionariosAsync();
        if (funcionarios is null)
            return null;
        return funcionarios.Select(f => new FuncionarioDto(f.Id, f.Nome, f.Cpf, f.ContratoAtivo));
    }
}