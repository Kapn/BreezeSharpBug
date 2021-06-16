Models Scaffolded from Package Manager console with the following command:
```
dotnet ef dbcontext scaffold "Server=localhost;Database=Northwind;User ID=sa;Password=Pa`$`$word" Microsoft.EntityFrameworkCore.SqlServer --output-dir Models --use-database-names --force --startup-project NorthwindServer/ --project NorthwindModel/
```