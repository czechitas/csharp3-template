# Entity Framework Setup

[Microsoft Article](https://learn.microsoft.com/en-us/ef/core/cli/dotnet)

1. ❕Install Entity Framework CLI tools

    ```cmd
    dotnet tool install --global dotnet-ef
    ```

2. 🦄 Make sure your Entity Framework CLI tools are properly installed

    ```cmd
    dotnet ef
    ```

    Output should show a unicorn logo text art and your installed version

    ```cmd
                     _/\__       
               ---==/    \\
         ___  ___   |.    \|\
        | __|| __|  |  )   \\\
        | _| | _|   \_/ |  //|\\
        |___||_|       /   \\\/\\

    Entity Framework Core .NET Command-line Tools 8.0.7 <your version>

    <Usage documentation follows, not shown.>
    ```

3. 📦 Before you can use the tools on a specific project, you'll need to add the Microsoft.`EntityFrameworkCore.Design` package to it. Use NuGet manager or following command

   ```cmd
    dotnet add package Microsoft.EntityFrameworkCore.Design
   ```
