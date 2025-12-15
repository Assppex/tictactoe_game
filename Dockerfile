FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# 🔑 Ключевая настройка порта:
ENV ASPNETCORE_URLS=http://+:8080

WORKDIR /app

COPY . /app

RUN dotnet publish -c Release -o /app/publish

WORKDIR /app/publish

ENTRYPOINT ["dotnet", "cros_dots_hw_blazor.dll"]