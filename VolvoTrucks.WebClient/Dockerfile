FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["VoltoTrucks.WebClient/VoltoTrucks.WebClient.csproj", "VoltoTrucks.WebClient/"]
RUN dotnet restore "VoltoTrucks.WebClient/VoltoTrucks.WebClient.csproj"
COPY . .
WORKDIR "/src/VoltoTrucks.WebClient"
RUN dotnet build "VoltoTrucks.WebClient.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "VoltoTrucks.WebClient.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VoltoTrucks.WebClient.dll"]
