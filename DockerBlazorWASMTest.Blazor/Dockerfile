FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /app
COPY ["DockerBlazorWASMTest.Blazor/DockerBlazorWASMTest.Blazor.csproj", "DockerBlazorWASMTest.Blazor/"]
RUN dotnet restore "./DockerBlazorWASMTest.Blazor/DockerBlazorWASMTest.Blazor.csproj"
COPY . .
WORKDIR "/app/DockerBlazorWASMTest.Blazor"
RUN dotnet build "./DockerBlazorWASMTest.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./DockerBlazorWASMTest.Blazor.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM nginx:alpine
EXPOSE 80
EXPOSE 443
WORKDIR /usr/share/nginx/html
# Copy published app files
COPY --from=publish /app/publish/wwwroot/ .
# Copy nginx.conf file
COPY ./DockerBlazorWASMTest.Blazor/nginx.conf /etc/nginx/nginx.conf