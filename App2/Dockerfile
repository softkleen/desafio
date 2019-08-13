FROM microsoft/aspnetcore:2.0 AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0 AS build
WORKDIR /src
COPY App1.sln ./
COPY App2/App2.csproj App2/
RUN dotnet restore -nowarn:msb3202,nu1503
COPY . .
WORKDIR /src/App2
RUN dotnet build -c Release -o /app

FROM build AS publish
RUN dotnet publish -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "App2.dll"]
