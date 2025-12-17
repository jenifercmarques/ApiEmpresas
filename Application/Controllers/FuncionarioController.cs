using ApiEmpresas.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class FuncionarioController : ControllerBase
{
    private readonly IFuncionarioService _funcionarioService;
    public FuncionarioController(IFuncionarioService funcionarioService)
    {
        _funcionarioService = funcionarioService;
    }
    [HttpPost]
    public async Task<IActionResult> CreateFuncionario([FromBody] AddUpdateFuncionarioDto funcionarioDto)
    {
       try
        {
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
    
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteFuncionario([FromRoute] int id)
    {
       try
        {
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

    [HttpGet]
    public async Task<IActionResult> GetFuncionario()
    {
       try
        {
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

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateFuncionario([FromRoute] int id, [FromBody] AddUpdateFuncionarioDto funcionarioDto)
    {
       try
        {
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