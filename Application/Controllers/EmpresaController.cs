using ApiEmpresas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controlador responsável pelas operações de Empresa
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    // Serviço de lógica de negócios para Empresa
    private readonly IEmpresaService _empresaService;
    
    /// <summary>
    /// Construtor que injeta o serviço de empresa
    /// </summary>
    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }
    /// <summary>
    /// Cria uma nova empresa
    /// </summary>
    /// <param name="empresaDto">Dados da empresa a ser criada</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpPost]
    public async Task<IActionResult> CreateEmpresa([FromBody] AddUpdateEmpresaDto empresaDto)
    {
       try
        {
            // Adiciona a empresa no banco de dados
            await _empresaService.AdicionarEmpresaAsync(new (empresaDto.Nome, empresaDto.Cnpj, empresaDto.QuantidadeFuncionarios));
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
    /// Remove uma empresa por ID
    /// </summary>
    /// <param name="id">ID da empresa a ser removida</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpresa([FromRoute] int id)
    {
       try
        {
            // Remove a empresa do banco de dados
            await _empresaService.RemoverEmpresaAsync(id);
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
    /// Retorna todas as empresas cadastradas
    /// </summary>
    /// <returns>Lista de empresas</returns>
    [HttpGet]
    public async Task<IActionResult> GetEmpresa()
    {
       try
        {
            // Busca todas as empresas do banco de dados
            var empresas= await _empresaService.ObterTodosAsync();
            return Ok(empresas);
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
    /// Atualiza os dados de uma empresa existente
    /// </summary>
    /// <param name="id">ID da empresa a ser atualizada</param>
    /// <param name="empresaDto">Novos dados da empresa</param>
    /// <returns>Status 200 se sucesso, 422 se erro de validação, 400 se erro interno</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmpresa([FromRoute] int id, [FromBody] AddUpdateEmpresaDto empresaDto)
    {
       try
        {
            // Atualiza os dados da empresa no banco de dados
            await _empresaService.AtualizarEmpresaAsync(id, empresaDto);
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