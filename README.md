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
### Run application with one command (setup all docker containers with database, change environment variables depending on system You want to use):
```
cd C:\Users\bartl\source\repos\DockerBlazorWASMTest
docker-compose --env-file linux.env up -d --build
docker-compose --env-file windows.env up -d --build
--env-file - environment variables (other for different configuration / system)
-d - detached mode (services in the background, without blocking the command prompt)
--build - rebuild the docker images
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
### Docker compose push (push all containers to docker hub)
```
docker-compose --env-file linux.env push
docker-compose --env-file windows.env push
```
### Copy files to Raspberry Pi (change <raspberrypi_ip> to correct Raspberry Pi ip)
- Copy "docker-compose.yml" file to Raspberry Pi (using scp)
- Copy "linux.env" file to Raspberry Pi (using scp)
```
scp C:\Users\bartl\source\repos\DockerBlazorWASMTest\docker-compose.yml malinka@<raspberrypi_ip>:/home/malinka/Desktop/
scp C:\Users\bartl\source\repos\DockerBlazorWASMTest\linux.env malinka@<raspberrypi_ip>:/home/malinka/Desktop/
```
##### IMPORTANT - COPY CERTIFICATE TO RASPBERRY PI!!! (use scp) -> to: $HOME/.aspnet/https (change <raspberrypi_ip> to correct Raspberry Pi ip)
```
scp C:\Users\bartl\.aspnet\https\aspnetapp.pfx malinka@<raspberrypi_ip>:/home/malinka/Desktop
scp C:\Users\bartl\.aspnet\https\private.key malinka@<raspberrypi_ip>:/home/malinka/Desktop
scp C:\Users\bartl\.aspnet\https\certificate.crt malinka@<raspberrypi_ip>:/home/malinka/Desktop
ssh malinka@<raspberrypi_ip>
sudo mv /home/malinka/Desktop/aspnetapp.pfx /home/malinka/.aspnet/https
sudo mv /home/malinka/Desktop/private.key /home/malinka/.aspnet/https
sudo mv /home/malinka/Desktop/certificate.crt /home/malinka/.aspnet/https
ls -la /home/malinka/.aspnet/https
```
### Pull and run Docker Compose on Rapberry Pi / Windows:
```
docker-compose --env-file linux.env pull
docker-compose --env-file linux.env up -d
docker-compose --env-file windows.env pull
docker-compose --env-file windows.env up -d
```
### Check docker images and containers:
```
docker images
docker ps -a
```
### Test Apis:
```
curl http://localhost:5000/api
curl -k https://localhost:5001/api
curl http://localhost:7000/api
curl -k https://localhost:7001/api
-k - ignore certificate check
```
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
