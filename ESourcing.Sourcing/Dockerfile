FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY ESourcing.Sourcing/*.csproj ESourcing.Sourcing/
RUN dotnet restore ESourcing.Sourcing/*.csproj
COPY . .
RUN dotnet publish ESourcing.Sourcing/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ESourcing.Sourcing.dll" ]