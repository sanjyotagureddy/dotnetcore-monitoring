#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/DotNet.Monitoring.Api/DotNet.Monitoring.Api.csproj", "src/DotNet.Monitoring.Api/"]
COPY ["src/DotNet.Monitoring.Core/DotNet.Monitoring.Core.csproj", "src/DotNet.Monitoring.Core/"]
COPY ["src/DotNet.Monitoring.AssemblyScanning.Container/DotNet.Monitoring.AssemblyScanning.Container.csproj", "src/DotNet.Monitoring.AssemblyScanning.Container/"]
COPY ["src/DotNet.Monitoring.Common/DotNet.Monitoring.Common.csproj", "src/DotNet.Monitoring.Common/"]
COPY ["src/DotNet.Monitoring.Contracts/DotNet.Monitoring.Contracts.csproj", "src/DotNet.Monitoring.Contracts/"]
COPY ["src/DotNet.Monitoring.Presentation/DotNet.Monitoring.Presentation.csproj", "src/DotNet.Monitoring.Presentation/"]
COPY ["src/DotNet.Monitoring.Contracts.Presentation/DotNet.Monitoring.Contracts.Presentation.csproj", "src/DotNet.Monitoring.Contracts.Presentation/"]
COPY ["src/DotNet.Monitoring.Contracts.Services/DotNet.Monitoring.Contracts.Services.csproj", "src/DotNet.Monitoring.Contracts.Services/"]
RUN dotnet restore "src/DotNet.Monitoring.Api/DotNet.Monitoring.Api.csproj"
COPY . .
WORKDIR "/src/src/DotNet.Monitoring.Api"
RUN dotnet build "DotNet.Monitoring.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DotNet.Monitoring.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DotNet.Monitoring.Api.dll"]