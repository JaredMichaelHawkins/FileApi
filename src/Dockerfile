FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# copy csproj and restore as distinct layers
COPY ["File.Core/File.Core.csproj", "File.Core/"]
COPY ["File.Domain/File.Domain.csproj", "File.Domain/"]
COPY ["File.Infrastructure/File.Infrastructure.csproj", "File.Infrastructure/"]
COPY ["File.API/File.API.csproj", "File.API/"]
RUN dotnet restore "File.API/File.API.csproj"


# copy and build app and libraries
COPY ["File.Core/", "File.Core/"]
COPY ["File.Domain/", "File.Domain/"]
COPY ["File.Infrastructure/", "File.Infrastructure/"]
COPY ["File.API/", "File.API/"]
WORKDIR "/src/File.API"
RUN dotnet build "File.API.csproj" --no-restore -c Release -o /app/build

FROM build AS publish
WORKDIR "/src/File.API"
RUN dotnet publish --no-restore -o /app

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:7.0 AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "File.API.dll"]
