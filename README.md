# Introduction

Designed to be: 
```
expose api gateway endpoint -> vpc link -> nlb -> ecs fargate -> using Elastic search as the repository.
```
Essentially  it's a search api that proxies elastic search queries

# Background
- was initally planned to be a lambda using docker and .net 5.0 but the cold starts were to slow.
- lambda templates: https://docs.aws.amazon.com/lambda/latest/dg/csharp-package-cli.html
- developed in vs code

# Main pieces:

* Function.cs - class file containing a class with a single function handler method
* Integration tests that tests the business logic with an aws hosted elastic search (needs vpn)
* cloudformation script for network load balancer deloyment
* cloudformation script for ecs fargate deloyment
* cloudformation script for api gateway deloyment
* previous cfn for lambda deployment (not being used was too slow to process requests)

## Test the api locally with swagger
* In vscode hit f5
* Swagger Ui should load

## Test locally with postman
* import collection of api calls to postman
* ./Public Gateway.postman_collection.json
