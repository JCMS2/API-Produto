PraticaApi

PraticaApi é uma API simples para gerenciamento de produtos, construída com ASP.NET Core, Entity Framework Core e MySQL. Ela permite criar, buscar, atualizar e deletar produtos armazenados em um banco de dados.

Funcionalidades

A API oferece os seguintes endpoints:

ProdutoController

POST /Produto/criar
Adiciona um novo produto ao banco de dados.
Parâmetros do corpo da requisição:

{
  "nome": "Nome do Produto",
  "preco": 100.0,
  "descricao": "Descrição do produto"
}


GET /Produto/Buscar
Retorna a lista de todos os produtos cadastrados.

GET /Produto/BuscarPorId?id={id}
Retorna um produto específico pelo seu ID.

GET /Produto/BuscarNome?nome={nome}
Retorna produtos cujo nome contenha o termo informado.

DELETE /Produto/DeletarPorId?id={id}
Remove um produto do banco de dados pelo ID.

PUT /Produto/Alterar?id={id}
Atualiza os dados de um produto específico.
Parâmetros do corpo da requisição:

{
  "nome": "Novo Nome",
  "preco": 150.0,
  "descricao": "Nova descrição"
}

Estrutura do Projeto

Controllers
Contém o ProdutoController, responsável por gerenciar os endpoints da API.

Classes
Contém a classe Produto, que define o modelo de dados dos produtos.

Context
Contém ProdutoContext, que configura o Entity Framework Core para acessar o banco de dados MySQL.

Program.cs
Configura a aplicação, registra o DbContext, habilita o Swagger para documentação e inicializa a API.

Configuração do Banco de Dados

No arquivo appsettings.json, configure a string de conexão com seu banco MySQL:

"ConnectionStrings": {
  "ConecaoPadrao": "server=localhost;database=PraticaApiDB;user=root;password=suasenha"
}


O Entity Framework Core será responsável por criar a tabela Produtos a partir da classe Produto.

Requisitos

.NET 7 SDK ou superior

MySQL

Visual Studio 2022 ou VS Code

Como Executar

Clone o repositório:

git clone https://github.com/seuusuario/PraticaApi.git


Navegue até a pasta do projeto:

cd PraticaApi


Restaure as dependências e rode a aplicação:

dotnet restore
dotnet run


Acesse o Swagger para testar os endpoints:

https://localhost:5001/swagger
