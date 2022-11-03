FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /source


COPY . .

RUN dotnet restore TaskUI/TaskUI.csproj

# copy and publish app and libraries
RUN dotnet publish TaskUI/TaskUI.csproj -c Release -o /app --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/runtime:6.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT [ "dotnet", "TaskUI.dll" ] 