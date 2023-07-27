# Sample TDD with NUnit and .NET
This is the sample TDD with C# and .NET using NUnit Test Framework.

Project scaffoled by using

```bash
dotnet new nunit -n <NAME.Core.Tests>
dotnet new sln -name <NAME>
dotnet sln add <NAME.Core.Tests>/<NAME.Core.Tests>.csproj
```

Run test by using

```bash
dotnet restore
dotnet test
```