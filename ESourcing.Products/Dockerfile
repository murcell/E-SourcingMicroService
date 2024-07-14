FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY ESourcing.Products/*.csproj ESourcing.Products/
RUN dotnet restore ESourcing.Products/*.csproj
COPY . .
RUN dotnet publish ESourcing.Products/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ESourcing.Products.dll" ]