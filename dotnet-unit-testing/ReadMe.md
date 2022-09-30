# Unit Testing

Unit testing should be viewed as an investment. Here are a couple of invaluable returns, this investment facilitates:

1. Better initial delivery of the 1st iteration of new functionality
2. Alerts in the form of broken unit tests when developers unintentionally break existing code when implementing new features
3. Unit tests can be re-used in CI/CD Pipelines to prevent broken code making to production environments
4. Self documenting

## Assumptions 

When a developer writes a line of code, there is an assumption it will work. Every conditional statement, query and case statement is an assumption:

- Is my understanding of how a line of code executes is correct?
- Will the conditional `if` | `if else` | `else` work as expected?
- What happens if the data query returns no data, causes an exception, ...?
- Will the correct `switch` `case` statement work and do I need a `default` fallback?

If any of the above common coding practices or other, are in a newly written or updated block of code, they need to be tested separately in isolation.

## Structure

### Unit Testable Code

```
|	DataService
|		PersonDataService.cs
|           Find({...})
```

**PersonDataService.cs**

Concrete class containing unit testable functions. This pattern proposes a separate test class per function.

- PersonDataService.Find => FindTests.cs
- PersonDataService.{FunctionName} => {FunctionName}Tests.cs

### Unit Test

```
|	DataService.Tests
|		PersonDataServiceTests
|			BasePersonDataService.cs
|			FindTests.cs
```

**BasePersonDataService.cs:**

Convenience functionality written once and inherited by all {Entity}DataService test classes.

**FindTests.cs:**

Concrete unit tests. 

## Conventions

- It is optimal to write atomic unit tests. In the context of PersonDataService.Find({...}) testing single features such as:
    - What happens if the query returns empty results
    - What happens if the query returns results
    - Test different parameter combinations

[Characteristics of a good unit test](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices#characteristics-of-a-good-unit-test)

## References

- [Unit testing best practices with .NET Core and .NET Standard](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-best-practices?source=recommendations)