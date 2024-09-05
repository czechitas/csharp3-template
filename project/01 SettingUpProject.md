# Setting Up Final Project

## 🗂️ Setting up folder structure and helper files

```cmd
cd project
dotnet new sln --name ToDoList
mkdir src
mkdir tests
dotnet new editorconfig
dotnet new globaljson --roll-forward latestMajor
dotnet new gitignore
```

## 📡 Creating ToDoList.WebApi project

```cmd
cd project
dotnet new webapi --name ToDoList.WebApi --output src/ToDoList.WebApi
```

## 📘 Creating ToDoList.Model project

```cmd
cd project
dotnet new classlib --name ToDoList.Model --output src/ToDoList.Model
```

## 🗃️ Creating ToDoList.Persistency project

```cmd
cd project
dotnet new classlib --name ToDoList.Persistency --output src/ToDoList.Persistency
```

## 🧪 Creating ToDoList.Test project

```cmd
cd project
dotnet new xunit --name ToDoList.Test --output tests/ToDoList.Test
```

## 🌐 Creating ToDoList.Frontend project

```cmd
cd project
dotnet new blazor --interactivity None --empty --name ToDoList.Frontend --output src/ToDoList.Frontend
```
