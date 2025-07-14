FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base
WORKDIR /app
EXPOSE 3000
EXPOSE 3001

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Копируем ВСЕ .csproj файлы (с правильными путями)
COPY ["BG.Service/BG.Service.csproj", "BG.Service/"]
COPY ["BG.Data/BG.Data.csproj", "BG.Data/"]
COPY ["BG.Repository/BG.Repository.csproj", "BG.Repository/"]
COPY ["BudgetGuard/BudgetGuard.csproj", "BudgetGuard/"]

# Восстанавливаем зависимости
RUN dotnet restore "BudgetGuard/BudgetGuard.csproj"

# Копируем остальные файлы
COPY . .

# Собираем проект
WORKDIR "/src/BudgetGuard"
RUN dotnet build "BudgetGuard.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION
RUN dotnet publish "BudgetGuard.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "BudgetGuard.dll"]