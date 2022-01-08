FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /AP

ENTRYPOINT ["dotnet", "watch", "run", "--project", "AP.Host/AP.Host.csproj"]