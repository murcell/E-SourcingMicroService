FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
WORKDIR /app
EXPOSE 80
COPY ESourcing.Order/*.csproj ESourcing.Order/
COPY EventBusRabbitMQ/*.csproj EventBusRabbitMQ/
COPY Ordering.Application/*.csproj Ordering.Application/
COPY Ordering.Domain/*.csproj Ordering.Domain/
COPY Ordering.Infastructure/*.csproj Ordering.Infastructure/
RUN dotnet restore ESourcing.Order/*.csproj
COPY . .
RUN dotnet publish ESourcing.Order/*.csproj -c Release -o out
FROM mcr.microsoft.com/dotnet/aspnet:8.0 as runtime
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet","ESourcing.Order.dll" ]