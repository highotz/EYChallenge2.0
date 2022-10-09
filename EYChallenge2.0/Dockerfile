#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EYChallenge2.0/EYChallenge2.0.csproj", "EYChallenge2.0/"]
RUN dotnet restore "EYChallenge2.0/EYChallenge2.0.csproj"
COPY . .
WORKDIR "/src/EYChallenge2.0"
RUN dotnet build "EYChallenge2.0.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EYChallenge2.0.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EYChallenge2.0.dll"]