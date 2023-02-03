FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ProfileApi/ProfileApi.csproj", "ProfileApi/"]
RUN dotnet restore "ProfileApi/Profile.Api.csproj"
COPY . .
WORKDIR "/src/ProfileApi"
RUN dotnet build "Profile.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Profile.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Profile.Api.dll"]
