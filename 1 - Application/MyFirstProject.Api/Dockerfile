FROM  mcr.microsoft.com/dotnet/aspnet:5.0-alpine AS base
WORKDIR /app
EXPOSE 80

RUN apk add icu-libs
# https://www.abhith.net/blog/docker-sql-error-on-aspnet-core-alpine/
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false

FROM mcr.microsoft.com/dotnet/sdk:5.0-alpine AS build
WORKDIR /src
COPY ["1 - Application/MyFirstProject.Api/MyFirstProject.Api.csproj", "1 - Application/MyFirstProject.Api/"]
COPY ["2 - Domain/MyFirstProject.Domain/MyFirstProject.Domain.csproj", "2 - Application/MyFirstProject.Domain/"]
COPY ["3 - Data/MyFirstProject.Data/MyFirstProject.Data.csproj", "3 - Application/MyFirstProject.Data/"]
COPY ["4 - Infra/MyFirstProject.Infra.CrossCutting.IoC/MyFirstProject.Infra.CrossCutting.IoC.csproj", "4 - Application/MyFirstProject.Infra.CrossCutting.IoC/"]
COPY ["5 - Shared/MyFirstProject.Shared/MyFirstProject.Shared.csproj", "5 - Shared/MyFirstProject.Shared/"]
RUN dotnet restore "1 - Application/MyFirstProject.Api/MyFirstProject.Api.csproj"
COPY . .
WORKDIR "/src/1 - Application/MyFirstProject.Api"
RUN dotnet build "MyFirstProject.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MyFirstProject.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyFirstProject.Api.dll"]