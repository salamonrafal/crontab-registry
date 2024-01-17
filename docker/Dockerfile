# ##################################################### #
# This is Dockerfile use for production                 #
# ##################################################### #
FROM mcr.microsoft.com/dotnet/sdk:6.0 as build
WORKDIR /application
COPY . .

RUN dotnet restore ./src/CrontabRegistry/Application/Application.csproj; \
	dotnet publish ./src/CrontabRegistry/Application/Application.csproj -o ./publish;

FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine as runtime
ENV ASPNETCORE_URLS=http://+:4500
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=true

WORKDIR /application

COPY --from=build /application/publish /application

EXPOSE 4500
ENTRYPOINT [ "dotnet", "/application/Application.dll" ]