# 📂 Package
* dotnet add package Microsoft.VisualStudio.Web.CodeGeneration
* dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design

# I. dotnet aspnet-codegenerator

```shell
# Controller
dotnet aspnet-codegenerator controller -name CarController -outDir Controllers

# View
dotnet aspnet-codegenerator view Index Empty -outDir Views/Car -l _Layout -f

# Area
dotnet aspnet-codegenerator area CarArea