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

# Possible concern
* returning the board after adding a ship may need to be hidden from the user playing the game - Putting it in the api response may or may not be bad but it helps testing validation. One option could be to base64 the board in the response.
* more testing is obiously required. Other tests are written in the comments of the integration test
