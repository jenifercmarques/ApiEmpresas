using ApiEmpresas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador responsável pelas operações de Funcionário
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    // Serviço de lógica de negócios para Funcionário
    private readonly IFuncionarioService _funcionarioService;
    
    /// <summary>
    /// Construtor que injeta o serviço de funcionário
    /// </summary>
    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }
    /// <summary>
    /// Cria um novo funcionário
    /// </summary>
    /// <param name="funcionarioDto">Dados do funcionário a ser criado</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpPost]
    public async Task<IActionResult> CreateFuncionario([FromBody] AddUpdateFuncionarioDto funcionarioDto)
    {
       try
        {
            // Adiciona o funcionário no banco de dados
            await _funcionarioService.AdicionarFuncionarioAsync(new (funcionarioDto.Nome, funcionarioDto.Cpf, funcionarioDto.ContratoAtivo));
            return Ok();
        }
        catch (ApplicationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
       catch (Exception ex)
       {
           return StatusCode(400, $"Internal server error: {ex.Message}");
       }
    }
    
    /// <summary>
    /// Remove um funcionário por ID
    /// </summary>
    /// <param name="id">ID do funcionário a ser removido</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuncionario([FromRoute] int id)
    {
       try
        {
            // Remove o funcionário do banco de dados
            await _funcionarioService.RemoverFuncionarioAsync(id);
            return Ok();
        }
        catch (ApplicationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Retorna todos os funcionários cadastrados
    /// </summary>
    /// <returns>Lista de funcionários</returns>
    [HttpGet]
    public async Task<IActionResult> GetFuncionario()
    {
       try
        {
            // Busca todos os funcionários do banco de dados
            var funcionarios= await _funcionarioService.ObterTodosAsync();
            return Ok(funcionarios);
        }
        catch (ApplicationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Internal server error: {ex.Message}");
        }
    }

    /// <summary>
    /// Atualiza os dados de um funcionário existente
    /// </summary>
    /// <param name="id">ID do funcionário a ser atualizado</param>
    /// <param name="funcionarioDto">Novos dados do funcionário</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncionario([FromRoute] int id, [FromBody] AddUpdateFuncionarioDto funcionarioDto)
    {
       try
        {
            // Atualiza os dados do funcionário no banco de dados
            await _funcionarioService.AtualizarFuncionarioAsync(id, funcionarioDto);
            return Ok();
        }
        catch (ApplicationException ex)
        {
            return UnprocessableEntity(ex.Message);
        }
        catch (Exception ex)
        {
            return StatusCode(400, $"Internal server error: {ex.Message}");
        }
    }
}