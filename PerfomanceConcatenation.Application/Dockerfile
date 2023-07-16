FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["PerfomanceConcatenation.Application/PerfomanceConcatenation.Application.csproj", "PerfomanceConcatenation.Application/"]
RUN dotnet restore "PerfomanceConcatenation.Application/PerfomanceConcatenation.Application.csproj"
COPY . .
WORKDIR "/src/PerfomanceConcatenation.Application"
RUN dotnet build "PerfomanceConcatenation.Application.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PerfomanceConcatenation.Application.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PerfomanceConcatenation.Application.dll"]
