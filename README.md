# API de Empresas e Funcionários

API REST desenvolvida em ASP.NET Core para gerenciamento de empresas e funcionários.

## 📋 Pré-requisitos

Antes de começar, certifique-se de ter instalado em sua máquina:

- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0)
- [Docker Desktop](https://www.docker.com/products/docker-desktop) instalado e em execução
- [Visual Studio Code](https://code.visualstudio.com/) ou [Visual Studio 2022](https://visualstudio.microsoft.com/) (Opcional)
- Git (opcional, para clonar o repositório)

## 🚀 Tecnologias Utilizadas

- **ASP.NET Core 10.0** - Framework web
- **Entity Framework Core 9.0** - ORM para acesso ao banco de dados
- **MySQL** - Banco de dados relacional
- **Pomelo.EntityFrameworkCore.MySql** - Provider MySQL para EF Core
- **Swagger/OpenAPI** - Documentação da API
- **Docker** - Execução do banco de dados em conteinerização

## 📁 Estrutura do Projeto

```
ApiEmpresas/
├── Application/           # Camada de aplicação
│   ├── Controllers/      # Controladores da API
│   ├── DTO/             # Objetos de Transferência de Dados
│   ├── Interface/       # Interfaces de serviços
│   └── Service/         # Implementação dos serviços
├── Data/                 # Camada de acesso a dados
│   ├── AppDbContext.cs  # Contexto do banco de dados
│   └── Repository/      # Repositórios
├── Domain/               # Camada de domínio
│   ├── Entities/        # Entidades do domínio
│   ├── Enum/            # Enumeradores
│   └── Interface/       # Interfaces de repositórios
├── Infrastructure/       # Configurações de infraestrutura
├── Migrations/          # Migrações do Entity Framework
└── Program.cs           # Ponto de entrada da aplicação
```

## Passo inicial

Baixar ou clonar o projeto no github utilizando em CMD

```bash
git glone https://github.com/jenifercmarques/ApiEmpresas.git
```

## ⚙️ Configuração do Ambiente

### 1. Iniciar o Banco de Dados MySQL no Docker

#### Passo a Passo

**1. Criar e iniciar o container MySQL**

Execute o comando abaixo para criar um container MySQL com as credenciais do projeto:

```bash
docker run --name mysql-apiempresas -e MYSQL_ROOT_PASSWORD=api@empresas -e MYSQL_DATABASE=api_empresas -p 3306:3306 -d mysql:8.0
```


### 2. Configurar a String de Conexão

Abra o arquivo [appsettings.json](appsettings.json) e ajuste a string de conexão conforme necessário:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "server=localhost;port=3306;database=api_empresas;user=root;password=api@empresas"
  }
}
```

### 3. Restaurar as Dependências

Abra um terminal na pasta raiz do projeto e execute:

```bash
dotnet restore
```

Este comando irá baixar todos os pacotes NuGet necessários.

### 4. Criar estrutura do banco

Abra um terminal na pasta raiz do projeto e execute:

```bash
dotnet ef database update
```

## ▶️ Executando a Aplicação

### Via Terminal

Na pasta raiz do projeto, execute:

```bash
dotnet run
```

A aplicação estará disponível em:
- **HTTP**: http://localhost:5157
- **HTTPS**: https://localhost:7242

## 📖 Acessando a Documentação da API

Após iniciar a aplicação, acesse o Swagger UI no navegador:

```
https://localhost:7242/swagger
```

ou

```
http://localhost:5157/swagger
```

O Swagger fornece uma interface interativa para testar todos os endpoints da API.

## 🔌 Endpoints Disponíveis

### Empresas

- `GET /api/empresa` - Lista todas as empresas
- `GET /api/empresa/{id}` - Busca uma empresa por ID
- `POST /api/empresa` - Cria uma nova empresa
- `PUT /api/empresa/{id}` - Atualiza uma empresa existente
- `DELETE /api/empresa/{id}` - Remove uma empresa

### Funcionários

- `GET /api/funcionario` - Lista todos os funcionários
- `GET /api/funcionario/{id}` - Busca um funcionário por ID
- `POST /api/funcionario` - Cria um novo funcionário
- `PUT /api/funcionario/{id}` - Atualiza um funcionário existente
- `DELETE /api/funcionario/{id}` - Remove um funcionário
