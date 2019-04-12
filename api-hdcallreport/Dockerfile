FROM microsoft/dotnet:2.1-sdk AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY "api-hdcallreport.csproj" "api-hdcallreport/"
RUN dotnet restore "api-hdcallreport/api-hdcallreport.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "api-hdcallreport.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "api-hdcallreport.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "api-hdcallreport.dll"]