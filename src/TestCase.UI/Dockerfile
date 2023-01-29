FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/TestCase.UI/TestCase.UI.csproj", "TestCase.UI/"]
RUN dotnet restore "src/TestCase.UI/TestCase.UI.csproj"
COPY . .
WORKDIR "/src/TestCase.UI"
RUN dotnet build "TestCase.UI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TestCase.UI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TestCase.UI.dll"]
