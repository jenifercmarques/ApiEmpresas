// Ponto de entrada da aplicação
var builder = WebApplication.CreateBuilder(args);

// Adiciona os serviços ao container de injeção de dependência
// Documentação Swagger/OpenAPI: https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers(); // Habilita o uso de controladores
builder.Services.AddEndpointsApiExplorer(); // Explora os endpoints da API
builder.Services.AddSwaggerGen(); // Gera a documentação Swagger
builder.Services.ConfigureDbContext(builder.Configuration); // Configura o contexto do banco de dados
builder.Services.ConfigureServices(); // Configura os serviços e repositórios

var app = builder.Build();

// Configuração do pipeline de requisições HTTP
if (app.Environment.IsDevelopment())
{
    // Habilita Swagger apenas em ambiente de desenvolvimento
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configura middlewares da aplicação
app.ConfigureApp();

// Inicia a aplicação
app.Run();