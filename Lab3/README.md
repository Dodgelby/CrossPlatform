## Запуск проекту

```bash
echo "Building library..."
dotnet build ClassLibraryLab3
```

```bash
echo "Packing library..."
dotnet pack ClassLibraryLab3 -o NugetLocalRepo
```

```bash
echo "Adding NuGet source..."
dotnet nuget add source NugetLocalRepo --name LocalNuget
```

```bash
echo "Building app..."
cd ClassLibraryLab3
dotnet add package DPoliarush --source ../NugetLocalRepo
dotnet run
```
![image](https://github.com/user-attachments/assets/7f90bb04-dc0c-4f6d-87a0-0abd3bf35d6c)
![image](https://github.com/user-attachments/assets/39726ca9-dbad-4450-9276-b401d3c743e6)
