FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY EESourcing.UI/*.csproj ESourcing.UI/
COPY ESourcing.Core/*.csproj ESourcing.Core/
COPY Esourcing.Infastructure/*.csproj Esourcing.Infastructure/
RUN dotnet restore ESourcing.UI/*.csproj
COPY . .
RUN dotnet publish ESourcing.UI/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ESourcing.UI.dll" ]