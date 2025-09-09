📚 Biblioteca API

Uma aplicação .NET Web API desenvolvida para praticar conceitos de arquitetura, boas práticas e organização de projetos.
O objetivo é simular o gerenciamento de uma biblioteca, com autores e livros, aplicando camadas bem definidas.

🚀 Tecnologias utilizadas

[.NET 8] (ajuste conforme versão usada)

Entity Framework Core

C#

REST API

Banco Mysql

📂 Estrutura do Projeto
biblioteca/
│── Controllers/        # Controladores da API
│   ├── AutorController.cs
│   ├── LivroController.cs
│
│── Data/               # Contexto do banco de dados
│   └── AppDbContext.cs
│
│── DTO/                # Objetos de transferência de dados
│   ├── AutorCriacaoDto.cs
│   ├── AutorEdicaoDto.cs
│   ├── LivroCriacaoDto.cs
│   ├── LivroEdicaoDto.cs
│
│── Models/             # Entidades do sistema
│   ├── AutorModel.cs
│   ├── LivroModel.cs
│   └── ResponseModel.cs
│
│── Services/           # Regras de negócio
│   ├── Autor/
│   │   ├── AutorService.cs
│   │   └── IAutorInterfaces.cs
│   ├── Livro/
│       ├── LivroService.cs
│       └── ILivroInterfaces.cs
│
│── Migrations/         # Migrações do Entity Framework
│── appsettings.json    # Configurações da aplicação
│── Program.cs          # Configuração inicial

📌 Funcionalidades

Autores

Criar autor

Editar autor

Listar autores

Excluir autor

Livros

Criar livro

Editar livro

Listar livros

Excluir livro

▶️ Como rodar o projeto

Clone este repositório:

git clone https://github.com/seu-usuario/biblioteca.git


Entre na pasta do projeto:

cd biblioteca


Configure a string de conexão no arquivo appsettings.json.

Rode as migrações para criar o banco:

dotnet ef database update


Execute a aplicação:

dotnet run


A API estará disponível em:

https://localhost:5001/swagger
