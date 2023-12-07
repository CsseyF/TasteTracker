# TasteTracker

Taste Tracker é uma aplicação para coleta e gerenciamento de feedbacks
de clientes sobre restaurantes, abrangendo aspectos como avaliação de pratos, serviços e experiência geral.

## Recursos Utilizados:

Se faz necessário realizar a instalação das aplicações/frameworks abaixo:

* Visual Studio

    - **[Visual Studio](https://visualstudio.microsoft.com/downloads/?WT.mc_id=javascript-0000-gllemos)**
    - **[.NET 8]([https://dotnet.microsoft.com/download?WT.mc_id=javascript-0000-gllemos](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0))**

## Rodando o projeto
Rode estes comandos do CLI no na pasta do projeto TasteTracker.API:

```console
dotnet build
dotnet run
```

## Criando o container docker

```
docker run -e "ACCEPT_EULA=Y" -e "SA_PASSWORD=tasteTracker2929" -p 1433:1433 --name tasteTracker -d mcr.microsoft.com/mssql/server
```



## Rodando as migrations

A partir do projeto TasteTracker.Persistence, rode o seguinte comando:

```console
dotnet ef database update --startup-project ..\TasteTracker.API\
```

## Endpoints Principais

### POST: /Auth
Request para autenticação dos outros endpoints.
```
{
  "email": "seuemail@email.com",
  "password": "suasenha"
}
```

### POST: /Cliente
Request para criação de novo usuário.

```
{
  "firstName": "casey",
  "lastName": "fernandes",
  "email": "novoemail@email.com",
  "password": "novasenha"
}
```

### 
