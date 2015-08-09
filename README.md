# ZohoPeopleClient
Web API wrapper for Zoho People

[![Build status](https://ci.appveyor.com/api/projects/status/rsxfde6vkxgfdaby?svg=true)](https://ci.appveyor.com/project/druss/zohopeopleclient)

## The nuget package  [![NuGet Status](https://img.shields.io/nuget/v/ZohoPeopleClient.svg)](https://www.nuget.org/packages/ZohoPeopleClient/)

https://nuget.org/packages/Fody/

    PM> Install-Package ZohoPeopleClient

## Examples

### Sign in with login and password

```charp
var client = new ZohoClient();
var token = await client.LoginAsync(login, password);
// save token for further use
```

### Sing in with token

```charp
// load token from storage
var client = new ZohoClient();
client.Login(token);
```

### Get TimeLog items

```charp
var timeLogItems = await client.TimeTracker.TimeLog.GetAsync(
	"testUser@email.com",
    new DateTime(2015, 07, 01),
    new DateTime(2015, 07, 20));
```
	
### Add TimeLog record

```charp
var newLogId = await client.TimeTracker.TimeLog.AddAsync(
    "testUser@email.com",
	new DateTime(2015, 07, 30),
    "269998000000314122",
    TimeSpan.FromHours(8),
    "non-billable");
```
