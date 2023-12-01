## API de Gestão de Restaurante

### Features

- [x] Documentação da API com swagger
- [x] Autenticação e Autorização com JWT
- [x] Endpoint com dados para gráficos para dashboard
- [x] Gerenciar Demandas da Cozinha e do Garçom
- [x] Cadastrar e visualizar todos pedidos comuns
- [x] Cadastrar e visualizar todos pedidos delivery
- [x] Gerenciar os produtos( visualizar,cadastrar, editar e excluir)
- [x] Gerenciar as categorias de produtos( visualizar,cadastrar, editar e excluir)
- [x] Gerenciar as mesas( visualizar,cadastrar, editar e excluir)
- [x] Gerenciar os usuários( visualizar,cadastrar)
- [x] Fechar conta (finalizar pedido com pagamento pendente)
- [] Upload imagens dos produtos e usuários no Storage da Azure
- [] Caching com Redis
- [] Logs, monitoramento da API


### 🛠 Tecnologias

As seguintes ferramentas foram usadas na construção do projeto:
- [.NET](https://dotnet.microsoft.com/en-us/)
- [SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-2019)
- [Microsoft Azure](https://azure.microsoft.com/pt-br/)

### 🛠 Padrões Utilizados

As seguintes padrões foram usados na construção do projeto:
- DDD (Domain-Driven Design)
- CQRS (Command Query Responsibility Segregation)
- SOLID

### Pré-requisitos

Antes de começar, você vai precisar ter instalado em sua máquina as seguintes ferramentas:
[Git](https://git-scm.com), [.NET](https://dotnet.microsoft.com/en-us/).
[SQLServer](https://www.microsoft.com/pt-br/sql-server/sql-server-2019) ou subir container utilizando o [Docker](https://www.docker.com/).
Além disto é bom ter um editor para trabalhar com o código como [Visual Studio](https://visualstudio.microsoft.com/pt-br/downloads/).
Também é preciso configurar as váriaveis de conexão com banco de dados no arquivo `api-restaurant-dotnet/src/Restaurant.API/appsettings.Development.json`.

### 🎲 Rodando o Back End (servidor)

#### Rodando Confitec.API

```bash
# Clone este repositório
$ git clone <https://github.com/henriquesan14/api-restaurant-dotnet.git>

# Acesse a pasta do projeto no terminal/cmd
$ cd api-restaurant-dotnet

# Vá para a pasta da Confitec.API
$ cd src/Restaurant.API

# Execute a aplicação com o comando do dotnet
$ dotnet run

# A API iniciará na porta:5000 com HTTP e na porta:5001 com HTTPS - acesse <http://localhost:5001>
```

### Autor
---

<a href="https://www.linkedin.com/in/henrique-san/">
 <img style="border-radius: 50%;" src="https://avatars.githubusercontent.com/u/33522361?v=4" width="100px;" alt=""/>
 <br />
 <sub><b>Henrique Santos</b></sub></a> <a href="https://www.linkedin.com/in/henrique-san/">🚀</a>


Feito com ❤️ por Henrique Santos 👋🏽 Entre em contato!

[![Linkedin Badge](https://img.shields.io/badge/-Henrique-blue?style=flat-square&logo=Linkedin&logoColor=white&link=https://www.linkedin.com/in/henrique-san/)](https://www.linkedin.com/in/henrique-san/) 
