FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VolvoTrucks.Web/VolvoTrucks.Web.csproj", "VolvoTrucks.Web/"]
RUN dotnet restore "VolvoTrucks.Web/VolvoTrucks.Web.csproj"
COPY . .
WORKDIR "/src/VolvoTrucks.Web"
RUN dotnet build "VolvoTrucks.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VolvoTrucks.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VolvoTrucks.Web.dll"]
