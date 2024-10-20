# Entity Framework Database Migrations

[Microsoft Article](https://learn.microsoft.com/en-us/ef/core/managing-schemas/migrations/?tabs=dotnet-core-cli)

## 1️⃣ First Time Only - No database yet

1. ▶️ **First Time only!** Create first migration

    ```cmd
    dotnet ef migrations add InitialCreate
    ```

2. ➡️ **First Time only!** Updating database and creating schema

    ```cmd
    dotnet ef database update
    ```

## 🔃 Updating Database Schema

1. ⏩ Creating a migration (use explicit name)

    ```cmd
    dotnet ef migrations add <your_migration_name_here>
    ```

2. ➡️ Updating database and creating schema

    ```cmd
    dotnet ef database update
    ```
