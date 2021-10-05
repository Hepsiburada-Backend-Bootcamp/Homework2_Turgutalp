FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Homework1.API/Homework1.API.csproj", "Homework1.API/"]
RUN dotnet restore "Homework1.API/Homework1.API.csproj"
COPY . .
WORKDIR "/src/Homework1.API"
RUN dotnet build "Homework1.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Homework1.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Homework1.API.dll"]
