# Introduction
This code is designed to record the state of a battleship board with the following features:
* Create a board
* Add a battleship to the board
* Take an “attack” at a given position, and report back whether the attack
resulted in a hit or a miss.

# Assumptions
* using vscode
* azure app services installed
* azure account owned

# Deployment Azure 
```
cd battleships.api
dotnet publish -c Release -o ./publish
#right click on publish -> click deploy to web app -> follow the prompts
#influences: https://docs.microsoft.com/en-us/aspnet/core/tutorials/publish-to-azure-webapp-using-vscode?view=aspnetcore-5.0
```

# Hosted Url
https://pr-battleships.azurewebsites.net/swagger/index.html
