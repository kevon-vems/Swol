# Setup
If you get "dotnet: command not found", run:
bash setup.sh

# Build
dotnet build Swol.sln

# Test
dotnet test Swol.Tests/Swol.Tests.csproj --no-build

# Format
dotnet format
