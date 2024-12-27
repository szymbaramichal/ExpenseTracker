# Stage 1: Build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY *.sln ./
COPY ExpenseTracker.App/*.csproj ExpenseTracker.App/
COPY ExpenseTracker.Business/*.csproj ExpenseTracker.Business/
COPY ExpenseTracker.Core/*.csproj ExpenseTracker.Core/
COPY ExpenseTracker.Infrastructure/*.csproj ExpenseTracker.Infrastructure/
RUN dotnet restore ExpenseTracker.App/ExpenseTracker.App.csproj

COPY . .
WORKDIR /src/ExpenseTracker.App
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /publish .

EXPOSE 5000

ENTRYPOINT ["dotnet", "ExpenseTracker.App.dll"]
