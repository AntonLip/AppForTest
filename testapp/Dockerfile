#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["testapp/testapp.csproj", "testapp/"]
COPY ["testapp.DataAccess/testapp.DataAccess.csproj", "testapp.DataAccess/"]
COPY ["testapp.Models/testapp.Models.csproj", "testapp.Models/"]
COPY ["testapp.Services/testapp.Services.csproj", "testapp.Services/"]
RUN dotnet restore "testapp/testapp.csproj"
COPY . .
WORKDIR "/src/testapp"
RUN dotnet build "testapp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "testapp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
ENV CONN_STR_SERVER=""
ENV CONN_STR_PORT="1433"
ENV CONN_STR_USER=""
ENV CONN_STR_USER_PASSWORD="!"
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "testapp.dll"]