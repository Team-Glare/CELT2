#! /bin/bash
echo "Running the API locally.."
echo "Install the dependencies..."
dotnet restore
echo "Build the solution..."
dotnet build
echo "Run the API..."
cd CELTAPI
dotnet run CELTAPI.csproj &
