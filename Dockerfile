FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
#COPY ["WebApplication1/WebApplication1.csproj", "WebApplication1/"]
COPY . .
RUN dotnet restore "myWebApp.csproj"
RUN dotnet build "myWebApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "myWebApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "myWebApp.dll"]
