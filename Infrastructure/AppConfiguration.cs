using Microsoft.EntityFrameworkCore;

/// <summary>
/// Classe de extensão para configurar a aplicação e seus serviços
/// </summary>
public static class AppConfiguration
{
    /// <summary>
    /// Configura o contexto do banco de dados com MySQL
    /// </summary>
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(options =>
            // Configura o provedor MySQL com a string de conexão
            options.UseMySql(configuration["ConnectionStrings:DefaultConnection"],
                new MySqlServerVersion(new Version(8, 0, 26))));
    
    /// <summary>
    /// Configura os middlewares da aplicação
    /// </summary>
    public static void ConfigureApp(this WebApplication app)
    {
        // Redireciona requisições HTTP para HTTPS
        app.UseHttpsRedirection();
        // Mapeia os controladores para as rotas
        app.MapControllers();
    }
    
    /// <summary>
    /// Configura a injeção de dependência dos serviços e repositórios
    /// AddScoped: uma instância por requisição HTTP
    /// </summary>
    public static void ConfigureServices(this IServiceCollection services)
    {
        // Registra os serviços de Empresa
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        
        // Registra os serviços de Funcionário
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
    }
}