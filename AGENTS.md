# Setup
This project requires the .NET SDK (9.0+). If using a cloud dev environment, ensure the image includes it, or run setup.sh.
If you get "dotnet: command not found", run:
bash setup.sh

# Coding Standards
Don't use pages / component names that have the same name as a model
Don't name pages / components with the same name as a folder
use file scoped namespaces
don't abbreviate variable names


# Build
dotnet build Swol.sln

# Test
dotnet test Swol.Tests/Swol.Tests.csproj --no-build

# Format
dotnet format
