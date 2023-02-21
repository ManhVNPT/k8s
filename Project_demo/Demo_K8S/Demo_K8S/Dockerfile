#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Demo_K8S/Demo_K8S.csproj", "Demo_K8S/"]
RUN dotnet restore "Demo_K8S/Demo_K8S.csproj"
COPY . .
WORKDIR "/src/Demo_K8S"
RUN dotnet build "Demo_K8S.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Demo_K8S.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Demo_K8S.dll"]