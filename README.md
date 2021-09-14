# Introduction
This code is designed to record the state of a battleship board with the following features:
* Create a board
* Add a battleship to the board
* Take an “attack” at a given position, and report back whether the attack
resulted in a hit or a miss.

# Running locally
* open in vscode
* hit f5 to load swagger

# Deployment Assumptions
* using vscode
* the vscode extension - azure app services is installed
* you have an azure account

# Deployment Azure 
```
cd battleships.api
dotnet publish -c Release -o ./publish
#right click on publish -> click deploy to web app -> follow the prompts
#influences: https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vscode?view=aspnetcore-5.0
```

# Hosted Url
https://pr-battleships.azurewebsites.net/swagger/index.html
