📚 Biblioteca API

Uma aplicação .NET Web API desenvolvida para praticar conceitos de arquitetura, boas práticas e organização de projetos.
O objetivo é simular o gerenciamento de uma biblioteca, com autores e livros, aplicando camadas bem definidas.

🚀 Tecnologias utilizadas

.NET 8

Entity Framework Core

C#

REST API

Banco Mysql

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
