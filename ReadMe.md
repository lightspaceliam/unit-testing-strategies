# Unit Testing Strategies

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

## Structures

```
| dotnet-unit-testing
|       Api
|       Api.Tests
|       DataService
|       DataService.Tests
```

TODO: React unit testing