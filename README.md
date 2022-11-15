dotnet new sln -n YA-Cap -o YA-Cap
cd YA-Cap/
dotnet new webapi -o src/YACap.API
dotnet sln add src/YACap.API/YACap.API.csproj

dotnet run --project src/YACap.API/YACap.API.csproj

cd src/YACap.API/
dotnet add package DotNetCore.CAP --version 6.2.1
dotnet add package DotNetCore.CAP.InMemoryStorage --version 6.2.1
dotnet add package Savorboard.CAP.InMemoryMessageQueue --version 6.0.0