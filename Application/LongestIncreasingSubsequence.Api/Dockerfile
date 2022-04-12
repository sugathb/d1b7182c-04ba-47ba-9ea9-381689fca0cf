#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["LongestIncreasingSubsequence.Api/LongestIncreasingSubsequence.Api.csproj", "LongestIncreasingSubsequence.Api/"]
RUN dotnet restore "LongestIncreasingSubsequence.Api/LongestIncreasingSubsequence.Api.csproj"
COPY . .
WORKDIR "/src/LongestIncreasingSubsequence.Api"
RUN dotnet build "LongestIncreasingSubsequence.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LongestIncreasingSubsequence.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LongestIncreasingSubsequence.Api.dll"]