FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app


FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ["src/EDziekanat.Web.Api/EDziekanat.Web.Api.csproj", "src/EDziekanat.Web.Api/"]
COPY ["src/EDziekanat.EntityFramework/EDziekanat.EntityFramework.csproj", "src/EDziekanat.EntityFramework/"]
COPY ["src/EDziekanat.Core/EDziekanat.Core.csproj", "src/EDziekanat.Core/"]
COPY ["src/EDziekanat.Application/EDziekanat.Application.csproj", "src/EDziekanat.Application/"]
COPY ["src/EDziekanat.Utilities/EDziekanat.Utilities.csproj", "src/EDziekanat.Utilities/"]
COPY ["src/EDziekanat.Web.Core/EDziekanat.Web.Core.csproj", "src/EDziekanat.Web.Core/"]
RUN dotnet restore "src/EDziekanat.Web.Api/EDziekanat.Web.Api.csproj"
COPY . .

WORKDIR "/src/src/EDziekanat.Web.Api"
RUN dotnet build "EDziekanat.Web.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "EDziekanat.Web.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "EDziekanat.Web.Api.dll"]