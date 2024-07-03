#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Cursus.LMS.API/Cursus.LMS.API.csproj", "Cursus.LMS.API/"]
COPY ["Cursus.LMS.Service/Cursus.LMS.Service.csproj", "Cursus.LMS.Service/"]
COPY ["Cursus.LMS.DataAccess/Cursus.LMS.DataAccess.csproj", "Cursus.LMS.DataAccess/"]
COPY ["Cursus.LMS.Model/Cursus.LMS.Model.csproj", "Cursus.LMS.Model/"]
COPY ["Cursus.LMS.Utility/Cursus.LMS.Utility.csproj", "Cursus.LMS.Utility/"]
RUN dotnet restore "./Cursus.LMS.API/Cursus.LMS.API.csproj"
COPY . .
WORKDIR "/src/Cursus.LMS.API"
RUN dotnet build "./Cursus.LMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Cursus.LMS.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Cursus.LMS.API.dll"]