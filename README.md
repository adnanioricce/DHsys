[![License](https://img.shields.io/pypi/l/ansicolortags.svg)](https://img.shields.io/github/license/adnanioricce/DHsys)
![Build](https://img.shields.io/github/workflow/status/adnanioricce/DHsys/ci/master)

# DHsys
DHsys is a little side project of mine that I create to replicate a POS system in a pharmacy in a more "modern" way(meaning, not written in clipper). The project is separated between it's Web API and his Libraries. Currently, this is just a playground that I Will keep for a little while
# How to Build and run the Api project

## With source code

The following is required to build and run the project:

- .Net Core sdk 3.1 or Higher
- Postgresql 10 or higher

If you have the requirements, just follow the steps:

- Create a database in the postgresql server. By default, the projects expects a database with name dhsysdb
- update database connection string in the appsettings.json on src/Presentation/Api/appsettings.json if needed.
- run the project
- Go to http://localhost:5000/api
## With Docker

start a postgresql container.

```docker run --name dhsysdb -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=dhsysdb -d postgres```

start a dhsysdb container with a db container host and connection string 
```docker run --name dhsys-api -p 5000:5000 -e DH_CONNECTION_STRING=User ID=postgres;Password=postgres;Host=dhsysdb;Port=5432;Database=dhsysdb;Pooling=true; -d dhsysapi```

you should be seeing this screen:
![Api Docs](./docs/img/api_swagger.png)
## Use CI Build
You can access a CI build of the project in [DHsys CI](http://dhsysapi.adnangonzagaci.com/api/v1/)

# Using the Web Api
## Crud Methods
Each entity has basic CRUD endpoints

Create: ``POST /api/{entity}/create?api-version=1.0``

Read: ``GET /api/{entity}?api-version=1.0&id=79001``

Update: ``PUT /api/{entity}?api-version=1.0&id=79001``

Delete: ``DELETE /api/{entity}?api-version=1.0&id=79001``

Create Validation: ``POST /api/{entity}/validate-create?api-version=1.0``

to use Create,Update and Create Validation endpoints, you need to send the object in the body request

## Query entries with OData
You can query entity data with OData in the ``/api/{entity}/query`` endpoint
Some examples 

Top: ``/api/Product/query?api-version=1.0&$top=100``

![Query Top](./docs/img/query_top.png)

Select: ``/api/Product/query?api-version=1.0&$top=100&$select=uniqueCode,name,commercialName,manufacturerName,manufacturerCountry``

![Query Select](./docs/img/query_select.png)

OrderBy: ``/api/Product/query?api-version=1.0&$top=100&$select=uniqueCode,name,commercialName,manufacturerName,manufacturerCountry&$orderBy=id``

![Query OrderBy](./docs/img/query_orderBy.png)

Filter: ``/api/Product/query?api-version=1.0&$=top=100&$select=id,uniqueCode,name,riskClass&$filter=id eq 79001``

![Query Filter](./docs/img/query_filter.png)
