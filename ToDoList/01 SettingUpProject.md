# Setting Up Final Project

## 📡 Creating ToDoList.WebApi project

```cmd
cd ToDoList
dotnet new web --name ToDoList.WebApi --output src/ToDoList.WebApi
```

## 📘 Creating ToDoList.Model project

```cmd
cd ToDoList
dotnet new classlib --name ToDoList.Model --output src/ToDoList.Model
```

## 🗃️ Creating ToDoList.Persistency project

```cmd
cd ToDoList
dotnet new classlib --name ToDoList.Persistency --output src/ToDoList.Persistency
```

## 🧪 Creating ToDoList.Test project

```cmd
cd ToDoList
dotnet new xunit --name ToDoList.Test --output tests/ToDoList.Test
```

## 🌐 Creating ToDoList.Frontend project

```cmd
cd ToDoList
dotnet new blazor --interactivity None --empty --name ToDoList.Frontend --output src/ToDoList.Frontend
```
