FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["SnakeGame/SnakeGame.csproj", "SnakeGame/"]
RUN dotnet restore "SnakeGame/SnakeGame.csproj"
COPY . .
WORKDIR "/src/SnakeGame"
RUN dotnet build "SnakeGame.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SnakeGame.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SnakeGame.dll"]
