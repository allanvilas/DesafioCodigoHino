# Etapa 1: Build da aplicação
# Usa a imagem oficial do SDK do .NET para compilar a aplicação
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia o arquivo de projeto (.csproj) e restaura as dependências
COPY *.csproj ./
RUN dotnet restore

# Copia o restante dos arquivos do projeto e compila a aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# Etapa 2: Runtime da aplicação
# Usa a imagem oficial do runtime do .NET para rodar a aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Define o diretório de trabalho dentro do container
WORKDIR /app

# Copia os binários gerados na etapa de build para o runtime
COPY --from=build /app/out .

# Expõe a porta em que a aplicação será executada
EXPOSE 5200

# Comando de inicialização da aplicação
ENTRYPOINT ["dotnet", "DesafioCodigoHino.dll"]
