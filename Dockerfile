FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /App

# Copys everything
COPY . ./

#restores as distinct layers
RUN dotnet restore

#build and publish a relase
RUN dotnet publish -c Release -o out

#build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /App
COPY --from=build-env /App/out .

ENTRYPOINT ["dotnet", "BFS-and-DFS.dll"]

