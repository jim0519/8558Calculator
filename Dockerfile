FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["AspNetCoreWebApp/AspNetCoreWebApp.csproj", "AspNetCoreWebApp/"]
RUN dotnet restore "AspNetCoreWebApp/AspNetCoreWebApp.csproj"
COPY . .
WORKDIR "/src/AspNetCoreWebApp"
RUN dotnet build "AspNetCoreWebApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "AspNetCoreWebApp.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "AspNetCoreWebApp.dll"]