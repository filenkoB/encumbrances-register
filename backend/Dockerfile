FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app

COPY ./*/*.csproj ./
RUN dotnet restore WebAPI.csproj

COPY . ./source/
WORKDIR /app/source
RUN dotnet publish -c release -o /release

EXPOSE 80

FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /release
COPY --from=build /release ./

CMD ASPNETCORE_URLS=http://*:$PORT dotnet WebAPI.dll