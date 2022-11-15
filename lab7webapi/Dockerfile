#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["lab7webapi/lab7webapi.csproj", "lab7webapi/"]
RUN dotnet restore "lab7webapi/lab7webapi.csproj"
COPY . .
WORKDIR "/src/lab7webapi"
RUN dotnet build "lab7webapi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "lab7webapi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "lab7webapi.dll"]