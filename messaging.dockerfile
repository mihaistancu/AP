FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /messaging

ENTRYPOINT ["dotnet", "watch", "run", "--project", "AP.Host/AP.Host.csproj"]