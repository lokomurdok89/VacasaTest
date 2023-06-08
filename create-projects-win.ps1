Write-Host "About to Create the directory" -ForegroundColor Green

mkdir ServicesTest
Set-Location ServicesTest

Write-Host "About to create the solution and projects" -ForegroundColor Green
dotnet new sln
dotnet new webapi -n API

Set-Location API

    New-Item -ItemType Directory -Path "Application"
    New-Item -ItemType Directory -Path "Domain"
    New-Item -ItemType Directory -Path "Persistence"

Write-Host "Executing dotnet restore" -ForegroundColor Green
dotnet restore

Write-Host "Finished!" -ForegroundColor Green
