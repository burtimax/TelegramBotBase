# Notes

## Migrations

### BotContext Migrations
~~~
ADD MIGRATIONS
1) cd AspNetTelegramBot
2) dotnet ef migrations add Initial --context BotContext -p ../AspNetTelegramBot/BotStore.csproj -s BotStore.csproj -o Src/Bot/Db/MigrationsData
3) dotnet ef database update --context BotContext

REMOVE MIGRATIONS
1) cd AspNetTelegramBot
2) dotnet ef migrations remove --context BotContext -p ../AspNetTelegramBot/BotStore.csproj -s BotStore.csproj
~~~

### SantaContext Migrations
~~~
ADD MIGRATIONS
1) cd AspNetTelegramBot
2) dotnet ef migrations add Initial --context StoreContext -p ../AspNetTelegramBot/BotStore.csproj -s BotStore.csproj -o Src/BotStore/Db/MigrationsData
3) dotnet ef database update --context StoreContext

REMOVE MIGRATIONS
1) cd AspNetTelegramBot
2) dotnet ef migrations remove --context StoreContext -p ../AspNetTelegramBot/BotStore.csproj -s BotStore.csproj
~~~