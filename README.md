# Projeto Wake Commerce

Projetos da solução foram criados com base na Clean Architecturer apresentada por Jason Taylor, no link https://jasontaylor.dev/clean-architecture-getting-started/

Domain: entidades de modelo de banco de dados e DTOs.
Application: mapeamento de entidades, interfaces, handlers e comandos (padrão Mediator).
Infrastructurer: persistência de dados, repositórios e afins.
WakeCommerce(API): controladores.

Está sendo utilizado o PostgreSQL como base de dados, através do container feito no arquivo docker-compose.yml

Para iniciar o container é necessário ter o Docker Desktop instalado e dentro da pasta onde temos o docker-compose.yml executar o seguinte comando no terminal: docker compose up -d

Para manipulação das tabelas foi utilizado a abordagem Code-First com EF Core, então é importante ter instalado a biblioteca na máquina para debug, segue comando: dotnet tool install --global dotnet-ef

A aplicação deverá criar as tabelas de forma automática ao iniciar, porém caso tenha problema em criar as tabelas após feito o conteiner, vá na pasta dentro do repositório local src/Infrastructurer e execute o comando:
dotnet ef --startup-project ../WakeCommerce/. database update

OBS.: projeto de testes não foi 100% finalizado, devido problemas com o banco de dados de teste.