# DockerBlazorWASMTest
This repository contains C# web API backend with database and Blazor WASM frontend served in docker-compose file.

### Generate https certificate for Api:
```
cd %USERPROFILE%
dotnet dev-certs https --clean
dotnet dev-certs https -ep .aspnet\https\aspnetapp.pfx -p password
dotnet dev-certs https --trust
-ep - path to existing certificate file (.pfx) that you want to use for HTTPS development (existing PFX file)
```
### Generate https certificate for Blazor WASM (when generating certificate press ENTER):
```
cd %USERPROFILE%\.aspnet\https
Press ENTER on any prompts after this command:
openssl req -newkey rsa:2048 -nodes -keyout private.key -out certificate.csr
openssl x509 -req -days 365 -in certificate.csr -signkey private.key -out certificate.crt
```
### Run application with one command (setup all docker containers with database):
```
cd C:\Users\bartl\source\repos\DockerBlazorWASMTest
docker compose up --build -d
```
### Created containers:
- C# Web API http/https (swagger):
```
http://localhost:5000 (redirect to https 5001)
https://localhost:5001
```
- Blazor WASM frontend http/https:
```
http://localhost:7000 (redirect to https 7001)
https://localhost:7001
```
### Open the Blazor WASM frontend on https://localhost:7001, trust the website.

### Helpers:
Update ef core tools:
```
dotnet tool update --global dotnet-ef
```
Remember to change ***MIGRATION_NAME*** 
``` 
cd C:\Users\bartl\source\repos\DockerBlazorWASMTest\DockerBlazorWASMTest.Api
dotnet ef migrations add MIGRATION_NAME -o ./Migrations --startup-project ../DockerBlazorWASMTest.Api
dotnet ef migrations add Init -o ./Migrations --startup-project ../DockerBlazorWASMTest.Api
dotnet ef database update
```