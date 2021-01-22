[![License](https://img.shields.io/pypi/l/ansicolortags.svg)](https://img.shields.io/github/license/adnanioricce/DHsys)
![Build](https://img.shields.io/github/workflow/status/adnanioricce/DHsys/ci/master)

# DHsys
DHsys is a little side project of mine that I create to replicate a POS system in a pharmacy in a more "modern" way(meaning, not written in clipper). The project is separated between it's Web API and his Libraries. Currently, this is just a playground that I Will keep for a little while
# Requirements
- Framework .Net Core 3.1 
- Postgresql 11 or higher
# How to run
Go to src/Presentation/Api

execute dotnet run on your shell

Optionally, on Visual Studio, select the Api Project and run the project.

after this, go to http://localhost:5000/api/v1/ to see the generated api docs
# Running with docker
If you have docker, you can run project docker image

first create the database
```docker run --name dhsysdb -e POSTGRES_PASSWORD=postgres -e POSTGRES_DB=dhsysdb -d postgres```

after that, run a instance of the project

```bash 
#DH_CONNECTION_STRING is optional, since the image uses dhsysdb by default, but if you want to give a different connection string to the api...
docker run --name dhsys -e DH_CONNECTION_STRING="User ID=postgres;Password=postgres;Host=dhsysdb;Port=5432;Database=dhsysdb;Pooling=true;" -d adnanioricce/dhsys
```
go to http://localhost:5000/api/v1/