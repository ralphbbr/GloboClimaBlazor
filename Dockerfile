# Usar a imagem do SDK do .NET
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copiar os arquivos de projeto do Blazor
COPY *.csproj ./
# Restaurar as dependências do Blazor
RUN dotnet restore GloboClimaBlazor.csproj

# Copiar o restante dos arquivos
COPY . ./

# Construir e publicar a aplicação Blazor
RUN dotnet publish GloboClimaBlazor.csproj -c Release -o out

# Imagem de runtime para a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .
ENTRYPOINT ["dotnet", "GloboClimaBlazor.dll"]
