using Microsoft.EntityFrameworkCore;

public static class AppConfiguration
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        => services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(configuration["ConnectionStrings:DefaultConnection"],
                new MySqlServerVersion(new Version(8, 0, 26))));
    public static void ConfigureApp(this WebApplication app)
    {
        app.UseHttpsRedirection();
        app.MapControllers();
    }
    public static void ConfigureServices(this IServiceCollection services)
    {
        services.AddScoped<IEmpresaService, EmpresaService>();
        services.AddScoped<IEmpresaRepository, EmpresaRepository>();
        services.AddScoped<IFuncionarioService, FuncionarioService>();
        services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
    }
}