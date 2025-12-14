using ApiEmpresas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class EmpresaController : ControllerBase
{
    private readonly IEmpresaService _empresaService;
    public EmpresaController(IEmpresaService empresaService)
    {
        _empresaService = empresaService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateEmpresa([FromBody] EmpresaDto empresaDto)
    {
       try
        {
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmpresa([FromRoute] int id)
    {
       try
        {
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

    [HttpGet]
    public async Task<IActionResult> GetEmpresa()
    {
       try
        {
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmpresa([FromRoute] int id, [FromBody] EmpresaDto empresaDto)
    {
       try
        {
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