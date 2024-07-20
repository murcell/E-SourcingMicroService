FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY Esourcing.Gateway/*.csproj Esourcing.Gateway/
RUN dotnet restore Esourcing.Gateway/*.csproj
COPY . .
RUN dotnet publish Esourcing.Gateway/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","Esourcing.Gateway.dll" ]